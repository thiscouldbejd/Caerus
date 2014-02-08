Imports Leviathan.Comparison.Comparer
Imports System.Text.ASCIIEncoding

Namespace Cisco

	Partial Public Class WirelessSpeeds

		#Region " Public Properties "

			Public ReadOnly Property HT() As String
				Get
					Return ToString("HT", Nothing)
				End Get
			End Property

		#End Region

		#Region " Public Shared Methods "

			Public Shared Function TryParse( _
				ByVal value As char(), _
				ByRef parsedObject As WirelessSpeeds _
			) As Boolean

				Dim returnValues As New ArrayList

				For i As Integer = 0 To value.Length - 1

					Dim numericalValue As Byte = ASCII.GetBytes(New Char() {value(i)})(0)

					Dim rateValue As Integer = 1 + ((numericalValue - 2) * 0.5)

					If Not returnValues.Contains(rateValue) Then returnValues.Add(rateValue)

				Next

				returnValues.Sort()

				parsedObject.Value = returnValues.ToArray(GetType(Integer))
				parsedObject.Max = returnValues(returnValues.Count - 1)

				Return True

			End Function

			Public Shared Function TryParse( _
				ByVal value As Byte(), _
				ByRef parsedObject As WirelessSpeeds _
			) As Boolean

				If Not value Is Nothing AndAlso value.Length = 2 Then

					If parsedObject Is Nothing Then parsedObject = New WirelessSpeeds()

					Dim returnValues As New ArrayList

					Dim nValue As Int16 = BitConverter.ToInt16(value, 0)

					Dim current_Value As Integer = 1
					Dim current_Speed As Integer = 0

					For i As Integer = 0 To 15

						If EnumContains(nValue, current_Value) Then returnValues.Add(current_Speed)

						current_Speed += 1
						current_Value = current_Value * 2

					Next

					returnValues.Sort()

					parsedObject.HT_Value = returnValues.ToArray(GetType(Integer))
					parsedObject.HT_Max = returnValues(returnValues.Count - 1)

					Return True

				End If

				Return False

			End Function

			Public Shared Function TryParse( _
				ByVal value As String, _
				ByRef parsedObject As WirelessSpeeds _
			) As Boolean

				If Not String.IsNullOrEmpty(value) Then

					If parsedObject Is Nothing Then parsedObject = New WirelessSpeeds()

					TryParse(value.ToCharArray, parsedObject)

					If value.Length = 2 Then

						Return TryParse(ASCII.GetBytes(value.ToCharArray), parsedObject)

					Else

						Return True

					End If

				Else

					Return False

				End If

			End Function

		#End Region

	End Class

End Namespace
