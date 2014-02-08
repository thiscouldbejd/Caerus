Namespace Cisco

    Public Class CiscoIPPhoneSoftKeyCollection

		#Region " Public Methods "

	        Public Overloads Sub Add( _
	            ByVal name As String, _
	            ByVal url As String, _
	            ByVal position As Short _
	        )
	            Add(New CiscoIPPhoneSoftKey(name, url, position))
	        End Sub
	
	        Public Overloads Sub Add( _
	            ByVal name As String, _
	            ByVal action As CiscoIPPhoneSoftKeyURI, _
	            ByVal position As Short _
	        )
	            Dim sk As New CiscoIPPhoneSoftKey(name, Nothing, position)
	            sk.SetAction(action)
	            Add(sk)
	        End Sub
	
	        Public Overloads Sub Remove( _
	            ByVal name As String, _
	            ByVal url As String, _
	            ByVal position As Short _
	        )
	            With Me
	                For i As Integer = 0 To .Count - 1
	                    If CType(.Item(i), CiscoIPPhoneSoftKey).Name = name AndAlso _
	                        CType(.Item(i), CiscoIPPhoneSoftKey).Url = url AndAlso _
	                        CType(.Item(i), CiscoIPPhoneSoftKey).Position = position Then
	                        RemoveAt(i)
	                        i -= 1
	                    End If
	                Next
	            End With
	            
	        End Sub
	
	        Public Overloads Sub Remove( _
	            ByVal name As String, _
	            ByVal action As CiscoIPPhoneSoftKeyURI, _
	            ByVal position As Short _
	        )
	            Dim sk As New CiscoIPPhoneSoftKey(name, Nothing, position)
	            sk.SetAction(action)
	            Remove(sk)
	        End Sub

		#End Region

    End Class

End Namespace