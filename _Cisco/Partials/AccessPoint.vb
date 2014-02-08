Namespace Cisco

	Partial Public Class AccessPoint
	Implements IMonitorable

		#Region " Public Properties "

			Public ReadOnly Property StartupTime() As DateTime
				Get
					Return System.DateTime.Now().Subtract(UpTime.Value)
				End Get
			End Property

			Public ReadOnly Property WiredInterfaces() As AccessPointInterfaceCollection
				Get
					If Not Interfaces Is Nothing Then

						Dim return_Collection As New AccessPointInterfaceCollection
						return_Collection.AddRange(Interfaces.WiredInterfaces)
						Return return_Collection

					Else

						Return New AccessPointInterfaceCollection

					End If
				End Get
			End Property

			Public ReadOnly Property WirelessInterfaces() As AccessPointInterfaceCollection
				Get
					If Not Interfaces Is Nothing Then

						Dim return_Collection As New AccessPointInterfaceCollection
						return_Collection.AddRange(Interfaces.WirelessInterfaces)
						Return return_Collection

					Else

						Return New AccessPointInterfaceCollection

					End If
				End Get
			End Property

		#End Region

		#Region " IMonitorable Implementation "

			Public Overridable ReadOnly Property IsAccessPointHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If Not DeviceName.IsAlive(CType(Me, Snmp.ISnmpManageable).Target) Then _
						Return New Health(HealthStatus.Down, Resources.HEALTH_GENERAL_NETWORKDEVICEDOWN)

					Dim l_Health As New Health(HealthStatus.Healthy)

					If Not Interfaces.WirelessInterfaces Is Nothing Then

						For i As Integer = 0 To Interfaces.WirelessInterfaces.Count - 1

							l_Health = Monitoring.CheckHealth(l_Health, Interfaces.WirelessInterfaces(i))

						Next

					End If

					Return l_Health

				End Get
			End Property

		#End Region

	End Class

End Namespace
