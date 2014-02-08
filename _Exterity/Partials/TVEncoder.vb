Namespace Exterity

	Partial Public Class TVEncoder
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public ReadOnly Property IsTVEncoderHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If Not DeviceName.IsAlive(CType(Me, Snmp.ISnmpManageable).Target) Then _
						Return New Health(HealthStatus.Down)

					Dim l_Health As New Health(HealthStatus.Healthy, Resources.HEALTH_GENERAL_NETWORKDEVICEDOWN)

					If Not Interfaces Is Nothing Then

						For i As Integer = 0 To Interfaces.Count - 1

							l_Health = Monitoring.CheckHealth(l_Health, Interfaces(i))

						Next

					End If

					Return l_Health

				End Get
			End Property

		#End Region

	End Class

End Namespace
