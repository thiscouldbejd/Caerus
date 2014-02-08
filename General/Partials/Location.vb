Partial Public Class Location

	#Region " Public Shared Functions "

		''' <summary>
		''' Method to Parse a Location from a String Value.
		''' </summary>
		''' <param name="value">The Value to Parse.</param>
		''' <param name="parsedObject">The Returned Value if the Parse is Successfull.</param>
		''' <returns>A Boolean indicating Success or Failure</returns>
		''' <remarks></remarks>
		Public Shared Function TryParse( _
			ByVal value As String, _
			ByRef parsedObject As Location _
		) As Boolean

			If Not String.IsNullOrEmpty(value) AndAlso _
				(value.IndexOf(BACK_SLASH) > 0 OrElse value.IndexOf(FORWARD_SLASH) > 0) Then

				parsedObject = New Location

				Dim values As String() = value.Split(New Char() {BACK_SLASH, FORWARD_SLASH}, _
					StringSplitOptions.RemoveEmptyEntries)

				If values.Length >= 1 Then

					parsedObject.Organisation = values(0)

					If values.Length >= 2 Then

						parsedObject.Site = values(1)

						If values.Length >= 3 Then

							parsedObject.Block = values(2)

							If values.Length >= 4 Then

								parsedObject.Room = values(3)

								If values.Length >= 5 Then parsedObject.Area = values(4)

							End If

						End If

					End If

				End If

				Return True

			End If

			Return False

		End Function

	#End Region

End Class
