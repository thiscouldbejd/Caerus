Namespace Cisco

    Partial Public Class CiscoIPPhoneInputItem

		#Region " Public Methods "

	        Public Sub SetInputFlags( _
	            ByVal flags As CiscoIPPhoneInputItemFlags _
	        )
	            Select Case flags
	                Case CiscoIPPhoneInputItemFlags.AlphaNumeric
	                    Me.InputFlags = "A"
	                Case CiscoIPPhoneInputItemFlags.LowerCaseAlpha
	                    Me.InputFlags = "L"
	                Case CiscoIPPhoneInputItemFlags.Nothing
	                    Me.InputFlags = String.Empty
	                Case CiscoIPPhoneInputItemFlags.Numeric
	                    Me.InputFlags = "N"
	                Case CiscoIPPhoneInputItemFlags.UpperCaseAlpha
	                    Me.InputFlags = "U"
	            End Select
	        End Sub

		#End Region

		#Region " Rendering Methods "

	        Protected Overrides Sub Render( _
	            ByVal output As System.Web.UI.HtmlTextWriter _
	        )
	
	            output.WriteLine("<InputItem>")
	
	            output.WriteLine("<DisplayName>" & DisplayName & "</DisplayName>")
	
	            output.WriteLine("<QueryStringParam>" & QueryStringParamater & "</QueryStringParam>")
	
	            output.WriteLine("<InputFlags>" & InputFlags & "</InputFlags>")
	
	            If Not DefaultValue = Nothing Then
	                output.WriteLine("<DefaultValue>" & DefaultValue & "</DefaultValue>")
	            End If
	
	            output.WriteLine("</InputItem>")
	
	        End Sub

		#End Region

    End Class

End Namespace