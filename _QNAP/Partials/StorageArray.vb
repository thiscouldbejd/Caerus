Namespace QNAP

	Partial Public Class StorageArray
		Implements IMonitorable

		#Region " IMonitorable Implementation "

			Public ReadOnly Property IsStorageArrayHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If Not DeviceName.IsAlive(CType(Me, Snmp.ISnmpManageable).Target) Then _
						Return New Health(HealthStatus.Down)

					Dim l_Health As New Health(HealthStatus.Healthy)

					l_Health = Monitoring.CheckHealth(l_Health, System_Temperature)
					l_Health = Monitoring.CheckHealth(l_Health, CPU_Temperature)

					If Not Interfaces Is Nothing Then

						For i As Integer = 0 To Interfaces.Count - 1

							l_Health = Monitoring.CheckHealth(l_Health, Interfaces(i))

						Next

					End If

					If Not Drives Is Nothing Then

						For i As Integer = 0 To Drives.Count - 1

							l_Health = Monitoring.CheckHealth(l_Health, Drives(i))

						Next

					End If

					If Not Volumes Is Nothing Then

						For i As Integer = 0 To Volumes.Count - 1

							l_Health = Monitoring.CheckHealth(l_Health, Volumes(i))

						Next

					End If

					Return l_Health

				End Get
			End Property

		#End Region

	End Class

End Namespace
