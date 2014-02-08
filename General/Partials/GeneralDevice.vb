Partial Public Class GeneralDevice
	Implements IMonitorable

	#Region " IMonitorable Implementation "

		Public Overridable ReadOnly Property IsGeneralDeviceHealthy() As Health Implements IMonitorable.IsHealthy
			Get

				If Status = DeviceStatus.Down Then

					Return New Health(HealthStatus.Down)

				ElseIf Status = DeviceStatus.Warning Then

					Return New Health(HealthStatus.Degraded)

				Else

					Return New Health(HealthStatus.Healthy)

				End If

			End Get
		End Property

	#End Region

End Class
