Imports System.Net.Dns

Public Class Monitoring

	#Region " Public Shared Methods "

		''' <summary>
		''' Public Method to Check Health of an IMonitorable Instance.
		''' </summary>
		''' <param name="currentHealth">The Current Health of the System.</param>
		''' <param name="monitorable">The Instance whose Health to Check.</param>
		''' <returns>The health status.</returns>
		''' <remarks></remarks>
		Public Shared Function CheckHealth( _
			ByVal currentHealth As Health, _
			ByVal monitorable As IMonitorable _
		) As Health

			If Not monitorable Is Nothing Then

				Dim monitorableHealth As Health = monitorable.IsHealthy

				If monitorableHealth.Status < currentHealth.Status Then Return monitorableHealth

			End If

			Return currentHealth

		End Function

	#End Region

End Class
