Namespace Cisco

	Public Class Vlan
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			''' <summary>
			''' Returns the Health of the Vlan.
			''' </summary>
			''' <returns></returns>
			''' <remarks></remarks>
			Public ReadOnly Property IsVlanHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If (Me.State = VlanState.SUSPENDED) Then

						Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_CISCO_VLANSUSPENDED, Index, Name))

					Else

						Return New Health(HealthStatus.Healthy)

					End If

				End Get
			End Property

		#End Region

	End Class

End Namespace
