Namespace Cisco

	Partial Public Class FanMonitor
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public Overridable ReadOnly Property IsFanMonitorHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If State = EnvironmentalMonitoringState.Critical OrElse _
						State = EnvironmentalMonitoringState.Shutdown OrElse _
						State = EnvironmentalMonitoringState.Warning Then

						Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_CISCO_MONITORSTATUS, "Fan", State))

					Else

						Return New Health(HealthStatus.Healthy)

					End If

				End Get
			End Property

		#End Region

	End Class

End Namespace
