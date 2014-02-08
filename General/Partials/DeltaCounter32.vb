Partial Public Class DeltaCounter32

	#Region " Private Constants "

		Private Const MAX_VALUE As Double = 4294967295

		Private Const ROUNDING_FIGURES As Int32 = 4

	#End Region

	#Region " Public Properties "

		Public WriteOnly Property Value() As System.Int64
			Set(ByVal value As System.Int64)

				If value < m_CurrentValue Then m_CurrentValue -= MAX_VALUE ' Counter must have rolled Over.

				m_LastValueSet = m_CurrentValueSet
				m_LastValue = m_CurrentValue

				m_CurrentValueSet = Now
				m_CurrentValue = value

			End Set
		End Property

		Public ReadOnly Property ValueDelta() As Double
			Get
				Return m_CurrentValue - m_LastValue
			End Get
		End Property

		Public ReadOnly Property DeltaInSec() As Double
			Get
				If Not m_LastValueSet = Nothing Then

					Return m_CurrentValueSet.Subtract(m_LastValueSet).TotalSeconds

				Else

					Return 0

				End If
			End Get
		End Property

		Public ReadOnly Property ValueDeltaInSec() As Double
			Get
				If Not m_LastValueSet = Nothing Then

					Return Math.Round((m_CurrentValue - m_LastValue) / DeltaInSec, ROUNDING_FIGURES)

				Else

					Return 0

				End If
			End Get
		End Property

		Public ReadOnly Property DeltaInMSec() As Double
			Get
				If Not m_LastValueSet = Nothing Then

					Return m_CurrentValueSet.Subtract(m_LastValueSet).TotalMilliseconds

				Else

					Return 0

				End If
			End Get
		End Property

		Public ReadOnly Property ValueDeltaInMSec() As Double
			Get
				If Not m_LastValueSet = Nothing Then

					Return Math.Round((m_CurrentValue - m_LastValue) / DeltaInMSec, ROUNDING_FIGURES)

				Else

					Return 0

				End If
			End Get
		End Property

	#End Region

	#Region " Public Methods "

		Public Overrides Function ToString() As String

			Return PercentageValue.FormatPercentage(CurrentValue)

		End Function

	#End Region

	#Region " Public Shared Methods "

		Public Shared Function GetProportionalUsage( _
			ByVal proportionToGet As DeltaCounter32, _
			ByVal ParamArray otherProportions As DeltaCounter32() _
		) As PercentageValue

			Dim proportion_Delta As Double = proportionToGet.ValueDelta

			If proportion_Delta = 0 Then

				Return New PercentageValue()

			Else

				Dim total_Delta As Double = proportion_Delta

				For i As Integer = 0 To otherProportions.Length - 1

					total_Delta += otherProportions(i).ValueDelta

				Next

				Return New PercentageValue(proportion_Delta / total_Delta)

			End If

		End Function

		Public Shared Function GetBandwidthUsage( _
			ByVal usageUnicastPacketSource As DeltaCounter32, _
			ByVal usageBroadcastPacketSource As DeltaCounter32, _
			ByVal usageMulticastPacketSource As DeltaCounter32, _
			ByVal usageOctetSource As DeltaCounter32, _
			ByVal speed As InterfaceSpeed _
		) As PercentageValue

			Dim delta_Packets As Double = usageUnicastPacketSource.ValueDelta + _
				usageBroadcastPacketSource.ValueDelta + usageMulticastPacketSource.ValueDelta

			Dim delta_Octets As Double = usageOctetSource.ValueDelta

			Dim delta_Time As Double = (usageUnicastPacketSource.DeltaInSec + usageBroadcastPacketSource.DeltaInSec + _
				usageMulticastPacketSource.DeltaInSec + usageOctetSource.DeltaInSec) / 4

			Dim retVal As Single = 0

			If (delta_Packets > 0 OrElse delta_Octets > 0) AndAlso delta_Time > 0 Then

				' 96 is the number of bit times (minimum) for the interframe gap. 64 is
				' the number of bits in the preamble + SFD. (The octet count doesn't
				' include these, so we have to add them in for each packet.)
				' 8 is the number of bits in each octet.
				retVal = ((delta_Packets * (96 + 64)) + (delta_Octets * 8)) / (delta_Time * speed.Value)

			End If

			Return New PercentageValue(retVal)

		End Function

		Public Shared Function FormatBoundariedNumber( _
			ByVal number As Long, _
			ByVal boundaries As Long(), _
			ByVal labelBoundaries As String() _
		) As String

			For i As Integer = 0 To boundaries.Length - 1

				If number >= boundaries(i) Then _
					Return (Math.Floor(number / boundaries(i))).ToString & labelBoundaries(i)

			Next

			Return "0"

		End Function

	#End Region

End Class
