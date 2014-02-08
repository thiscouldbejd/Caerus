Partial Public Class InterfaceName

	#Region " Private Shared Variables "

		Private Shared INTERFACE_NAMES As String() = New String() _
			{"Port", "Ethernet", "Vlan", "Loopback", "Null", "Tunnel", "Radio", "Virtual", "BVI", "SVI"}

	#End Region

	#Region " Public Shared Methods "

	''' <summary>
		''' Method to Parse an Interface Name from a String Value.
		''' </summary>
		''' <param name="value">The Value to Parse.</param>
		''' <param name="parsedObject">The Returned Value if the Parse is Successfull.</param>
		''' <returns>A Boolean indicating Success or Failure</returns>
		''' <remarks></remarks>
		Public Shared Function TryParse( _
			ByVal value As String, _
			ByRef parsedObject As InterfaceName _
		) As Boolean

			If Not String.IsNullOrEmpty(value) Then

				Dim l_fullName As String = value.Trim
				Dim l_shortName As String = l_fullName

				For i As Integer = 0 To INTERFACE_NAMES.Length - 1

					If l_shortName.IndexOf(INTERFACE_NAMES(i), StringComparison.InvariantCultureIgnoreCase) >= 0 Then

						If l_shortName.IndexOf(SPACE) > 0 OrElse l_shortName.IndexOf(HYPHEN) > 0 Then _
							l_shortName = l_shortName.Split(New Char() {SPACE, HYPHEN})(0)

						For j As Integer = l_shortName.Length - 1 To 0 Step -1

							If Not l_shortName(j) = FULL_STOP AndAlso _
								Not l_shortName(j) = FORWARD_SLASH AndAlso _
								Not StringCommands.IsNumeric(l_shortName(j)) Then

								' Weird Bug with some Interface Names | Investigating!
								If l_shortName.Length > Math.Max(2, j + 1) Then _
									l_shortName = l_shortName.Substring(0, 2).ToLower & l_shortName.Substring(j + 1).ToLower

								Exit For

							End If

						Next

					End If

				Next

				parsedObject = New InterfaceName(l_fullName, l_shortName)

				Return True

			Else

				Return False

			End If

		End Function

	#End Region

End Class
