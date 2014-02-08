Namespace Cisco

	Partial Public Class PowerMonitorCollection
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public Overridable ReadOnly Property IsPowerMonitorCollectionHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					Dim l_Health As New Health(HealthStatus.Healthy)

					For i As Integer = 0 To Count - 1

						l_Health = Monitoring.CheckHealth(l_Health, Item(i))

					Next

					Return l_Health

				End Get
			End Property

		#End Region

	End Class

End Namespace
