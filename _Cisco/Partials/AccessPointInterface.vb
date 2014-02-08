Namespace Cisco

	Partial Public Class AccessPointInterface

		#Region " Public Properties "

			Public ReadOnly Property TotalAssociations As System.Int64
				Get
					Return Clients + Bridges + Repeaters
				End Get
			End Property

			Public ReadOnly Property SsidList As String
				Get
					Return StringCommands.ObjectToSingleString(Ssids, PIPE)
				End Get
			End Property

			''' <summary>
			''' Current Operating Frequency
			''' </summary>
			''' <value></value>
			''' <returns></returns>
			''' <remarks></remarks>
			Public ReadOnly Property CurrentFrequency() As String
				Get
					Dim l_CurrentBand As FrequencyBand = CurrentBand

					If Not l_CurrentBand Is Nothing AndAlso Not l_CurrentBand.Units = FrequencyUnits.NONE Then
						Return (l_CurrentBand.StartFrequency + _
							((Channel - l_CurrentBand.StartChannel) * l_CurrentBand.FrequencySpacing)).ToString & _
								l_CurrentBand.Units.ToString.ToLower
					Else
						Return String.Empty
					End If
				End Get
			End Property

			''' <summary>
			''' Current Operating Frequency Band
			''' </summary>
			''' <value></value>
			''' <returns></returns>
			''' <remarks></remarks>
			Public ReadOnly Property CurrentBand() As FrequencyBand
				Get
					If Not Bands Is Nothing AndAlso Bands.Count >= 1 Then
						For i As Integer = 0 To Bands.Count - 1

							If Channel >= Bands(i).StartChannel AndAlso Channel <= Bands(i).EndChannel Then _
								Return Bands(i)

						Next
					End If

					Return Nothing
				End Get
			End Property

			Public ReadOnly Property MaxAssociations() As Integer
				Get
					Dim l_maxAssociations As Integer = 0

					If Not Ssids Is Nothing Then

						For i As Integer = 0 To Ssids.Count - 1

							l_maxAssociations += Ssids(i).MaxAssociations

						Next

					End If

					Return l_maxAssociations

				End Get
			End Property

			Public ReadOnly Property DisplayPower_Summary() As String
				Get
					If CurrentPowerLevel_Client < CurrentPowerLevel AndAlso _
						CurrentPowerLevel_Client > 0 Then
						Return DisplayPower_Client & "*"
					Else
						Return DisplayPower
					End If
				End Get
			End Property

			Public ReadOnly Property DisplayPower() As String
				Get
					Dim percentage As Single

					If PowerLevels > 0 AndAlso _
						CurrentPowerLevel > 0 Then

						percentage = Math.Round((CurrentPowerLevel / PowerLevels) * 100, 0)

					Else

						percentage = 0

					End If

					Return percentage & PERCENTAGE_MARK

				End Get
			End Property

			Public ReadOnly Property DisplayPower_Client() As String
				Get
					Dim percentage As Single

					If PowerLevels > 0 AndAlso _
						CurrentPowerLevel_Client > 0 Then

						percentage = Math.Round((CurrentPowerLevel_Client / PowerLevels_Client) * 100, 0)

					Else

						percentage = 0

					End If

					Return percentage & PERCENTAGE_MARK

				End Get
			End Property

		#End Region

	End Class

End Namespace
