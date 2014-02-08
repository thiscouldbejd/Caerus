Imports Caerus.Monitoring

Partial Public Class NetworkDevice
	Implements IMonitorable

	#Region " IMonitorable Implementation "

		Public Overridable ReadOnly Property IsNetworkDeviceHealthy() As Health Implements IMonitorable.IsHealthy
			Get

				If Not DeviceName.IsAlive(CType(Me, Snmp.ISnmpManageable).Target) Then _
					Return New Health(HealthStatus.Down, Resources.HEALTH_GENERAL_NETWORKDEVICEDOWN)

				Dim l_Health As New Health(HealthStatus.Healthy)

				If Not Interfaces Is Nothing Then

					For i As Integer = 0 To Interfaces.Count - 1

						l_Health = CheckHealth(l_Health, Interfaces(i))

					Next

				End If

				Return l_Health

			End Get
		End Property

	#End Region

End Class
