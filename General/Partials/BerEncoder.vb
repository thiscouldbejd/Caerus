Imports System.Text.Encoding

Public Class BerEncoder

	#Region " Public Shared Methods "

		Private Shared Function EncodeBerLength( _
			ByVal bytes As Byte() _
		) As Byte()

			Dim bytesLength As Byte() = EncodeBerLength(bytes.Length)

			Dim newBytes(bytes.Length + (bytesLength.Length - 1)) As Byte

			Array.Copy(bytes, 0, newBytes, bytesLength.Length, bytes.Length)

			For i As Integer = 0 To bytesLength.Length - 1
				newBytes(i) = bytesLength(i)
			Next

			Return newBytes

		End Function

		Private Shared Function EncodeBerLength( _
			ByVal bytes As ArrayList _
		) As Byte()

			bytes.InsertRange(0, EncodeBerLength(bytes.Count))

			Return bytes.ToArray(GetType(Byte))

		End Function

	#End Region

	#Region " Public Shared Methods "

		Public Shared Function EncodeBerLength( _
			ByVal length As Integer _
		) As Byte()

			Dim bytes As New ArrayList()

			bytes.Add(CByte((length And &HFF)))

			length = (length >> 8)
			Do While (length <> 0)
				bytes.Add(CByte((length And &HFF)))
				length = (length >> 8)
			Loop

			If (bytes.Count > 1) Then bytes.Insert(0, CByte((bytes.Count Or &H80)))

			Return bytes.ToArray(GetType(Byte))

		End Function

		Public Shared Function EncodeBerInteger( _
			ByVal value As Long _
		) As Byte()

			Dim bytes As New ArrayList

			Do
				bytes.Insert(0, CByte((value And &HFF)))
				value = (value >> 8)
			Loop While (value <> 0)

			Return EncodeBerLength(bytes)

		End Function

		Public Shared Function EncodeBerString( _
			ByVal value As String _
		) As Byte()

			Dim bytes As New ArrayList

			bytes.AddRange(ASCII.GetBytes(value))

			Return EncodeBerLength(bytes)

		End Function

		Public Shared Function EncodeBerIpAddress( _
			ByVal value As IPAddress _
		) As Byte()

			Return EncodeBerLength(value.GetAddressBytes())

		End Function

		Public Shared Function EncodeBerObjectID( _
			ByVal value As String _
		) As Byte()

			If value.StartsWith("1.") Then value = ("4" & value.Substring(2))
			'If value.StartsWith("1.3") Then value = ("43" & value.Substring(3))

			Dim bytes As New ArrayList

			Dim values As String() = value.Split(New Char() {"."c})
			Dim length As Integer = 0

			For i As Integer = 0 To values.Length - 1
				If Not String.IsNullOrEmpty(values(i)) Then
					Dim val As Integer = Integer.Parse(values(i))
					bytes.Insert(length, CByte((val And &H7F)))
					val = (val >> 7)
					Do While (val <> 0)
						bytes.Insert(length, CByte(((val And &H7F) Or &H80)))
						val = (val >> 7)
					Loop
					length = bytes.Count
				End If
			Next

			Return EncodeBerLength(bytes)

		End Function

		Public Shared Function EncodeBerNull() As Byte()

			Return New Byte() {0}

		End Function

	#End Region

End Class
