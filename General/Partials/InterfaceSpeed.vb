Partial Public Class InterfaceSpeed

	#Region " Private Shared Variables "

		Private Shared BOUNDARY_VALUES As Int64() = New Int64() {1000000000, 1000000, 1000, 1}

		Private Shared BOUNDARY_DESCRIPTIONS As String() = New String() {"gbit", "mbit", "kbit", "bit"}

	#End Region

	#Region " Public Properties "

		Public ReadOnly Property HalfDuplex As System.Int64
			Get
				Return Value / 2
			End Get
		End Property

	#End Region

	#Region " Public Methods "

		Public Overrides Function ToString() As String

			Return DeltaCounter32.FormatBoundariedNumber(Value, BOUNDARY_VALUES, BOUNDARY_DESCRIPTIONS)

		End Function

	#End Region

End Class
