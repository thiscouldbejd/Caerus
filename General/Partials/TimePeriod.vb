Partial Public Class TimePeriod

	#Region " Public Properties "

		Public WriteOnly Property SecondsValue() As Double
			Set(value As Double)
				Me.Value = TimeSpan.FromSeconds(value)
			End Set
		End Property

		Public WriteOnly Property MillisecondsValue() As Double
			Set(value As Double)
				Me.Value = TimeSpan.FromMilliseconds(value)
			End Set
		End Property

	#End Region

	#Region " Public Methods "

		Public Overrides Function ToString() As String

			Return New TimespanConvertor().ParseStringFromTimespan(Value, New Boolean, True)

		End Function

	#End Region

End Class
