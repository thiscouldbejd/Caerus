Namespace Cisco

    Partial Public Class CiscoIPPhoneText

		#Region " Rendering Methods "

	        Protected Overrides Sub Render( _
	            ByVal output As System.Web.UI.HtmlTextWriter _
	        )
	            output.WriteLine("<CiscoIPPhoneText>")
	
	            output.WriteLine("<Title>" & Title & "</Title>")
	
	            output.WriteLine("<Prompt>" & Prompt & "</Prompt>")
	
	            output.WriteLine("<Text>" & Text & "</Text>")
	
	            For Each s As CiscoIPPhoneSoftKey In SoftKeys
	                s.RenderControl(output)
	            Next
	
	            output.WriteLine("</CiscoIPPhoneText>")
	        End Sub

		#End Region

    End Class

End Namespace