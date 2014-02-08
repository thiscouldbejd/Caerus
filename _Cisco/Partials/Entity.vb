Namespace Cisco

	Partial Public Class Entity
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public Overridable ReadOnly Property IsEntityHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If Type = HardwareType.Sensor AndAlso Status = SensorStatus.NonOperational Then _
						Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_CISCO_ENTITYSENSORNONOPERATIONAL, Name))

					Return New Health(HealthStatus.Healthy)

				End Get
			End Property

		#End Region

	End Class

End Namespace
