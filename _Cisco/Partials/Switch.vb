Namespace Cisco

	Partial Public Class Switch
		Implements IMonitorable

		#Region " Public Properties "

			Public ReadOnly Property StartupTime() As DateTime
				Get
					Return System.DateTime.Now().Subtract(UpTime.Value)
				End Get
			End Property

			Public ReadOnly Property CurrentTemperature() As Temperature
				Get
					If Not Me.Temperatures Is Nothing AndAlso Temperatures.Count > 0 Then _
						Return New Temperature(Me.Temperatures(0).Value)
					Return Nothing
				End Get
			End Property

		#End Region

		#Region " IMonitorable Implementation "

			Public Overridable ReadOnly Property IsSwitchHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If Not DeviceName.IsAlive(CType(Me, Snmp.ISnmpManageable).Target) Then _
						Return New Health(HealthStatus.Down)

					Dim l_Health As New Health(HealthStatus.Healthy)

					If Not Interfaces Is Nothing Then

						For i As Integer = 0 To Interfaces.Count - 1

							l_Health = Monitoring.CheckHealth(l_Health, Interfaces(i))

						Next

					End If

					If Not Entities Is Nothing Then

						For i As Integer = 0 To Entities.Count - 1

							l_Health = Monitoring.CheckHealth(l_Health, Entities(i))

						Next

					End If

					If Not Vlans Is Nothing Then

						For i As Integer = 0 To Vlans.Count - 1

							l_Health = Monitoring.CheckHealth(l_Health, Vlans(i))

						Next

					End If

					Return l_Health

				End Get
			End Property

		#End Region

	End Class

End Namespace
