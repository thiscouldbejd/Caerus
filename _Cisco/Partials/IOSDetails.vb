Namespace Cisco

	Partial Public Class IOSDetails

		#Region " Private Shared Methods "

			''' <summary>
			''' This methods parses the IOS Version and expects it's input in the general form a.b(c.d)e (e.g. 12.2(37)SG).
			''' </summary>
			''' <param name="value">The version string.</param>
			''' <param name="parsedObject">The object being parsed.</param>
			''' <remarks>
			''' a is the major version number.
			''' b is the minor version number.
			''' c is the release number, which begins at one and increments as new releases in the same a.b train are released.
			''' d (omitted from general releases) is the interim build number.
			''' e (zero, one or two letters) is the release train identifier
			''' </remarks>
			Private Shared Sub ParseVersion( _
				ByVal value As String, _
				ByRef parsedObject As IOSDetails _
			)

				Dim versionString As String = value.Substring(0, value.IndexOf(BRACKET_START))
				Dim releaseString As String = value.Substring(value.IndexOf(BRACKET_START) + 1, _
					value.IndexOf(BRACKET_END) - (value.IndexOf(BRACKET_START) + 1))
				Dim trainString As String = value.Substring(value.IndexOf(BRACKET_END) + 1)

				' Parse the Version
				parsedObject.Version = Single.Parse(versionString)

				' Parse the Release and Build (if available)
				If Not String.IsNullOrEmpty(releaseString) Then

					For i As Integer = 0 To releaseString.Length - 1

						If Not StringCommands.IsNumeric(releaseString.Substring(i, 1)) Then _
							releaseString = releaseString.Substring(0, i)

					Next

					If releaseString.IndexOf(FULL_STOP) >= 0 Then
						parsedObject.Release = releaseString.Split(FULL_STOP)(0)
						parsedObject.Build = releaseString.Split(FULL_STOP)(1)
					Else
						parsedObject.Release = Integer.Parse(releaseString)
					End If

				End If

				If String.IsNullOrEmpty(trainString) Then

					parsedObject.Train = IOSTrain.Mainline

				Else

					Dim trainVersionString As String = Nothing

					For i As Integer = 0 To trainString.Length - 1

						If StringCommands.IsNumeric(trainString.Substring(i, 1)) Then
							trainVersionString = trainString.Substring(i)
							trainString = trainString.Substring(0, i)
							Exit For
						End If

					Next

					If Not String.IsNullOrEmpty(trainVersionString) Then

						For i As Integer = 0 To trainVersionString.Length - 1

							If Not StringCommands.IsNumeric(trainVersionString.Substring(i, 1)) Then
								trainVersionString = trainVersionString.Substring(0, i)
								Exit For
							End If

						Next

						parsedObject.TrainVersion = Int32.Parse(trainVersionString)

					End If

					If String.IsNullOrEmpty(trainString) Then

						parsedObject.Train = IOSTrain.Mainline

					ElseIf trainString.StartsWith("X") Then

						parsedObject.Train = IOSTrain.SpecialFunctionality

					ElseIf trainString.StartsWith("T") Then

						parsedObject.Train = IOSTrain.Technology

					ElseIf trainString.StartsWith("S") Then

						parsedObject.Train = IOSTrain.ServiceProvider

					ElseIf trainString.StartsWith("E") Then

						parsedObject.Train = IOSTrain.Enterprise

					ElseIf trainString.StartsWith("B") Then

						parsedObject.Train = IOSTrain.Broadband

					ElseIf trainString.StartsWith("X") Then

						parsedObject.Train = IOSTrain.SpecialFunctionality

					ElseIf trainString.StartsWith("J") Then

						parsedObject.Train = IOSTrain.Wireless

					Else

						parsedObject.Train = IOSTrain.Other

					End If

				End If

			End Sub

			''' <summary>
			''' This method parses the IOS Compilation Section in the general form [Date] by [Person]
			''' </summary>
			''' <param name="value">The compilation string.</param>
			''' <param name="parsedObject">The object being parsed.</param>
			''' <remarks></remarks>
			Private Shared Sub ParseCompilation( _
				ByVal value As String, _
				ByRef parsedObject As IOSDetails _
			)

				Dim compilationDateString As String = value.Substring(0, value.IndexOf(" by "))
				Dim compilationByString As String = value.Substring(value.IndexOf(" by ") + 4)

				' Parse the Date
				DateTime.TryParse(compilationDateString, parsedObject.CompilationDate)

				' Parse the By
				parsedObject.CompiledBy = compilationByString

			End Sub

		#End Region

		#Region " Public Shared Methods "

			Public Shared Function TryParse( _
				ByVal value As String, _
				ByRef parsedObject As IOSDetails _
			) As Boolean

				If Not String.IsNullOrEmpty(value) Then

					If parsedObject Is Nothing Then parsedObject = New IOSDetails()

					Dim bracketStart As Integer = value.IndexOf(BRACKET_START)
					Dim bracketEnd As Integer = value.IndexOf(BRACKET_END)

					Do Until bracketStart < 0

						If value.IndexOf(HYPHEN, bracketStart, (bracketEnd - bracketStart)) >= 0 Then

							parsedObject.Image = value.Substring(bracketStart + 1, (bracketEnd - (bracketStart + 1)))
							Exit Do

						ElseIf bracketEnd + 1 < value.Length Then

							bracketStart = value.IndexOf(BRACKET_START, bracketEnd + 1)
							bracketEnd = value.IndexOf(BRACKET_END, bracketEnd + 1)

						Else

							bracketStart = -1
							bracketEnd = -1

						End If

					Loop

					' Do the Version Section
					If value.ToLower.IndexOf("version") >= 0 Then _
						ParseVersion(value.Substring(value.ToLower.IndexOf("version") + 8, value.IndexOf(COMMA, _
							value.ToLower.IndexOf("version")) - (value.ToLower.IndexOf("version") + 8)), parsedObject)

					' Do the Compiled Section
					If value.ToLower.IndexOf("compiled") >= 0 Then _
						ParseCompilation(value.Substring(value.ToLower.IndexOf("compiled") + 9), parsedObject)

					Return True

				End If

				Return False

			End Function

		#End Region

	End Class

End Namespace
