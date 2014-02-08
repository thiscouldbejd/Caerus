Namespace IBM

	Partial Public Class Blower
		Implements IMonitorable

		#Region " Public Properties "

			Public WriteOnly Property Parse() As String
				Set(value As String)

					Me.Value = BladeCenter.ParseIBMStringNumerical(value, NotSupported, Offline)

				End Set
			End Property

		#End Region

		#Region " IMonitorable Implementation "

			Public ReadOnly Property IsHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If Not NotSupported Then

						If Offline Or State = BlowerState.Bad Then

							Return New Health(HealthStatus.Down, String.Format(Resources.HEALTH_IBM_BLOWERSTATUS, State, Value))

						ElseIf State = BlowerState.Warning Or State = BlowerState.Unknown Then

							Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_IBM_BLOWERSTATUS, State, Value))

						End If

					End If

					Return New Health(HealthStatus.Healthy)

				End Get
			End Property

		#End Region

	End Class

End Namespace
