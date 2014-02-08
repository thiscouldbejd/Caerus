Public Class Temperature
	Implements IMonitorable

	#Region " Public Constants "

		Public Const CENTIGRADE_VALUE As String = "Centigrade"

	#End Region

	#Region " IMonitorable Implementation "

		Public Overridable ReadOnly Property IsTemperatureHealthy() As Health Implements IMonitorable.IsHealthy
			Get

				If Value >= WarningLevelHigh Then

					Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_GENERAL_TEMPERATUREHIGH, _
						Me.ToString(), New Temperature(WarningLevelHigh).ToString()))

				ElseIf Value <= WarningLevelLow Then

					Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_GENERAL_TEMPERATURELOW, _
						Me.ToString(), New Temperature(WarningLevelLow).ToString()))

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
		''' <remarks>29 C/80 F | 46 C/114 F</remarks>
		Public Shared Function TryParse( _
			ByVal value As String, _
			ByRef parsedObject As Temperature _
		) As Boolean

			If Not String.IsNullOrEmpty(value) Then

				If parsedObject Is Nothing Then parsedObject = New Temperature()

				If value.IndexOf("/") >= 0 Then

					Dim c_Value As String = value.Substring(0, value.IndexOf("/")).TrimEnd("C".ToCharArray()).Trim()
					Dim f_Value As String = value.Substring(value.IndexOf("/") + 1).TrimEnd("F".ToCharArray()).Trim()

					If Double.TryParse(c_Value, parsedObject.Value) AndAlso _
						Double.TryParse(f_Value, parsedObject.Farenheit) Then Return True

				Else

					Dim c_Value As String = value.TrimEnd("C".ToCharArray()).Trim()

					If Double.TryParse(c_Value, parsedObject.Value) Then

						parsedObject.Farenheit = (parsedObject.Value * (9/5)) + 32
						Return True

					End If

				End If

			End If

			Return False

		End Function

	#End Region

End Class
