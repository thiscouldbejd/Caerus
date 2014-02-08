Namespace Cisco

	Partial Public Class TemperatureMonitor
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public Overridable ReadOnly Property IsTemperatureMonitorHealthy() As Health Implements IMonitorable.IsHealthy
				Get

				If Me.State = EnvironmentalMonitoringState.Critical OrElse _
					Me.State = EnvironmentalMonitoringState.Shutdown OrElse _
					Me.State = EnvironmentalMonitoringState.Warning Then

					Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_CISCO_MONITORSTATUS, "Temperature", State))

				Else

					Return New Health(HealthStatus.Healthy)

				End If

				End Get
			End Property

		#End Region

	End Class

End Namespace
