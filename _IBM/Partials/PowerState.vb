Namespace IBM

	Partial Public Class PowerState

		#Region " Public Shared Methods "

			''' <summary>
			''' Method to Parse from a String Value.
			''' </summary>
			''' <param name="value">The Value to Parse.</param>
			''' <param name="parsedObject">The Returned Value if the Parse is Successfull.</param>
			''' <returns>A Boolean indicating Success or Failure</returns>
			''' <remarks></remarks>
			Public Shared Function TryParse( _
				ByVal value As String, _
				ByRef parsedObject As PowerState _
			) As Boolean

				If Not String.IsNullOrEmpty(value) Then

					parsedObject = New PowerState([Enum].Parse(GetType(PowerDomainState), _
						value.Substring(0, 1)), value.Substring(2))

					Return True

				Else

					Return False

				End If

			End Function

		#End Region

	End Class

End Namespace
