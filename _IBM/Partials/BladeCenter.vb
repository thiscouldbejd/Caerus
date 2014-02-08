Namespace IBM

	Partial Public Class BladeCenter
		Implements IMonitorable

		#Region " Public Constants "

			Public Const NOT_READABLE_VALUE As String = "Not Readable!"

			Public Const OFFLINE_VALUE As String = "Offline"

		#End Region

		#Region " IMonitorable Implementation "

			Public ReadOnly Property IsBladeCenterHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					Dim l_Health As New Health(HealthStatus.Healthy)

					l_Health = Monitoring.CheckHealth(l_Health, Blower1)

					l_Health = Monitoring.CheckHealth(l_Health, Blower2)

					If Not PowerSupplies Is Nothing Then

						For i As Integer = 0 To PowerSupplies.Count - 1

							l_Health = Monitoring.CheckHealth(l_Health, PowerSupplies(i))

						Next

					End If

					If Not PowerDomains Is Nothing Then

						For i As Integer = 0 To PowerDomains.Count - 1

							l_Health = Monitoring.CheckHealth(l_Health, PowerDomains(i))

						Next

					End If

					If Not BladeServers Is Nothing Then

						For i As Integer = 0 To BladeServers.Count - 1

							l_Health = Monitoring.CheckHealth(l_Health, BladeServers(i))

						Next

					End If

					If Not SwitchModules Is Nothing Then

						For i As Integer = 0 To SwitchModules.Count - 1

							l_Health = Monitoring.CheckHealth(l_Health, SwitchModules(i))

						Next

					End If

					Return l_Health

				End Get
			End Property

		#End Region

		#Region " Public Shared Methods "

			Public Shared Function ParseIBMNumericalValue( _
				ByVal fullStringRepresentation As String _
			) As Double

				If Not String.IsNullOrEmpty(fullStringRepresentation) Then

					Return Double.Parse(fullStringRepresentation.Trim().TrimEnd(UPPERCASE_LETTERS))

				Else

					Return 0

				End If

			End Function

			Public Shared Function ParseIBMStringNumerical( _
				ByVal fullStringRepresentation As String, _
				ByRef notSupported As Boolean, _
				ByRef offline As Boolean _
			) As Long

				Try

					If Not String.IsNullOrEmpty(fullStringRepresentation) Then

						If String.Compare(fullStringRepresentation, NOT_READABLE_VALUE) = 0 Then

							notSupported = True
							offline = False

							Return 0

						ElseIf String.Compare(fullStringRepresentation, OFFLINE_VALUE) = 0 Then

							notSupported = False
							offline = True

							Return 0

						Else

							notSupported = False
							offline = False

							fullStringRepresentation = fullStringRepresentation.Trim

							Dim length As Integer

							For i As Integer = 0 To fullStringRepresentation.Length - 1

								If Not IsNumeric(fullStringRepresentation(i)) Then

									length = i

									Exit For

								ElseIf i = fullStringRepresentation.Length - 1 Then

									length = i + 1

								End If

							Next

							Dim returnLong As Long

							If Long.TryParse(fullStringRepresentation.Substring(0, length), returnLong) Then _
						Return returnLong

						End If

					End If

				Catch ex As Exception

				End Try

				Return 0

			End Function

			Public Shared Function ParseIBMStringNumerical( _
				ByVal fullStringRepresentation As String, _
				ByVal unitStringRepresentation As String, _
				ByRef notSupported As Boolean, _
				ByRef offline As Boolean _
			) As Double

				Try

					If Not String.IsNullOrEmpty(fullStringRepresentation) Then

						If String.Compare(fullStringRepresentation, NOT_READABLE_VALUE) = 0 Then

							notSupported = True
							offline = False

							Return 0

						ElseIf String.Compare(fullStringRepresentation, OFFLINE_VALUE) = 0 Then

							notSupported = False
							offline = True

							Return 0

						Else

							notSupported = False
							offline = False

							fullStringRepresentation = fullStringRepresentation.Trim
							unitStringRepresentation = unitStringRepresentation.Trim()

							Dim isNegative As Boolean = False

							If String.Compare(fullStringRepresentation.Substring(0, 1), HYPHEN) = 0 Then

								isNegative = True
								fullStringRepresentation = fullStringRepresentation.TrimStart(HYPHEN)

							End If

							Dim numericalStringRepresentation As String = _
								fullStringRepresentation.Substring(0, fullStringRepresentation.Length - _
								(unitStringRepresentation.Length + 1)).Trim

							Dim returnLong As Double

							If Double.TryParse(numericalStringRepresentation, returnLong) Then

								If String.Compare(fullStringRepresentation.Substring(0, 1), HYPHEN) = 0 Then

									Return 0 - returnLong

								Else

									Return returnLong

								End If

							End If

						End If

					End If

					Catch ex As Exception

					End Try

				Return 0

			End Function

		#End Region

	End Class

End Namespace
