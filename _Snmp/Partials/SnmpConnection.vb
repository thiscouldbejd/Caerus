Imports System.Net.Sockets.AddressFamily
Imports System.Net.Sockets.SocketType
Imports N = System.Net.Sockets.SocketOptionName
Imports P = System.Net.Sockets.ProtocolType
Imports S = System.Net.Sockets.SocketOptionLevel

Namespace Snmp

	Partial Public Class SnmpConnection

		#Region " Private Constants "

			Private Const TIMEOUT_RECOVERY_SLEEP As Integer = 100

		#End Region

		#Region " Public Events "

			Public Event ResponseReceived( _
				ByVal outputMessage As IPacketDecoder _
			)

		#End Region

		#Region " Private Methods "

			Private Sub CreateSocket()

				If Not Target Is Nothing Then

					For i As Integer = 0 To Target.Length - 1

						CreateSocket(Target(i))

						If m_TargetSocket.Connected Then

							If Target.Length > 1 Then ' Redundant Gateways issue

								Dim response As ISnmpMessage = CreateOutputMessage(SnmpVersion.SNMP_VERSION_1)

								If SendMessage(CreateRequestMessage(SnmpVersion.SNMP_VERSION_1, SnmpMessageType.GET_NEXT_REQUEST, ".1.3"), _
									CreateOutputMessage(SnmpVersion.SNMP_VERSION_1), Nothing) Then

									Exit For

								Else

									' -- Target didn't respond, so try the next address --
									m_TargetSocket = Nothing
									m_TargetEndPoint = Nothing

								End If

							Else

								Exit For

							End If

						Else

							m_TargetSocket = Nothing
							m_TargetEndPoint = Nothing

						End If

					Next

				End If

			End Sub

			Private Sub CreateSocket( _
				ByVal address As IPAddress _
			)

				m_TargetEndPoint = New IPEndPoint(address, Port)

				m_TargetSocket = New Socket(InterNetwork, Dgram, Type)

				m_TargetSocket.SetSocketOption(S.Socket, N.SendTimeout, SendTimeout)
				m_TargetSocket.SetSocketOption(S.Socket, N.ReceiveTimeout, ReceiveTimeout)

				m_TargetSocket.Connect(m_TargetEndPoint)

			End Sub

			Private Function SynchronousSend( _
				ByVal packet As Byte(), _
				ByVal retryAttemptsOnTimeout As Integer _
			) As Byte()

				Try

					If (Not packet Is Nothing) Then

						If (Not TargetSocket Is Nothing) Then

							Dim sendPacketLength As Integer = TargetSocket.Send(packet)

							If sendPacketLength = packet.Length Then

								Dim bytesToReturn As Byte() = Nothing
								Dim bytesToReturnCurrentEnd As Integer = 0
								Dim byteLengthReceived As Integer
								Dim bytesReceived(8192) As Byte
								Dim receiveComplete As Boolean = False

								Do

									TargetSocket.Blocking = True
									byteLengthReceived = TargetSocket.Receive(bytesReceived)

									If byteLengthReceived > 0 Then

										If bytesToReturn Is Nothing Then
											bytesToReturn = Array.CreateInstance(GetType(Byte), byteLengthReceived)
										Else
											bytesToReturnCurrentEnd = bytesToReturn.Length
											Array.Resize(bytesToReturn, bytesToReturnCurrentEnd + byteLengthReceived)
										End If

										If bytesReceived.Length > byteLengthReceived Then
											Array.Resize(bytesReceived, byteLengthReceived)
											receiveComplete = True
										End If

										bytesReceived.CopyTo(bytesToReturn, bytesToReturnCurrentEnd)

									Else

										receiveComplete = True

									End If

								Loop Until receiveComplete

								Return bytesToReturn

							End If

						Else

							Throw New Exception( _
								String.Format(SingleResource( _
									Me.GetType, RESOURCEMANAGER_NAME_EXCEPTION, "socketConnectionError")))

						End If

					End If

					retryAttemptsOnTimeout = 0

				Catch ex As SocketException

					If Not ex.SocketErrorCode = SocketError.TimedOut Then retryAttemptsOnTimeout = 0
					Threading.Thread.Sleep(TIMEOUT_RECOVERY_SLEEP)

				End Try

				If retryAttemptsOnTimeout > 0 Then

					' Try to Recover Socket if it's Blocking.
					If TargetSocket.Blocking Then

						TargetSocket.Close()
						CreateSocket(CType(TargetSocket.RemoteEndpoint, IPEndPoint).Address)

					End If

					Return SynchronousSend(packet, retryAttemptsOnTimeout - 1)

				Else

					Return Nothing

				End If

			End Function

		#End Region

		#Region " Public Methods "

			Public Function CreateOutputMessage( _
				ByVal messageVersion As SnmpVersion _
			) As ISnmpMessage

				Select Case messageVersion

					Case SnmpVersion.SNMP_VERSION_1

						Return New SnmpV1Message()

					Case SnmpVersion.SNMP_VERSION_2C

						Return New SnmpV2cMessage()

					Case SnmpVersion.SNMP_VERSION_2P

						Throw New NotImplementedException()

					Case SnmpVersion.SNMP_VERSION_3

						Throw New NotImplementedException()

				End Select

				Return Nothing

			End Function

			Public Function SynchronousSend( _
				ByVal packet As Byte() _
			) As Byte()

				Return SynchronousSend(packet, TimeoutRetries)

			End Function

			Public Function CreateRequestMessage( _
				ByVal messageVersion As SnmpVersion, _
				ByVal requestType As SnmpMessageType _
			) As ISnmpMessage

				LastRequestId += 1

				Select Case messageVersion

					Case SnmpVersion.SNMP_VERSION_1

						Return SnmpV1Message.CreateRequest(requestType, Community, LastRequestId)

					Case SnmpVersion.SNMP_VERSION_2C

						Return SnmpV2cMessage.CreateRequest(requestType, Community, LastRequestId)

					Case SnmpVersion.SNMP_VERSION_2P

						Throw New NotImplementedException()

					Case SnmpVersion.SNMP_VERSION_3

						Throw New NotImplementedException()

				End Select

				Return Nothing

			End Function

			Public Function CreateRequestMessage( _
				ByVal messageVersion As SnmpVersion, _
				ByVal requestType As SnmpMessageType, _
				ByVal objectId As String _
			) As ISnmpMessage

				LastRequestId += 1

				Select Case messageVersion

					Case SnmpVersion.SNMP_VERSION_1

						Return SnmpV1Message.CreateRequest(requestType, Community, LastRequestId, objectId)

					Case SnmpVersion.SNMP_VERSION_2C

						Return SnmpV2cMessage.CreateRequest(requestType, Community, LastRequestId, objectId)

					Case SnmpVersion.SNMP_VERSION_2P

						Throw New NotImplementedException()

					Case SnmpVersion.SNMP_VERSION_3

						Throw New NotImplementedException()

				End Select

				Return Nothing

			End Function

			Public Function CreateRequestMessage( _
				ByVal messageVersion As SnmpVersion, _
				ByVal requestType As SnmpMessageType, _
				ByVal objectId As String, _
				ByVal objectType As SnmpDataType, _
				ByVal objectValue As Object _
			) As ISnmpMessage

				LastRequestId += 1

				Select Case messageVersion

					Case SnmpVersion.SNMP_VERSION_1

						Return SnmpV1Message.CreateRequest(requestType, Community, LastRequestId, _
							objectId, objectType, objectValue)

					Case SnmpVersion.SNMP_VERSION_2C

						Return SnmpV2cMessage.CreateRequest(requestType, Community, LastRequestId, _
							objectId, objectType, objectValue)

					Case SnmpVersion.SNMP_VERSION_2P

						Throw New NotImplementedException()

					Case SnmpVersion.SNMP_VERSION_3

						Throw New NotImplementedException()

				End Select

				Return Nothing

			End Function

			Public Function SendMessage( _
				ByVal inputMessage As IPacketEncoder, _
				ByRef outputMessage As IPacketDecoder, _
				ParamArray ByVal types As Type() _
			) As Boolean

				Dim success As Boolean

				Try
					Dim packet As Byte() = SynchronousSend(inputMessage.EncodePacket)

					If Not packet Is Nothing Then
						outputMessage.DecodePacket(packet, 0, types)
						success = True
					Else
						success = False
					End If

				Catch ex As Exception
					success = False
				End Try

				Return success

			End Function

			''' <summary>
			''' Public Function to Get an SNMP Response.
			''' </summary>
			''' <param name="type">The Type of Request to Send.</param>
			''' <param name="oid">The Oid Required.</param>
			''' <returns>A Pair comprising the returned Oid and value, or Nothing.</returns>
			''' <remarks></remarks>
			Public Function GetResponse( _
				ByVal messageVersion As SnmpVersion, _
				ByVal type As SnmpMessageType, _
				ByVal oid As String, _
				Optional ByVal fieldType As System.Type = Nothing _
			) As DictionaryEntry

				Dim response As ISnmpMessage = CreateOutputMessage(messageVersion)

				Dim aryResults As New ArrayList

				If SendMessage(CreateRequestMessage(messageVersion, type, oid), response, fieldType) Then

					If response.ProtocolDataUnit.Error = SnmpErrorStatus.NO_ERROR Then

						For i As Integer = 0 To response.ProtocolDataUnit.VariableBindings.Length - 1

							Return New DictionaryEntry( _
								response.ProtocolDataUnit.VariableBindings(i).ObjectId, _
								response.ProtocolDataUnit.VariableBindings(i).ObjectValue)

						Next

					End If

				End If

				Return Nothing

			End Function

			''' <summary>
			''' Public Function to Get an SNMP Response.
			''' </summary>
			''' <param name="oid">The Oid Required.</param>
			''' <returns>An Array of Pairs comprising the returned Oid and value.</returns>
			''' <remarks></remarks>
			Public Function GetTreeResponse( _
				ByVal messageVersion As SnmpVersion, _
				ByVal oid As String, _
				ByVal fieldType As System.Type, _
				Optional ByVal maximumResponses As Integer = 0 _
			) As DictionaryEntry()

				Dim currentOid As String = oid

				Dim lstResults As New List(Of DictionaryEntry)

				Dim runningCount As Integer = 0

				Do While True

					runningCount += 1

					Dim result As DictionaryEntry = _
						GetResponse(messageVersion, SnmpMessageType.GET_NEXT_REQUEST, currentOid, fieldType)

					If result.Key = Nothing OrElse _
						(maximumResponses > 0 AndAlso runningCount > maximumResponses) OrElse _
						Not result.Key.TrimStart(FULL_STOP).StartsWith(oid.TrimStart(FULL_STOP) & FULL_STOP) Then

						Exit Do

					Else

						lstResults.Add(result)

						currentOid = result.Key

					End If

				Loop

				Return lstResults.ToArray()

			End Function

			''' <summary>
			''' Public Function to Set an SNMP Value.
			''' </summary>
			''' <param name="messageVersion"></param>
			''' <param name="oid">The Oid Required.</param>
			''' <param name="valueType">The Type of Value to Set.</param>
			''' <param name="value">The Value to Set.</param>
			''' <returns>A Boolean Value indicating Success.</returns>
			''' <remarks></remarks>
			Public Function SetValue( _
				ByVal messageVersion As SnmpVersion, _
				ByVal oid As String, _
				ByVal valueType As SnmpDataType, _
				ByVal value As Object _
			) As Boolean

				Dim response As ISnmpMessage = CreateOutputMessage(messageVersion)

				Dim aryResults As New ArrayList

				If SendMessage(CreateRequestMessage(messageVersion, SnmpMessageType.SET_REQUEST, _
					oid, valueType, value), response) Then

					If response.ProtocolDataUnit.Error = SnmpErrorStatus.NO_ERROR Then _
						Return True

				End If

				Return False

			End Function

			Public Sub AddFalseOctetString( _
				ByVal oid As String, _
				Optional ByVal isNextRequest As Boolean = False _
			)
				If isNextRequest Then
					m_OctetStringsThatAreNotStringsBaseOids.Add(oid.Trim(FULL_STOP))
				Else
					m_OctetStringsThatAreNotStringsOids.Add(oid.Trim(FULL_STOP))
				End If

			End Sub

			Public Function IsOidFalseOctetString( _
				ByVal oid As String _
			) As Boolean

				If m_OctetStringsThatAreNotStringsOids.Contains(oid) Then

					Return True

				Else

					For i As Integer = 0 To m_OctetStringsThatAreNotStringsBaseOids.Count - 1

						If oid.StartsWith(m_OctetStringsThatAreNotStringsBaseOids(i)) Then _
							Return True

					Next

				End If

				Return False

			End Function

		#End Region

		#Region " Public Shared Methods "

			''' <summary>
			''' </summary>
			''' <param name="objectId"></param>
			''' <param name="delineatorCount"></param>
			''' <returns></returns>
			''' <remarks></remarks>
			Public Shared Function GetObjectIdPrefix( _
				ByVal objectId As String, _
				ByVal delineatorCount As Integer _
			) As String

				For i As Integer = 0 To delineatorCount - 1
					objectId = objectId.Substring(0, objectId.LastIndexOf(FULL_STOP))
				Next

				Return objectId

			End Function

			''' <summary>
			''' </summary>
			''' <param name="snmpType">The SNMP Data Type to Get the Object Type for.</param>
			''' <returns></returns>
			''' <remarks></remarks>
			Public Shared Function GetObjectType( _
				ByVal snmpType As SnmpDataType _
			) As Type

				Select Case snmpType
					Case SnmpDataType.ASN1_BIT_STRING

						Return GetType(String)

					Case SnmpDataType.ASN1_BOOLEAN

						Return GetType(Boolean)

					Case SnmpDataType.ASN1_ENUMERATED

						' Not Implemented
						Return Nothing

					Case SnmpDataType.ASN1_IA5_STRING

						Return GetType(String)

					Case SnmpDataType.ASN1_INTEGER

						Return GetType(Integer)

					Case SnmpDataType.ASN1_NULL

						Return Nothing

					Case SnmpDataType.ASN1_OBJECT_IDENTIFIER

						Return GetType(String)

					Case SnmpDataType.ASN1_OCTET_STRING

						Return GetType(String)

					Case SnmpDataType.ASN1_PRINTABLE_STRING

						Return GetType(String)

					Case SnmpDataType.ASN1_REAL

						Return GetType(Long)

					Case SnmpDataType.ASN1_SEQUENCE

						' Not Implemented
						Return Nothing

					Case SnmpDataType.ASN1_SET

						' Not Implemented
						Return Nothing

					Case SnmpDataType.ASN1_T61_STRING

						Return GetType(String)

					Case SnmpDataType.ASN1_UTC_TIME

						Return GetType(DateTime)

					Case SnmpDataType.SNMP_COUNTER_32

						Return GetType(Long)

					Case SnmpDataType.SNMP_COUNTER_64

						Return GetType(Long)

					Case SnmpDataType.SNMP_GAUGE

						Return GetType(Long)

					Case SnmpDataType.SNMP_IP_ADDRESS

						Return GetType(IPAddress)

					Case SnmpDataType.SNMP_OPAQUE

						' Not Implemented
						Return Nothing

					Case SnmpDataType.SNMP_PDU_GETBULKREQUEST

						' Not Implemented
						Return Nothing

					Case SnmpDataType.SNMP_PDU_GETNEXTREQUEST

						' Not Implemented
						Return Nothing

					Case SnmpDataType.SNMP_PDU_GETREQUEST

						' Not Implemented
						Return Nothing

					Case SnmpDataType.SNMP_PDU_GETRESPONSE

						' Not Implemented
						Return Nothing

					Case SnmpDataType.SNMP_PDU_INFORMREQUEST

						' Not Implemented
						Return Nothing

					Case SnmpDataType.SNMP_PDU_SETREQUEST

						' Not Implemented
						Return Nothing

					Case SnmpDataType.SNMP_PDU_TRAP

						' Not Implemented
						Return Nothing

					Case SnmpDataType.SNMP_PDU_TRAPV2

						' Not Implemented
						Return Nothing

					Case SnmpDataType.SNMP_PHYSICAL_ADDRESS

						Return GetType(PhysicalAddress)

					Case SnmpDataType.SNMP_TIMETICKS

						Return GetType(TimeSpan)

					Case SnmpDataType.SNMP_UNIT_32

						' Not Implemented
						Return Nothing

					Case Else

						Return Nothing

				End Select

			End Function

			''' <summary>
			''' Return the Oid String Represented by a String.
			''' </summary>
			''' <param name="value"></param>
			''' <returns></returns>
			''' <remarks></remarks>
			Public Shared Function StringToOid( _
				ByVal value As String _
			) As String

				If Not String.IsNullOrEmpty(value) Then _
					Return BytesToOid(BerEncoder.EncodeBerString(value))

				Return Nothing

			End Function

			Public Shared Function PhysicalAddressToOid( _
				ByVal value As System.Net.NetworkInformation.PhysicalAddress _
			) As String

				If Not value Is Nothing Then _
					Return BytesToOid(value.GetAddressBytes)

				Return Nothing

			End Function

			Public Shared Function BytesToOid( _
				ByVal bytes As Byte() _
			) As String

				If Not bytes Is Nothing Then

					Dim sb As New System.Text.StringBuilder()

					For i As Integer = 0 To bytes.Length - 1

						sb.Append(bytes(i).ToString)

						If i < bytes.Length - 1 Then sb.Append(FULL_STOP)

					Next

					Return sb.ToString

				End If

				Return Nothing

			End Function

			Public Shared Function OidToBytes( _
				ByVal oid As String _
			) As Byte()

				If Not String.IsNullOrEmpty(oid) Then

					Dim oid_Values As String() = oid.Split(FULL_STOP)

					Dim ret_Bytes(oid_Values.Length - 1) As Byte

					For i As Integer = 0 To oid_Values.Length - 1
						ret_Bytes(i) = Byte.Parse(oid_Values(i))
					Next

					Return ret_Bytes

				End If

				Return Nothing

			End Function

		#End Region

	End Class

End Namespace
