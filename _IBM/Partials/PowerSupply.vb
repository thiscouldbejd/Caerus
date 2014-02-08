Namespace IBM

	Partial Public Class PowerSupply
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public ReadOnly Property IsPowerSupplyHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If Exists Then

						If State = PowerSupplyState.NotAvailable Then

							Return New Health(HealthStatus.Down, String.Format(Resources.HEALTH_IBM_POWERSUPPLYSTATUS, Index, State))

						ElseIf State = PowerSupplyState.Warning Then

							Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_IBM_POWERSUPPLYSTATUS, Index, State))

						End If

					End If

					Return New Health(HealthStatus.Healthy)

				End Get
			End Property

		#End Region

	End Class

End Namespace
