Imports Caerus.Cisco
Imports Leviathan.Visualisation
Imports IT = Leviathan.Visualisation.InformationType

Namespace Commands

	Partial Public Class CiscoCommands
		
		#Region " Command Processing Methods "
		
			<Command( _
				ResourceContainingType:=GetType(CiscoCommands), _
				ResourceName:="CommandDetails", _
				Name:="find-association", _
				Description:="@commandCiscoDescriptionFindAssociation@" _
			)> _
			Public Function ProcessCommandFindAssociation( _
				<Configurable( _
					ResourceContainingType:=GetType(CiscoCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandCiscoParameterPhysicalAddress@" _
				)> _
				ByVal macAddress As PhysicalAddress, _
				<Configurable( _
					ResourceContainingType:=GetType(CiscoCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandCiscoParameterAccessPoints@" _
				)> _
				ByVal accessPoints As ICollection _
			) As IFixedWidthWriteable
			
				For Each ap As AccessPoint In accessPoints
				
					If Not ap.WirelessInterfaces Is Nothing Then
					
						For Each wirelessInt As AccessPointInterface In ap.WirelessInterfaces
						
							If Not wirelessInt.Ssids Is Nothing Then
							
								For Each singleSsid As Ssid In wirelessInt.Ssids
								
									If Not singleSsid.Associations Is Nothing Then
									
										Dim foundAssociation As ClientAssociation = singleSsid.Associations(macAddress)
										
											If Not foundAssociation Is Nothing Then
											
												Dim rows As New List(Of Row)
												
												With rows
												
													.Add(New Row().Add("AP").Add(ap.Name))
													.Add(New Row().Add("AP IP").Add(ap.ISnmpManageable_Target))
													.Add(New Row().Add("AP Model").Add(ap.Model))
													
													.Add(New Row().Add("Organisation").Add(ap.Location.Organisation))
													
													.Add(New Row().Add("Site").Add(ap.Location.Site))
													.Add(New Row().Add("Block").Add(ap.Location.Block))
													.Add(New Row().Add("Room").Add(ap.Location.Room))
													.Add(New Row().Add("Area").Add(ap.Location.Area))
													
													.Add(New Row().Add("Role").Add(ap.Name.Role))
													.Add(New Row().Add("Layer").Add(ap.Name.Layer))
													.Add(New Row().Add("Area").Add(ap.Name.Area))
													.Add(New Row().Add("Number").Add(ap.Name.Number))
													
													.Add(New Row().Add("Interface").Add(wirelessInt.Name))
													.Add(New Row().Add("Interface Frequency").Add(wirelessInt.CurrentFrequency))
													.Add(New Row().Add("Interface Speed").Add(wirelessInt.Speed))
													.Add(New Row().Add("Interface Power").Add(wirelessInt.DisplayPower))
													
													.Add(New Row().Add("SSID").Add(singleSsid.Name))
													.Add(New Row().Add("SSID Broadcast").Add(singleSsid.Broadcast))
													
													.Add(New Row().Add("Association Address").Add(foundAssociation.ClientAddress))
													.Add(New Row().Add("Association Name").Add(foundAssociation.Name))
													.Add(New Row().Add("Association State").Add(foundAssociation.State))
													.Add(New Row().Add("Association Vlan").Add(foundAssociation.Vlan))
													.Add(New Row().Add("Association Algorithm").Add(foundAssociation.Algorithm))
													.Add(New Row().Add("Association Authentication").Add(foundAssociation.Authentication))
													.Add(New Row().Add("Association Key Management").Add(foundAssociation.KeyManagement))
													.Add(New Row().Add("Association Cipher (Unicast)").Add(foundAssociation.UnicastCipher))
													.Add(New Row().Add("Association Cipher (Multicast)").Add(foundAssociation.MulticastCipher))
													.Add(New Row().Add("Association Duration").Add(foundAssociation.Duration))
													.Add(New Row().Add("Association Speed").Add(foundAssociation.CurrentSpeeds))
													.Add(New Row().Add("Association Power Mode").Add(foundAssociation.PowerMode))
													.Add(New Row().Add("Association Signal Stength").Add(foundAssociation.SignalStrength))
													.Add(New Row().Add("Association Signal Quality").Add(foundAssociation.SignalQuality))
													
												End With
												
												Return Cube.Create(IT.Information, "Association", "Property", "Value").Add(New Slice(rows))
												
											End If
											
										End If
										
									Next
									
								End If
								
							Next
							
						End If
						
					Next
					
					Return Nothing
					
			End Function
			
			<Command( _
				ResourceContainingType:=GetType(CiscoCommands), _
				ResourceName:="CommandDetails", _
				Name:="format-config", _
				Description:="@commandCiscoDescriptionConfigFormat@" _
			)> _
			Public Sub ProcessCommandFormat( _
				<Configurable( _
					ResourceContainingType:=GetType(CiscoCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandCiscoParameterDevices@" _
				)> _
				ByVal networkDevice As Object, _
				<Configurable( _
					ResourceContainingType:=GetType(CiscoCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandCiscoParameterInputConfigFile@" _
				)> _
				ByVal inputConfigFile As IO.FileStream, _
				<Configurable( _
					ResourceContainingType:=GetType(CiscoCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandCiscoParameterOutputConfigFile@" _
				)> _
				ByVal outputConfigFile As IO.FileStream _
			)
			
				Dim inputConfigReader As New io.StreamReader(inputConfigFile)
				
				Dim inputConfig As String = inputConfigReader.ReadToEnd()
				
				inputConfigReader.Close()
				
				inputConfig = Format(inputConfig, networkDevice)
				
				Dim outputConfigWriter As New IO.StreamWriter(outputConfigFile)
				
				outputConfigWriter.Write(inputConfig)
				
				outputConfigWriter.Close()
				
			End Sub
			
			<Command( _
				ResourceContainingType:=GetType(CiscoCommands), _
				ResourceName:="CommandDetails", _
				Name:="find-address", _
				Description:="@commandCiscoDescriptionFindAddress@" _
			)> _
			Public Function ProcessCommandFindAddress( _
				<Configurable( _
					ResourceContainingType:=GetType(CiscoCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandCiscoParameterPhysicalAddress@" _
				)> _
				ByVal macAddress As PhysicalAddress, _
				<Configurable( _
					ResourceContainingType:=GetType(CiscoCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandCicsoSwitchParameterSwitches@" _
				)> _
				ByVal switches As ICollection _
			) As IFixedWidthWriteable()
			
				Dim lstReturn As New List(Of IFixedWidthWriteable)
				
				For Each sw As Cisco.Switch In switches
				
					If Not sw.ForwardingAddresses Is Nothing Then
					
						Dim foundAddress As BridgeForwardingAddress = sw.ForwardingAddresses(macAddress)
						
						If Not foundAddress Is Nothing Then
						
							Dim rows As New List(Of Row)
							
							With rows
							
								.Add(New Row().Add("Switch").Add(sw.Name))
								.Add(New Row().Add("Switch IP").Add(sw.ISnmpManageable_Target))
								.Add(New Row().Add("Switch Model").Add(sw.Model))
								
								.Add(New Row().Add("Organisation").Add(sw.Location.Organisation))
								
								.Add(New Row().Add("Site").Add(sw.Location.Site))
								.Add(New Row().Add("Block").Add(sw.Location.Block))
								.Add(New Row().Add("Room").Add(sw.Location.Room))
								.Add(New Row().Add("Area").Add(sw.Location.Area))
								
								.Add(New Row().Add("Role").Add(sw.Name.Role))
								.Add(New Row().Add("Layer").Add(sw.Name.Layer))
								.Add(New Row().Add("Area").Add(sw.Name.Area))
								.Add(New Row().Add("Number").Add(sw.Name.Number))
								
								.Add(New Row().Add("Status").Add(foundAddress.Status))
								
								For Each port As BridgePort In sw.BridgePorts
								
									If port.Index = foundAddress.Port Then
									
										For Each [interface] As SwitchInterface In sw.Interfaces
										
											If [interface].Index = port.InterfaceIndex Then
											
												.Add(New Row().Add("Interface").Add([interface].Name))
												
													For Each vl As Vlan In sw.Vlans
													
														If vl.Index = [interface].Vlan Then
														
															.Add(New Row().Add("Vlan").Add([interface].Vlan))
															.Add(New Row().Add("Vlan Name").Add(vl.Name))
															
															.Add(New Row().Add("Interface Secured").Add([interface].Secured))
															.Add(New Row().Add("Interface Security Status").Add([interface].SecurityStatus))
															.Add(New Row().Add("Interface Violation Action").Add([interface].ViolationAction))
															.Add(New Row().Add("Interface Dot1x Mode").Add([interface].Dot1xMode))
															.Add(New Row().Add("Interface Dot1x Status").Add([interface].Dot1xStatus))
															
															lstReturn.Add(Cube.Create(IT.Information, "Association","Property", "Value").Add(New Slice(rows)))
															
															Exit For
															
														End If
														
													Next
													
												Exit For
												
											End If
											
										Next
										
									End If
									
								Next
								
							End With
							
						End If
						
					End If
					
				Next
				
				Return lstReturn.ToArray()
				
			End Function
			
		#End Region
		
	End Class

End Namespace