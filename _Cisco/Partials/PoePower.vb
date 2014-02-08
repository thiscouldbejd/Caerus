Namespace Cisco

	Partial Public Class PoePower

		#Region " Public Properties "

			Public WriteOnly Property Parse() As Int64
				Set(ByVal value As Int64)

					If value < 4294967294 Then

						Me.Value = (value / 1000)

					Else

						Me.Value = 0

					End If

				End Set
			End Property

		#End Region

	End Class

End Namespace
