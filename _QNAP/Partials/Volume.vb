Namespace QNAP

	Partial Public Class Volume
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public ReadOnly Property IsVolumeHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If Status.ToUpper <> "READY" Then

						Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_QNAP_VOLUMENOTREADY, Index, Description, Status))

					Else

						Return New Health(HealthStatus.Healthy)

					End If

				End Get
			End Property

		#End Region

	End Class

End Namespace
