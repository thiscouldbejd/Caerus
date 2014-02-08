Namespace Cisco

	Partial Public Class SensorThreshold
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public Overridable ReadOnly Property IsSensorThresholdHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If Status = True AndAlso Severity = SensorThresholdSeverity.Minor OrElse _
							Severity = SensorThresholdSeverity.Major OrElse _
							Severity = SensorThresholdSeverity.Critical Then _
							Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_CISCO_SENSORSTATUS, Severity))

					Return New Health(HealthStatus.Healthy)

				End Get
			End Property

		#End Region

	End Class

End Namespace
