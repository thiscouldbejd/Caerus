Namespace Cisco

    Partial Public Class CiscoIPPhoneSoftKey

		#Region " Public Methods "

	        Public Sub SetAction( _
	            ByVal action As CiscoIPPhoneSoftKeyURI _
	        )
	            Select Case action
	                Case CiscoIPPhoneSoftKeyURI.Back
	                    Url = "SoftKey:<<"
	                Case CiscoIPPhoneSoftKeyURI.Cancel
	                    Url = "SoftKey:Cancel"
	                Case CiscoIPPhoneSoftKeyURI.Dial
	                    Url = "SoftKey:Dial"
	                Case CiscoIPPhoneSoftKeyURI.EditDial
	                    Url = "SoftKey:EditDial"
	                Case CiscoIPPhoneSoftKeyURI.Exit
	                    Url = "SoftKey:Exit"
	                Case CiscoIPPhoneSoftKeyURI.Forward
	                    Url = "SoftKey:>>"
	                Case CiscoIPPhoneSoftKeyURI.Nothing
	                    Url = String.Empty
	                Case CiscoIPPhoneSoftKeyURI.Select
	                    Url = "SoftKey:Select"
	                Case CiscoIPPhoneSoftKeyURI.Submit
	                    Url = "SoftKey:Submit"
	                Case CiscoIPPhoneSoftKeyURI.Update
	                    Url = "SoftKey:Update"
	            End Select
	        End Sub

		#End Region

		#Region " Rendering Methods "

	        Protected Overrides Sub Render( _
	            ByVal output As System.Web.UI.HtmlTextWriter _
	        )
	            output.WriteLine("<SoftKeyItem>")
	
	            output.WriteLine("<Position>" & Position.ToString & "</Position>")
	
	            output.WriteLine("<Name>" & Name & "</Name>")
	
	            output.WriteLine("<URL>" & Url & "</URL>")
	
	            output.WriteLine("</SoftKeyItem>")
	        End Sub

		#End Region

    End Class

End Namespace