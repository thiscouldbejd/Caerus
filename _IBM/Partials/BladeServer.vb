Namespace IBM

	Partial Public Class BladeServer
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public ReadOnly Property IsBladeServerHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If Exists Then

						If State = BladeState.Bad Then

							Return New Health(HealthStatus.Down, String.Format(Resources.HEALTH_IBM_BLADESERVERSTATUS, Index, Name, State))

						ElseIf State = BladeState.Warning Then

							Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_IBM_BLADESERVERSTATUS, Index, Name, State))

						End If

					End If

					Return New Health(HealthStatus.Healthy)

				End Get
			End Property

		#End Region

	End Class

End Namespace
