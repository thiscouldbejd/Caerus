Namespace Cisco

    Partial Public Class CiscoIPPhoneMenuItem

		#Region " Rendering Methods "

	        Protected Overrides Sub Render( _
	            ByVal output As System.Web.UI.HtmlTextWriter _
	        )
	            output.WriteLine("<MenuItem>")
	
	            output.WriteLine("<Name>" & Name & "</Name>")
	
	            output.WriteLine("<URL>" & Url & "</URL>")
	
	            output.WriteLine("</MenuItem>")
	        End Sub

		#End Region

    End Class

End Namespace