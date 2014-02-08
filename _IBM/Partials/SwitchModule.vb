Namespace IBM

	Partial Public Class SwitchModule
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public ReadOnly Property IsSwitchModuleHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If HasPostResults Then

						If State = SwitchModuleState.Bad Then

							Return New Health(HealthStatus.Down, String.Format(Resources.HEALTH_IBM_SWITCHSTATUS, Index, State))

						ElseIf State = SwitchModuleState.Warning Then

							Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_IBM_SWITCHSTATUS, Index, State))

						End If

					End If

					Return New Health(HealthStatus.Healthy)

				End Get
			End Property

		#End Region

	End Class

End Namespace
