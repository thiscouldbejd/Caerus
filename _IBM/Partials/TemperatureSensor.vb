Namespace IBM

	Partial Public Class TemperatureSensor

		#Region " IMonitorable Implementation "

			Public Overrides ReadOnly Property IsTemperatureHealthy() As Health
				Get

					If Offline Then

						Return New Health(HealthStatus.Down, Resources.HEALTH_IBM_TEMPERATURESENSOROFFLINE)

					Else

						Return New Health(HealthStatus.Healthy)

					End If

				End Get
			End Property

		#End Region

		#Region " Public Shared Methods "

			''' <summary>
			''' Method to Parse from a String Value.
			''' </summary>
			''' <param name="value">The Value to Parse.</param>
			''' <param name="parsedObject">The Returned Value if the Parse is Successfull.</param>
			''' <returns>A Boolean indicating Success or Failure</returns>
			''' <remarks></remarks>
			Public Overloads Shared Function TryParse( _
				ByVal value As String, _
				ByRef parsedObject As TemperatureSensor _
			) As Boolean

				If Not String.IsNullOrEmpty(value) Then

					Dim l_NotSupported As Boolean
					Dim l_Offline As Boolean
					Dim l_value As Double = BladeCenter.ParseIBMStringNumerical( _
						value, CENTIGRADE_VALUE, l_NotSupported, l_Offline)

					parsedObject = New TemperatureSensor(l_NotSupported, l_Offline)
					parsedObject.Value = l_Value

					Return True

				Else

					Return False

				End If

			End Function

		#End Region

	End Class

End Namespace
