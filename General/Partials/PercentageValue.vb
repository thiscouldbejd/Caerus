Partial Public Class PercentageValue

	#Region " Public Methods "

		Public Overrides Function ToString() As String

			Return PercentageValue.FormatPercentage(Value)

		End Function

	#End Region

	#Region " Public Shared Methods "

		Public Shared Function FormatPercentage( _
			ByVal value As Single, _
			ByVal Optional decimalPlaces As Integer = 2 _
		) As String

			If Math.Sign(value) < 0 Then value = (0 - value)

			If value <= 1 Then

				Return Math.Round(value * 100, decimalPlaces).ToString & PERCENTAGE_MARK

			ElseIf value <= 100

				Return Math.Round(value, decimalPlaces).ToString & PERCENTAGE_MARK

			ElseIf value <= 1000

				Return Math.Round(value / 10, decimalPlaces).ToString & PERCENTAGE_MARK

			End If

			Return Nothing

		End Function

	#End Region

End Class
