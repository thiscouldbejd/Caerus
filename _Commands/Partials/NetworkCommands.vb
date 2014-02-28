Imports Caerus.Snmp
Imports Leviathan.Caching
Imports Leviathan.Visualisation
Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Security
Imports System.Text
Imports IT = Leviathan.Visualisation.InformationType

Namespace Commands

	Public Class NetworkCommands

		#Region " Public Constants "

			''' <summary>
			''' Public Constant Reference to the Name of the Map Method.
			''' </summary>
			''' <remarks></remarks>
			Public Const METHOD_MAP As String = "Map"

		#End Region

		#Region " Private Functions "

			Private Function Map( _
				ByVal targetType As Type _
			) As ObjectMapping

				Dim cache As Simple = Simple.GetInstance(GetType(NetworkCommands).GetHashCode)

				Dim mapping As ObjectMapping = Nothing

				If Not cache.TryGet(mapping, METHOD_MAP.GetHashCode, targetType.GetHashCode) Then

					mapping = New ObjectMapping()

					ConfigurationFactory.GetInstance(Host.StringParser, Me.GetType().Assembly.GetName().Name).Configure(mapping, _
						targetType.FullName.Substring(targetType.Assembly.GetName().Name.Length + 1), "snmp", "Mappings")

					If mapping.InheritsMappings Then

						Dim current_Type As System.Type = targetType.BaseType

						Do Until current_Type Is GetType(Object)

							Dim parent_Mapping As New ObjectMapping

							ConfigurationFactory.GetInstance(Host.StringParser, Me.GetType().Assembly.GetName().Name).Configure(parent_Mapping, _
								current_Type.FullName.Substring(current_Type.Assembly.GetName().Name.Length + 1), "snmp", "Mappings")

							mapping.Integrate(parent_Mapping)

							If Not parent_Mapping.InheritsMappings Then Exit Do

							current_Type = current_Type.BaseType

						Loop

					End If

					cache.Set(mapping.Compile(TypeAnalyser.GetInstance(targetType)), METHOD_MAP.GetHashCode, targetType.GetHashCode)

				End If

				Return mapping

			End Function

			Private Function GetActualVersion( _
				ByVal displayVersion As SNMPDisplayVersion _
			) As SnmpVersion

				Select Case displayVersion

					Case SNMPDisplayVersion.v1

						Return SnmpVersion.SNMP_VERSION_1

					Case SNMPDisplayVersion.v2

						Return SnmpVersion.SNMP_VERSION_2C

					Case SNMPDisplayVersion.v2c

						Return SnmpVersion.SNMP_VERSION_2C

					Case SNMPDisplayVersion.v2p

						Return SnmpVersion.SNMP_VERSION_2P

					Case SNMPDisplayVersion.v3

						Return SnmpVersion.SNMP_VERSION_3

					Case Else

						Return SnmpVersion.SNMP_VERSION_2C

				End Select

			End Function

			Private Function FormatOid( _
				ByVal oidValue As String, _
				ByVal currentTargets As Object, _
				ByVal previousTargets As Object() _
			) As String

				If Not previousTargets Is Nothing AndAlso previousTargets.Length > 0 Then

					For i As Integer = 0 To previousTargets.Length - 1

						Dim parentString As String = Nothing

						For j As Integer = i To previousTargets.Length - 1

							parentString = parentString & ParentVariable

							If j < previousTargets.Length - 1 Then parentString = parentString & FULL_STOP

						Next

						oidValue = TypeAnalyser.Format(oidValue, previousTargets(i), parentString)

					Next

				End If

				Return TypeAnalyser.Format(oidValue, currentTargets)

			End Function

			Private Delegate Sub AsyncPopulateObjectFromSnmp( _
				ByVal connection As SnmpConnection, _
				ByRef target As Object, _
				ByVal mapping As ObjectMapping, _
				ByVal parentObjects As Object(), _
				ByVal populateAsynchronously As Boolean, _
				ByVal updateOnly As Boolean _
			)

			Private Sub PopulateObjectFromSnmp( _
				ByVal connection As SnmpConnection, _
				ByRef target As Object, _
				ByVal mapping As ObjectMapping, _
				ByVal parentObjects As Object(), _
				ByVal populateAsynchronously As Boolean, _
				ByVal updateOnly As Boolean _
			)

				Dim lastObjectIdPrefix As String = Nothing

				Dim request As ISnmpMessage = connection.CreateRequestMessage(mapping.Version, SnmpMessageType.GET_REQUEST)

				Dim requestTypes As New List(Of Type)
				Dim requestMappings As New List(Of Integer)

				Dim results As New Dictionary(Of MemberAnalyser, Object)

				For i As Integer = 0 To mapping.FieldMappings.Length

					Dim actualOidToGet As String = String.Empty

					If i < mapping.FieldMappings.Length Then actualOidToGet = FormatOid(mapping.FieldMappings(i).Value, target, parentObjects)

					Dim isGetNextRequest As Boolean = (i < mapping.FieldMappings.Length AndAlso mapping.FieldMappings(i).Value.EndsWith(NextOidSuffix))

					If i > 0 AndAlso _
						( _
							(i = mapping.FieldMappings.Length AndAlso request.ProtocolDataUnit.VariableBindings.Length > 0) _
								OrElse _
									(request.ProtocolDataUnit.VariableBindings.Length >= MaximumBindingsPerPDU) _
						OrElse _
							(Not String.IsNullOrEmpty(lastObjectIdPrefix) AndAlso Not actualOidToGet.StartsWith(lastObjectIdPrefix) AndAlso _
								request.ProtocolDataUnit.VariableBindings.Length > 0) _
						OrElse _
							isGetNextRequest AndAlso request.ProtocolDataUnit.VariableBindings.Length > 0 _
						OrElse _
							(request.ProtocolDataUnit.VariableBindings.Length = 1 AndAlso _
								request.ProtocolDataUnit.Type = SnmpMessageType.GET_NEXT_REQUEST) _
						) _
					Then

						Dim response As ISnmpMessage = connection.CreateOutputMessage(mapping.Version)

						If connection.SendMessage(request, response, requestTypes.ToArray) AndAlso Not response Is Nothing AndAlso _
							Not response.ProtocolDataUnit Is Nothing AndAlso response.ProtocolDataUnit.Error = SnmpErrorStatus.NO_ERROR Then

							For j As Integer = 0 To response.ProtocolDataUnit.VariableBindings.Length - 1

								Dim current_Mapping As FieldMapping = mapping.FieldMappings(requestMappings(j))

								If Not String.IsNullOrEmpty(current_Mapping.OidToEnum) AndAlso response.ProtocolDataUnit.VariableBindings(j).ObjectType = _
									SnmpDataType.ASN1_OBJECT_IDENTIFIER Then

									results.Add(current_Mapping.Member, CType(response.ProtocolDataUnit.VariableBindings(j).ObjectValue, String) .TrimStart(FULL_STOP). _
										Substring(current_Mapping.OidToEnum.Length))

								Else

									results.Add(current_Mapping.Member, response.ProtocolDataUnit.VariableBindings(j).ObjectValue)

								End If

							Next

						End If

						If i < mapping.FieldMappings.Length Then

							Dim requestType As SnmpMessageType = SnmpMessageType.GET_REQUEST
							If isGetNextRequest Then requestType = SnmpMessageType.GET_NEXT_REQUEST

							request = connection.CreateRequestMessage(mapping.Version, requestType)
							requestTypes.Clear()
							requestMappings.Clear()

						End If

					End If

					If i < mapping.FieldMappings.Length AndAlso (Not updateOnly OrElse mapping.FieldMappings(i).Transient) Then

						Dim mappingType As Type = mapping.FieldMappings(i).Member.ReturnType

						If isGetNextRequest Then actualOidToGet = actualOidToGet.TrimEnd(NextOidSuffix).TrimEnd(FULL_STOP)

						request.ProtocolDataUnit.AddVariableBinding(actualOidToGet)
						requestTypes.Add(mappingType)
						requestMappings.Add(i)

						lastObjectIdPrefix = SnmpConnection.GetObjectIdPrefix(actualOidToGet, 2)

					End If

				Next

				mapping.PopulateObjectFromMap(target, results)

				' --- DO THE TABLE MAPPINGS ---

				' --- Check that there actually are table mappings, and if so, iterate through them ---
				If Not mapping.TableMappings Is Nothing Then

					Dim parentObjectCount As Integer

					If parentObjects Is Nothing Then parentObjectCount = 0 Else parentObjectCount = parentObjects.Length

					Dim l_Parents(parentObjectCount)

					For i As Integer = 0 To parentObjectCount - 1

						l_Parents(i) = parentObjects(i)

					Next

					l_Parents(l_Parents.Length - 1) = target

					For i As Integer = 0 To mapping.TableMappings.Length - 1

						Dim tableMap As TableMapping = mapping.TableMappings(i)

						' --- Get the target member for the object collection! ---
						Dim targetMember As MemberAnalyser = TypeAnalyser.GetInstance(target.GetType).GetMember(tableMap.Name)

						If Not targetMember Is Nothing Then

							Dim targetTypeAnalyser As TypeAnalyser = TypeAnalyser.GetInstance(targetMember.ReturnType)

							' --- Check the Target is actually a collection! ---
							If targetTypeAnalyser.IsIList Then

								' --- Read the Table/Collection! ---
								Dim targetCollection As IList = targetMember.Read(target)

								' --- If the Table/Collection is Nothing then Create it! ---
								If targetCollection Is Nothing then targetCollection = targetTypeAnalyser.Create()

								' --- Get the Element Type of the Table/Collection! ---
								Dim child_Type As Type = targetTypeAnalyser.ElementType

								If targetCollection.Count = 0 Then

									' --- Iterate through the Index Values! ---
									For j As Integer = 0 To tableMap.FieldMappings.Length - 1

										Dim fieldMap As FieldMapping = tableMap.FieldMappings(j)

										Dim oidValue As String
										Dim isIndexValue As Boolean

										If fieldMap.Value.EndsWith(IndexParsedOidSuffix) Then

											oidValue = fieldMap.Value.TrimEnd(IndexParsedOidSuffix).TrimEnd(FULL_STOP)
											isIndexValue = True

										Else

											oidValue = fieldMap.Value

										End If

										oidValue = FormatOid(oidValue, target, parentObjects)

										Dim childValues As DictionaryEntry() = connection.GetTreeResponse(mapping.Version, oidValue, Nothing, tableMap.MaxTableEntries)

										For k As Integer = 0 To childValues.Length - 1

											Dim child_Target As Object = TypeAnalyser.Create(child_Type)

											If isIndexValue Then

												If fieldMap.Member.ReturnType.IsPrimitive Then

													childValues(k).Value = childValues(k).Key.Substring(oidValue.Length).TrimStart(FULL_STOP)

												Else

													Dim data As Byte() = SnmpConnection.OidToBytes(childValues(k).Key.Substring(oidValue.Length).TrimStart(FULL_STOP))
													childValues(k).Value = BerDecoder.DecodeBerOctetString(data.Length, data, 0, fieldMap.Member.ReturnType)

												End If

											End If

											tableMap.PopulateObjectFromMap(child_Target, fieldMap.Member, childValues(k).Value)

											TypeAnalyser.AddElement(targetCollection, child_Target)

										Next

									Next

								End If

								Dim child_Current As Integer
								Dim child_Map As ObjectMapping = Map(child_Type)

								If populateAsynchronously Then

									SyncLock ASyncPopulations

										child_Current = ASyncPopulations.Count
										ASyncPopulations.Add(targetCollection.Count)

									End SyncLock

								End If

								For j As Integer = 0 To targetCollection.Count - 1

									If populateAsynchronously Then

										Dim populate As New AsyncPopulateObjectFromSnmp(AddressOf PopulateObjectFromSnmp)

										Dim child_Connection As New SnmpConnection(connection.Target, connection.Community, connection.ReceiveTimeout, _
											connection.SendTimeout, connection.TimeoutRetries)

										populate.BeginInvoke(child_Connection, targetCollection(j), child_Map, l_Parents, populateAsynchronously, updateOnly, _
											AddressOf ASyncPopulateObjectFromSnmpCompleted, child_Current)

									Else

										PopulateObjectFromSnmp(connection, targetCollection(j), child_Map, l_Parents, populateAsynchronously, updateOnly)

									End If

								Next

								If populateAsynchronously Then ' -- Block while all threads Complete --

									While ASyncPopulations(child_Current) > 0

										Threading.Thread.Sleep(20)

									End While

								End If

								targetMember.Write(target, targetCollection)

							End If

						End If

					Next

				End If

			End Sub

			Private Sub ASyncPopulateObjectFromSnmpCompleted( _
				ByVal ar As IAsyncResult _
			)

				SyncLock ASyncPopulations

					ASyncPopulations(ar.AsyncState) -= 1

				End SyncLock

			End Sub

		#End Region

		#Region " General Command Processing Methods "

			<Command( _
				ResourceContainingType:=GetType(NetworkCommands), _
				ResourceName:="CommandDetails", _
				Name:="ping", _
				Description:="@commandNetworkDescriptionPing@" _
			)> _
			Public Function ProcessCommandPing( _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionStartAddress@" _
				)> _
				ByVal startAddress As String, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionHostCount@" _
				)> _
				ByVal numberOfHosts As Integer _
			) As IFixedWidthWriteable

				Dim lastHost As Integer = Integer.Parse(startAddress.Substring(startAddress.LastIndexOf(FULL_STOP) + 1))

				Dim netAddress As String = startAddress.Substring(0, startAddress.LastIndexOf(FULL_STOP))

				Dim rows As New List(Of Row)

				For i As Integer = lastHost To lastHost + numberOfHosts

					rows.Add(New Row().Add(netAddress & FULL_STOP & i.ToString).Add(DeviceName.IsAlive(netAddress & FULL_STOP & i.ToString)))

				Next

				Return Cube.Create(IT.Information, "Ping Results", "Address", "Alive").Add(New Slice(rows))

			End Function

			<Command( _
				ResourceContainingType:=GetType(NetworkCommands), _
				ResourceName:="CommandDetails", _
				Name:="wake", _
				Description:="@commandNetworkDescriptionWake@" _
			)> _
			Public Function ProcessCommandWake( _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionMacAddress@" _
				)> _
				ByVal macAddress As PhysicalAddress, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionBroadcastAddress@" _
				)> _
				ByVal broadcastAddress As IPAddress _
			) As Boolean

				Return Computer.WakeOverLan(macAddress, broadcastAddress, 65535)

			End Function

			<Command( _
				ResourceContainingType:=GetType(NetworkCommands), _
				ResourceName:="CommandDetails", _
				Name:="wake", _
				Description:="@commandNetworkDescriptionWake@" _
			)> _
			Public Function ProcessCommandWake( _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionMacAddress@" _
				)> _
				ByVal macAddress As PhysicalAddress, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionBroadcastAddress@" _
				)> _
				ByVal broadcastAddress As IPAddress, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionPortNumber@" _
				)> _
				ByVal portNumber As Integer _
			) As Boolean

				Return Computer.WakeOverLan(macAddress, broadcastAddress, portNumber)

			End Function

		#End Region

		#Region " SNMP Command Processing Methods "

			<Command( _
				ResourceContainingType:=GetType(NetworkCommands), _
				ResourceName:="CommandDetails", _
				Name:="get-snmp", _
				Description:="@commandNetworkDescriptionGetSnmp@" _
			)> _
			Public Function ProcessCommandSnmpGet( _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionFqdn@" _
				)> _
				ByVal fqdn As String, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpCommunity@" _
				)> _
				ByVal community As String, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpVersion@" _
				)> _
				ByVal version As SNMPDisplayVersion, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpOid@" _
				)> _
				ByVal ParamArray oids As String(), _
			) As IFixedWidthWriteable

				Dim rows As New List(Of Row)

				If Not oids Is Nothing Then

					Dim l_Name As DeviceName = Nothing

					If DeviceName.TryParse(fqdn, l_Name) AndAlso (IgnoreIcmpConnectivity OrElse DeviceName.IsAlive(l_Name.IpAddresses)) Then

						Dim connection As New SnmpConnection(l_Name.IpAddresses, community, SnmpReceiveTimeout, SnmpSendTimeout, SnmpTimeoutRetries)

						For i As Integer = 0 To oids.Length - 1

							Dim result As DictionaryEntry = connection.GetResponse(GetActualVersion(version), SnmpMessageType.GET_REQUEST, oids(i))
							rows.Add(New Row().Add(result.Key).Add(result.Value))

						Next

					End If

				End If

				Return Cube.Create(IT.Information, "SNMP Results", "Oid", "Value").Add(New Slice(rows))

			End Function

			<Command( _
				ResourceContainingType:=GetType(NetworkCommands), _
				ResourceName:="CommandDetails", _
				Name:="set-snmp", _
				Description:="@commandNetworkDescriptionSetSnmp@" _
			)> _
		 Public Function ProcessCommandSnmpSet( _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionFqdn@" _
				)> _
				ByVal fqdn As String, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpCommunity@" _
				)> _
				ByVal community As String, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpVersion@" _
				)> _
				ByVal version As SNMPDisplayVersion, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpOid@" _
				)> _
				ByVal oid As String, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpValue@" _
				)> _
				ByVal value As String _
			) As Boolean

				Dim actualVersion As SnmpVersion = GetActualVersion(version)

				Dim l_Name As DeviceName = Nothing

				If DeviceName.TryParse(fqdn, l_Name) AndAlso (IgnoreIcmpConnectivity OrElse DeviceName.IsAlive(l_Name.IpAddresses)) Then

					Dim connection As New SnmpConnection(l_Name.IpAddresses, community, SnmpReceiveTimeout, SnmpSendTimeout, SnmpTimeoutRetries)

					Dim parser As New FromString()

					Dim responseMessage As ISnmpMessage = connection.CreateOutputMessage(GetActualVersion(version))

					If connection.SendMessage(connection.CreateRequestMessage(actualVersion, SnmpMessageType.GET_REQUEST, oid), responseMessage) Then

						If responseMessage.ProtocolDataUnit.Error = SnmpErrorStatus.NO_ERROR Then

							For i As Integer = 0 To responseMessage.ProtocolDataUnit.VariableBindings.Length - 1

								Dim snmpType As SnmpDataType = responseMessage.ProtocolDataUnit.VariableBindings(i).ObjectType

								Dim objActualType As Type = SnmpConnection.GetObjectType(snmpType)

								If Not objActualType Is Nothing Then

									Dim parsed As Boolean

									Dim objParsed As Object = parser.Parse(value, parsed, objActualType)

									If parsed Then

										Dim setMessage As ISnmpMessage = connection.CreateOutputMessage(GetActualVersion(version))

										If connection.SendMessage(connection.CreateRequestMessage(actualVersion, SnmpMessageType.SET_REQUEST, oid, snmpType, _
											objParsed), setMessage) Then Return True

									End If

								End If

							Next

						End If

					End If

				End If

				Return False

			End Function

			<Command( _
				ResourceContainingType:=GetType(NetworkCommands), _
				ResourceName:="CommandDetails", _
				Name:="get-snmp-next", _
				Description:="@commandNetworkDescriptionSnmpGetNext@" _
			)> _
			Public Function ProcessCommandGetSnmpNext( _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionFqdn@" _
				)> _
				ByVal fqdn As String, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpCommunity@" _
				)> _
				ByVal community As String, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpVersion@" _
				)> _
				ByVal version As SNMPDisplayVersion, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpOid@" _
				)> _
				ByVal oid As String _
			) As IFixedWidthWriteable

				Dim rows As New List(Of Row)

				Dim l_Name As DeviceName = Nothing

				If DeviceName.TryParse(fqdn, l_Name) AndAlso (IgnoreIcmpConnectivity OrElse DeviceName.IsAlive(l_Name.IpAddresses)) Then

					Dim connection As New SnmpConnection(l_Name.IpAddresses, community, SnmpReceiveTimeout, SnmpSendTimeout, SnmpTimeoutRetries)

					Dim result As DictionaryEntry = connection.GetResponse(GetActualVersion(version), SnmpMessageType.GET_NEXT_REQUEST, oid)
					rows.Add(New Row().Add(result.Key).Add(result.Value))

				End If

				Return Cube.Create(IT.Information, "SNMP Result", "Oid", "Value").Add(New Slice(rows))

			End Function

			<Command( _
				ResourceContainingType:=GetType(NetworkCommands), _
				ResourceName:="CommandDetails", _
				Name:="get-snmp-tree", _
				Description:="@commandNetworkDescriptionGetSnmpTree@" _
			)> _
			Public Function ProcessCommandSnmpGetTree( _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionFqdn@" _
				)> _
				ByVal fqdn As String, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpCommunity@" _
				)> _
				ByVal community As String, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpVersion@" _
				)> _
				ByVal version As SNMPDisplayVersion, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpOid@" _
				)> _
				ByVal oid As String _
			) As IFixedWidthWriteable

				Dim rows As New List(Of Row)

				Dim l_Name As DeviceName = Nothing

				If DeviceName.TryParse(fqdn, l_Name) AndAlso (IgnoreIcmpConnectivity OrElse DeviceName.IsAlive(l_Name.IpAddresses)) Then

					Dim connection As New SnmpConnection(l_Name.IpAddresses, community, SnmpReceiveTimeout, SnmpSendTimeout, SnmpTimeoutRetries)

					Dim results As DictionaryEntry() = connection.GetTreeResponse(GetActualVersion(version), oid, Nothing)

					For each result As DictionaryEntry in results

						rows.Add(New Row().Add(result.Key).Add(result.Value))

					Next

				End If

				Return Cube.Create(IT.Information, "SNMP Results", "Oid", "Value").Add(New Slice(rows))

			End Function

			Private Delegate Function AsyncProcessCommandSnmpCreate( _
				ByVal deviceType As Type, _
				ByVal fqdn As DeviceName, _
				ByVal community As String _
			) As Object

			<Command( _
				ResourceContainingType:=GetType(NetworkCommands), _
				ResourceName:="CommandDetails", _
				Name:="create-snmp", _
				Description:="@commandNetworkDescriptionPopulateSnmp@" _
			)> _
			Public Function ProcessCommandSnmpCreate( _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionDeviceType@" _
				)> _
				ByVal deviceType As Type, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionFqdn@" _
				)> _
				ByVal fqdn As DeviceName, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpCommunity@" _
				)> _
				ByVal community As String _
			) As Object

				Dim value As ISnmpManageable = TypeAnalyser.Create(deviceType, New DictionaryEntry(UNDER_SCORE & NetworkDevice.PROPERTY_NAME, fqdn), _
					New DictionaryEntry(UNDER_SCORE & NetworkDevice.PROPERTY_SNMPCOMMUNITY, community))

				Dim slowConnection As Boolean

				If (IgnoreIcmpConnectivity OrElse DeviceName.IsAlive(value.Target, slowConnection)) Then

					Dim useAsync As Boolean = slowConnection
					If UseSyncPopulation Then useAsync = False

					PopulateObjectFromSnmp(New SnmpConnection(value.Target, value.Community, SnmpReceiveTimeout, SnmpSendTimeout, SnmpTimeoutRetries), _
						value, Map(deviceType), New Object() {}, useAsync, Nothing)

				End If

				Return value

			End Function

			<Command( _
				ResourceContainingType:=GetType(NetworkCommands), _
				ResourceName:="CommandDetails", _
				Name:="populate-snmp", _
				Description:="@commandNetworkDescriptionPopulateSnmp@" _
			)> _
			Public Function ProcessCommandSnmpPopulate( _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionDevices@" _
				)> _
				ByVal value As ISnmpManageable _
			) As Object

				Dim slowConnection As Boolean

				If (IgnoreIcmpConnectivity OrElse DeviceName.IsAlive(value.Target, slowConnection)) Then

					Dim useAsync As Boolean = slowConnection
					If UseSyncPopulation Then useAsync = False

					PopulateObjectFromSnmp(New SnmpConnection(value.Target, value.Community, SnmpReceiveTimeout, SnmpSendTimeout, SnmpTimeoutRetries), _
						value, Map(value.GetType), New Object() {}, useAsync, True)

				End If

				Return value

			End Function

		#End Region

		#Region " Monitor Command Processing Methods "

			<Command( _
				ResourceContainingType:=GetType(NetworkCommands), _
				ResourceName:="CommandDetails", _
				Name:="monitor", _
				Description:="@commandNetworkDescriptionMonitor@" _
			)> _
			Public Function ProcessCommandMonitor( _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionGroupName@" _
				)> _
				ByVal groupName As String, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionDeviceType@" _
				)> _
				ByVal deviceType As Type, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionOutputUnhealthyDevicesOnly@" _
				)> _
				ByVal outputUnhealthyOnly As Boolean, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpCommunity@" _
				)> _
				ByVal community As String, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionFqdns@" _
				)> _
				ByVal ParamArray fqdns As DeviceName() _
			) As ISnmpManageable()

				If Monitored_Devices Is Nothing OrElse Monitored_Devices.Count > 0 Then _
					Monitored_Devices = New List(Of ISnmpManageable)

				If TypeAnalyser.GetInstance(deviceType).ImplementsInterface(GetType(IMonitorable)) Then

					If UseSyncPopulation Then

						For i As Integer = 0 To fqdns.Length - 1

							Host.Progress((i + 1) / fqdns.Length, String.Format("{0}: Monitoring Devices", groupName))

							Dim monitored_Device As IMonitorable = ProcessCommandSnmpCreate(deviceType, fqdns(i), community)
							If Not outputUnhealthyOnly Or monitored_Device.IsHealthy.Status <> HealthStatus.Healthy Then _
								Monitored_Devices.Add(monitored_Device)

						Next

					Else

						ASyncCount = fqdns.Length

						For i As Integer = 0 To fqdns.Length - 1

							Dim create As New AsyncProcessCommandSnmpCreate(AddressOf ProcessCommandSnmpCreate)

							create.BeginInvoke(deviceType, fqdns(i), community, AddressOf ASyncProcessCommandSnmpCreateCompleted, outputUnhealthyOnly)

						Next

						While ASyncCount > 0

							Threading.Thread.Sleep(20)

						End While

					End If

					For i As Integer = 0 To Monitored_Devices.Count - 1

						Host.Progress((i + 1) / Monitored_Devices.Count, String.Format("{0}: Re-Checking Suspect Devices", groupName))

						If CType(Monitored_Devices(i), IMonitorable).IsHealthy.Status <> HealthStatus.Healthy Then _
							ProcessCommandSnmpPopulate(monitored_Devices(i))

					Next

					If outputUnhealthyOnly Then

						Dim l_Monitored_Devices As New List(Of ISnmpManageable)

						For i As Integer = 0 To Monitored_Devices.Count - 1

							If CType(Monitored_Devices(i), IMonitorable).IsHealthy.Status <> HealthStatus.Healthy Then _
								l_Monitored_Devices.Add(monitored_Devices(i))

						Next

						monitored_Devices = l_Monitored_Devices

					End If

				End If

				Return monitored_Devices.ToArray()

			End Function

			Private Sub ASyncProcessCommandSnmpCreateCompleted( _
				ByVal ar As IAsyncResult _
			)

				Dim create As AsyncProcessCommandSnmpCreate = CType(ar, System.Runtime.Remoting.Messaging.ASyncResult).AsyncDelegate
				Dim monitored_Device As IMonitorable = create.EndInvoke(ar)

				If Not ar.AsyncState Or monitored_Device.IsHealthy.Status <> HealthStatus.Healthy Then _
					Monitored_Devices.Add(monitored_Device)

				ASyncCount -= 1

			End Sub

		#End Region

		#Region " Usage Commands "

			<Command( _
				ResourceContainingType:=GetType(NetworkCommands), _
				ResourceName:="CommandDetails", _
				Name:="cisco-ap-usage", _
				Description:="@commandNetworkDescriptionApUsage@" _
			)> _
			Public Function ProcessCommandCiscoAPUsage( _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionSnmpCommunity@" _
				)> _
				ByVal community As String, _
				<Configurable( _
					ResourceContainingType:=GetType(NetworkCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandNetworkParameterDescriptionFqdns@" _
				)> _
				ByVal ParamArray fqdns As DeviceName() _
			) As IFixedWidthWriteable()

				Dim total_Devices As Integer = fqdns.Length
				Dim found_Devices As Integer = 0

				Dim deviceType As System.Type = System.Type.GetType("Caerus.Cisco.AccessPoint")

				If Monitored_Devices Is Nothing OrElse Monitored_Devices.Count > 0 Then _
					Monitored_Devices = New List(Of ISnmpManageable)

				If UseSyncPopulation Then

					For i As Integer = 0 To fqdns.Length - 1

						Host.Progress((i + 1) / fqdns.Length, "Monitoring Access Points")

						Monitored_Devices.Add(ProcessCommandSnmpCreate(deviceType, fqdns(i), community))

					Next

				Else

					ASyncCount = fqdns.Length

					For i As Integer = 0 To fqdns.Length - 1

						Dim create As New AsyncProcessCommandSnmpCreate(AddressOf ProcessCommandSnmpCreate)

						create.BeginInvoke(deviceType, fqdns(i), community, AddressOf ASyncProcessCommandSnmpCreateCompleted, False)

					Next

					While ASyncCount > 0

						Threading.Thread.Sleep(20)

					End While

				End If

				Monitored_Devices.Sort()

				Dim usage_Rows As New List(Of Row)
				Dim unhealthy_Rows As New List(Of Row)

				Dim total_A_Assoc As Integer = 0
				Dim total_B_Assoc As Integer = 0

				Dim spread_A_Channels As New SortedDictionary(Of Integer, Integer)
				Dim spread_B_Channels As New SortedDictionary(Of Integer, Integer)

				For i As Integer = 0 To Monitored_Devices.Count - 1

					Dim ap As Caerus.Cisco.AccessPoint = CType(Monitored_Devices(i), Caerus.Cisco.AccessPoint)

					Dim interfaces As Caerus.Cisco.AccessPointInterfaceCollection = ap.WirelessInterfaces()

					Dim a_ch As String = ""
					Dim a_pwr As String = ""
					Dim a_assoc As Integer = 0
					Dim a_assoc_Style As Leviathan.Visualisation.InformationType = IT.Question
					Dim b_ch As String = ""
					Dim b_pwr As String = ""
					Dim b_assoc As Integer = 0
					Dim b_assoc_Style As Leviathan.Visualisation.InformationType = IT.Question

					Dim total_Assoc As Integer = 0
					Dim assoc_Style As Leviathan.Visualisation.InformationType = IT.Question

					For j As Integer = 0 To interfaces.Count - 1

						If interfaces(j).Name.ShortName = "do0" Then

							b_ch = interfaces(j).Channel.ToString()
							b_pwr = interfaces(j).DisplayPower_Summary
							b_assoc = interfaces(j).TotalAssociations
							total_B_Assoc += b_assoc
							total_Assoc += b_assoc
							If b_assoc = 0 Then
								b_assoc_Style = IT.[Error]
							ElseIf b_assoc >= 10 Then
								b_assoc_Style = IT.[Success]
							ElseIf b_assoc >= 5 Then
								b_assoc_Style = IT.[Warning]
							End If

							If Not spread_B_Channels.ContainsKey(interfaces(j).Channel) Then spread_B_Channels.Add(interfaces(j).Channel, 0)
							spread_B_Channels(interfaces(j).Channel) += 1

						ElseIf interfaces(j).Name.ShortName = "do1" Then

							a_ch = interfaces(j).Channel.ToString()
							a_pwr = interfaces(j).DisplayPower_Summary
							a_assoc = interfaces(j).TotalAssociations
							total_A_Assoc += a_assoc
							total_Assoc += a_assoc
							If a_assoc = 0 Then
								a_assoc_Style = IT.[Error]
							ElseIf a_assoc >= 10 Then
								a_assoc_Style = IT.[Success]
							ElseIf a_assoc >= 5 Then
								a_assoc_Style = IT.[Warning]
							End If

							If Not spread_A_Channels.ContainsKey(interfaces(j).Channel) Then spread_A_Channels.Add(interfaces(j).Channel, 0)
							spread_A_Channels(interfaces(j).Channel) += 1

						End If

					Next

					If total_Assoc = 0 Then
						assoc_Style = IT.[Error]
					ElseIf total_Assoc >= 20 Then
						assoc_Style = IT.[Success]
					ElseIf total_Assoc >= 10 Then
						assoc_Style = IT.[Warning]
					End If

					If Not ap.Name Is Nothing AndAlso Not ap.Location Is Nothing Then
						usage_Rows.Add(New Row().Add(New Cell(ap.Name.ShortName, 0, assoc_Style)).Add(ap.Location.Block).Add(ap.Location.Room).Add(ap.Model) _
							.Add(a_ch).Add(a_pwr).Add(New Cell(a_assoc, 0, a_assoc_Style)).Add(b_ch).Add(b_pwr).Add(New Cell(b_assoc, 0, b_assoc_Style)).Add(New Cell(total_Assoc, 0, assoc_Style)))
						found_Devices += 1
					End If


					If CType(ap, IMonitorable).IsHealthy.Status = HealthStatus.Down Then
						unhealthy_Rows.Add(New Row().Add(ap.Name.ShortName).Add(ap.Description).Add(New Cell(CType(ap, IMonitorable).IsHealthy.Details, 0, IT.[Error])))
					ElseIf CType(ap, IMonitorable).IsHealthy.Status = HealthStatus.Degraded Then
						unhealthy_Rows.Add(New Row().Add(ap.Name.ShortName).Add(ap.Description).Add(New Cell(CType(ap, IMonitorable).IsHealthy.Details, 0, IT.[Warning])))
					End If

				Next

				Dim summary_Rows As New List(Of Row)

				summary_Rows.Add(New Row().Add("Total Requested").Add(total_Devices))
				summary_Rows.Add(New Row().Add("Total Available").Add(found_Devices))
				If found_Devices < total_Devices Then summary_Rows.Add(New Row().Add("Missing").Add(New Cell(total_Devices - found_Devices, 0, IT.[Error])))
				summary_Rows.Add(New Row().Add().Add())

				summary_Rows.Add(New Row().Add("Total A Assoc").Add(total_A_Assoc))
				summary_Rows.Add(New Row().Add("Total B Assoc").Add(total_B_Assoc))
				summary_Rows.Add(New Row().Add("Total Assoc").Add(total_A_Assoc + total_B_Assoc))
				summary_Rows.Add(New Row().Add().Add())

				For Each a_Channel As Integer In spread_A_Channels.Keys
					summary_Rows.Add(New Row().Add("APs on A/Ch: " & a_Channel).Add(spread_A_Channels(a_Channel)))
				Next

				summary_Rows.Add(New Row().Add().Add())

				For Each b_Channel As Integer In spread_B_Channels.Keys
					summary_Rows.Add(New Row().Add("APs on B/Ch: " & b_Channel).Add(spread_B_Channels(b_Channel)))
				Next

				If unhealthy_Rows.Count > 0 Then

					Return New IFixedWidthWriteable() { _
						Cube.Create(IT.Information, "Access Point Problems", "Name", "Version", "Status").Add(New Slice(unhealthy_Rows)), _
						Cube.Create(IT.Information, "Access Point Usage", "Name", "Block", "Room", "Model", "A/Ch", "A/Pwr", "A/Assoc", "B/Ch", "B/Pwr", "B/Assoc", "Total/Assoc").Add(New Slice(usage_Rows)), _
						Cube.Create(IT.Information, "Access Point Summary", "Name", "Value").Add(New Slice(summary_Rows)) _
					}

				Else

					Return New IFixedWidthWriteable() { _
						Cube.Create(IT.Information, "Access Point Usage", "Name", "Block", "Room", "Model", "A/Ch", "A/Pwr", "A/Assoc", "B/Ch", "B/Pwr", "B/Assoc", "Total/Assoc").Add(New Slice(usage_Rows)), _
						Cube.Create(IT.Information, "Access Point Summary", "Name", "Value").Add(New Slice(summary_Rows)) _
					}
				
				End If

			End Function

		#End Region

	End Class

End Namespace