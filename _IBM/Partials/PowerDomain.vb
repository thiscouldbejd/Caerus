Namespace IBM

	Partial Public Class PowerDomain
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public ReadOnly Property IsPowerDomainHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If State.State = PowerDomainState.Bad Then

						Return New Health(HealthStatus.Down, String.Format(Resources.HEALTH_IBM_POWERDOMAINSTATUS, Index, State, UsedPower, TotalPower))

					ElseIf State.State = PowerSupplyState.Warning Then

						Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_IBM_POWERDOMAINSTATUS, Index, State, UsedPower, TotalPower))

					End If

					Return New Health(HealthStatus.Healthy)

				End Get
			End Property

		#End Region

	End Class

End Namespace
