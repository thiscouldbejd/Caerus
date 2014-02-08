Imports Caerus.Monitoring

Partial Public Class Computer
	Implements IMonitorable

	#Region " Private Constants "

		''' <summary>
		''' Magic Packet Header Length
		''' </summary>
		Private Const HEADER_LENGTH As Integer = 6

		''' <summary>
		''' Magic Packet Byte Length
		''' </summary>
		Private Const BYTE_LENGTH As Integer = 6

		''' <summary>
		''' Magic Packet Length
		''' </summary>
		Private Const MAGIC_PACKET_LENGTH As Integer = 16

	#End Region

	#Region " Public Properties "

		Public ReadOnly Property FixedStorage() As StorageDevice()
			Get
				Return Storage.Items(StorageType.FixedDisk)
			End Get
		End Property

	#End Region

	#Region " IMonitorable Implementation "

		Public Overridable ReadOnly Property IsComputerHealthy() As Health Implements IMonitorable.IsHealthy
			Get

				If Not DeviceName.IsAlive(CType(Me, Snmp.ISnmpManageable).Target) Then _
					Return New Health(HealthStatus.Down, Resources.HEALTH_GENERAL_NETWORKDEVICEDOWN)

				Dim l_Health As New Health(HealthStatus.Healthy)

				If Not Interfaces Is Nothing Then

					For i As Integer = 0 To Interfaces.Count - 1

						l_Health = CheckHealth(l_Health, Interfaces(i))

					Next

				End If

				If Not FixedStorage Is Nothing Then

					For i As Integer = 0 To FixedStorage.Count - 1

						l_Health = CheckHealth(l_Health, FixedStorage(i))

					Next

				End If

				Return l_Health

			End Get
		End Property

	#End Region

	#Region " Protected Shared Methods "

		''' <summary>
		''' Method to Create the Payload for the WOL Packet.
		''' </summary>
		''' <param name="macAddress">The Mac Address Destination of the Packet.</param>
		''' <returns></returns>
		''' <remarks></remarks>
		Protected Shared Function CreateWakeOnLanPayload( _
			ByVal macAddress As Byte() _
		) As Byte()

			Dim payloadData((HEADER_LENGTH + MAGIC_PACKET_LENGTH * BYTE_LENGTH) - 1) As Byte

			For i As Integer = 0 To HEADER_LENGTH - 1
				payloadData(i) = 255
			Next

			For i As Integer = 0 To MAGIC_PACKET_LENGTH - 1
				For j As Integer = 0 To BYTE_LENGTH - 1
					payloadData(((i * BYTE_LENGTH) + j) + HEADER_LENGTH) = macAddress(j)
				Next
			Next

			Return payloadData

		End Function

		''' <summary>
		''' Method to Send a UDP packet to a particular endpoint.
		''' </summary>
		''' <param name="destination">The End Point Destination for the Packet.</param>
		''' <param name="payload">The Packet Payload to send.</param>
		''' <returns>The number of Bytes sent.</returns>
		''' <remarks></remarks>
		Protected Shared Function SendUDPPacket( _
			ByVal destination As IPEndPoint, _
			ByVal payload As Byte() _
		) As Integer

			Dim socketClient As New Socket(destination.AddressFamily, _
				SocketType.Dgram, ProtocolType.Udp)

			Dim sendReturn As Integer = 0

			Try

				socketClient.Connect(destination)
				sendReturn = socketClient.Send(payload, payload.Length, SocketFlags.None)

			Catch ex As Exception
			Finally
				socketClient.Close()
			End Try

			Return sendReturn

		End Function

	#End Region

	#Region " Public Shared Methods "

		''' <summary>
		''' Method to Perform a Wake On Lan.
		''' </summary>
		''' <param name="macAddress">The Mac Address of the Device to Wake.</param>
		''' <param name="broadcastAddress">The Broadcast Address of the Subnet/Vlan containing the Device.</param>
		''' <param name="broadcastPort">The Port to Send to.</param>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Shared Function WakeOverLan( _
			ByVal macAddress As PhysicalAddress, _
			ByVal broadcastAddress As IPAddress, _
			ByVal broadcastPort As Integer _
		) As Boolean

			Return SendUDPPacket(New IPEndPoint(broadcastAddress, broadcastPort), _
				CreateWakeOnLanPayload(macAddress.GetAddressBytes)) > 0

		End Function

	#End Region

End Class
