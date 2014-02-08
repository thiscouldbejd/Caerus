Imports System.Text.Encoding

Public Class BerDecoder

	#Region " Public Shared Methods "

		Public Shared Function CheckBerType( _
			ByVal packet As Byte(), _
			ByRef currentIndex As Integer, _
			ByVal expectedType As Integer _
		) As Boolean

			If packet(currentIndex) = expectedType Then
				currentIndex += 1
				Return True
			Else
				Return False
			End If

		End Function

		Public Shared Function DecodeBerLength( _
			ByVal packet As Byte(), _
			ByRef currentIndex As Integer _
		) As Integer

			Dim currentLength As Integer = packet(currentIndex)
			currentIndex += 1

			If currentLength > 128 Then

				Dim extensionLength As Integer = currentLength And 127

				currentLength = 0

				For i As Integer = 0 To extensionLength - 1
					currentLength = ((currentLength << 8) + packet(currentIndex))
					currentIndex += 1
				Next

			End If

			Return currentLength

		End Function

		Public Shared Function DecodeBerInt32( _
			ByVal integerLength As Integer, _
			ByVal packet As Byte(), _
			ByRef currentIndex As Integer _
		) As Int32

			Dim value As Int32 = 0
			Dim i As Integer
			For i = 0 To integerLength - 1
				value = ((value << 8) Or (packet(currentIndex) And &HFF))
				currentIndex += 1
			Next i
			Return value

		End Function

		Public Shared Function DecodeBerInteger( _
			ByVal integerLength As Integer, _
			ByVal packet As Byte(), _
			ByRef currentIndex As Integer _
		) As Long

			Dim value As Long = 0
			Dim i As Integer
			For i = 0 To integerLength - 1
				value = ((value << 8) + packet(currentIndex))
				currentIndex += 1
			Next i
			Return value

		End Function

		Public Shared Sub DecodeBerNull( _
			ByVal packet As Byte(), _
			ByRef currentIndex As Integer _
		)

			currentIndex += 1

		End Sub

		Public Shared Function DecodeBerBitString( _
			ByVal stringLength As Integer, _
			ByVal packet As Byte(), _
			ByRef currentIndex As Integer _
		) As String

			Dim Result As String = _
				New String(System.Text.Encoding.UTF8.GetChars(packet, currentIndex, stringLength))

			currentIndex = (currentIndex + stringLength)

			Return Result

		End Function

		Public Shared Function DecodeBerOctetString( _
			ByVal stringLength As Integer, _
			ByVal packet As Byte(), _
			ByRef currentIndex As Integer _
		) As String

			Dim Result As New System.Text.StringBuilder

			Dim endIndex As Integer = currentIndex + stringLength

			Do Until currentIndex = endIndex

				Result.Append(packet(currentIndex).ToString("d"))

				currentIndex += 1

				If Not currentIndex = endIndex Then Result.Append(FULL_STOP)

			Loop

			Return Result.ToString

		End Function

		Public Shared Function DecodeBerOctetString( _
			ByVal stringLength As Integer, _
			ByVal packet As Byte(), _
			ByRef currentIndex As Integer, _
			ByVal type As System.Type _
		) As Object

			If type Is GetType(PhysicalAddress) _
				AndAlso stringLength = 6 Then

				Dim address_Bytes(5) As Byte
				Array.Copy(packet, currentIndex, address_Bytes, 0, 6)

				currentIndex += stringLength
				Return New PhysicalAddress(address_Bytes)

			ElseIf type Is GetType(DateTime) _
				AndAlso (stringLength = 8 OrElse stringLength = 11) Then

				Dim startIndex As Integer = currentIndex
				currentIndex += stringLength

				Return New DateTime( _
					(packet(startIndex) * 256) + packet(startIndex + 1), _
					packet(startIndex + 2), _
					packet(startIndex + 3), _
					packet(startIndex + 4), _
					packet(startIndex + 5), _
					packet(startIndex + 6), _
					packet(startIndex + 7) * 100 _
				)

			ElseIf type.IsEnum Then

				Return DecodeBerOctetString(stringLength, packet, currentIndex)

			ElseIf type Is GetType(Cisco.WirelessSpeeds) AndAlso stringLength = 2 Then

				Dim ret_Object As Cisco.WirelessSpeeds = Nothing
				Cisco.WirelessSpeeds.TryParse(New Byte() {packet(currentIndex), packet(currentIndex + 1)}, ret_Object)
				currentIndex = (currentIndex + stringLength)
				Return ret_Object

			Else

				Return DecodeBerString(stringLength, packet, currentIndex)

			End If

		End Function

		Public Shared Function DecodeBerString( _
			ByVal stringLength As Integer, _
			ByVal packet As Byte(), _
			ByRef currentIndex As Integer _
		) As String

			Dim actualLength As Integer = stringLength

			Do Until actualLength = 0

				If packet((currentIndex + actualLength) - 1) = 0 Then
					actualLength -= 1
				Else
					Exit Do
				End If

			Loop

			Dim Result As String = ASCII.GetString(packet, currentIndex, actualLength)

			currentIndex = (currentIndex + stringLength)

			Return Result

		End Function

		Public Shared Function DecodeBerObjectID( _
			ByVal objectIdLength As Integer, _
			ByVal packet As Byte(), _
			ByRef currentIndex As Integer _
		) As String

			Dim result As String = String.Empty

			For i As Integer = currentIndex To (currentIndex + objectIdLength) - 1

				Dim Val As Integer = 0

				Do While True
					Dim V As Integer = packet(i)
					Val = ((Val << 7) + (V And &H7F))
					If (V <= &H7F) Then Exit Do

					i += 1
				Loop

				If (result <> String.Empty) Then result = (result & ".")
				result = (result & Val)
			Next i

			currentIndex = (currentIndex + objectIdLength)

			If result.StartsWith("43") Then result = ("1.3" & result.Substring(2))

			Return result

		End Function

		Public Shared Function DecodeBerBinary( _
			ByVal binaryLength As Integer, _
			ByVal packet As Byte(), _
			ByRef currentIndex As Integer _
		) As String

			Dim result As String = BitConverter.ToString(packet, currentIndex, binaryLength)
			currentIndex = (currentIndex + binaryLength)

			Return result

		End Function

		Public Shared Function DecodeBerIpAddress( _
			ByVal ipAddressLength As Integer, _
			ByVal packet As Byte(), _
			ByRef currentIndex As Integer _
		) As IPAddress

			Dim result As String = String.Empty
			For i As Integer = 0 To ipAddressLength - 1
				If (result <> String.Empty) Then
					result = (result & ".")
				End If
				result = (result & packet(currentIndex))
				currentIndex += 1
			Next i

			Return IPAddress.Parse(result)

		End Function

	#End Region

End Class
