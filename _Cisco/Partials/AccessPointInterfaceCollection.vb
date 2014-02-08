Namespace Cisco

	Partial Public Class AccessPointInterfaceCollection
		Implements IMonitorable

		#Region " Public Properties "

			Public ReadOnly Property TotalAssociations() As Integer
				Get
					Dim l_totalAssociations As Integer = 0

					For i As Integer = 0 To Count - 1

						l_totalAssociations += Me(i).TotalAssociations

					Next

					Return l_totalAssociations
				End Get
			End Property

			Public ReadOnly Property MaxAssociations() As Integer
				Get
					Dim l_maxAssociations As Integer = 0

					For i As Integer = 0 To Count - 1

						l_maxAssociations += Me(i).MaxAssociations

					Next

					Return l_maxAssociations
				End Get
			End Property

			Public ReadOnly Property WiredInterfaces() As IList
				Get
					Dim aryReturn As New ArrayList

					For i As Integer = 0 To Count - 1

						If Me(i).Type = InterfaceType.FastEthernet OrElse _
							Me(i).Type = InterfaceType.GigabitEthernet _
							Then aryReturn.Add(Me(i))

					Next

					Return aryReturn

				End Get
			End Property

			Public ReadOnly Property WirelessInterfaces() As IList
				Get
					Dim aryReturn As New ArrayList

					For i As Integer = 0 To Count - 1

						If Me(i).Type = InterfaceType.IEEE80211 AndAlso Not Me(i).Name.ToString().StartsWith("Virtual") _
							Then aryReturn.Add(Me(i))

					Next

					Return aryReturn

				End Get
			End Property

			Public ReadOnly Property VlanInterfaces() As IList
				Get
					Dim aryReturn As New ArrayList

					For i As Integer = 0 To Count - 1

						If Me(i).Type = InterfaceType.L2Vlan _
							Then aryReturn.Add(Me(i))

					Next

					Return aryReturn

				End Get
			End Property

		#End Region

		#Region " IMonitorable Implementation "

			Public Overridable ReadOnly Property IsAccessPointInterfaceCollectionHealthy() As Health Implements IMonitorable.IsHealthy
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
