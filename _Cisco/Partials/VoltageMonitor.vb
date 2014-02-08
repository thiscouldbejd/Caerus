Namespace Cisco

	Partial Public Class VoltageMonitor
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public Overridable ReadOnly Property IsVoltageMonitorHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If State = EnvironmentalMonitoringState.Critical OrElse _
						State = EnvironmentalMonitoringState.Shutdown OrElse _
						State = EnvironmentalMonitoringState.Warning Then

						Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_CISCO_MONITORSTATUS, "Voltage", State))

					Else

						Return New Health(HealthStatus.Healthy)

					End If

				End Get
			End Property

		#End Region

	End Class

End Namespace
