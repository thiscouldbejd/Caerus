Namespace QNAP

	Partial Public Class HardDrive
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public ReadOnly Property IsHardDriveHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If Status <> HDStatus.READY Then

						Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_QNAP_HARDDRIVENOTREADY, Index, Description))

					ElseIf Not String.IsNullOrEmpty(SMART) AndAlso SMART.ToUpper <> "GOOD" Then

						Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_QNAP_HARDDRIVEBADSMART, Index, Description, SMART))

					ElseIf Not Temperature Is Nothing Then

						Temperature.WarningLevelHigh = 40
						Return Monitoring.CheckHealth(New Health(HealthStatus.Healthy), Temperature)

					Else

						Return New Health(HealthStatus.Healthy)

					End If

				End Get
			End Property

		#End Region

	End Class

End Namespace
