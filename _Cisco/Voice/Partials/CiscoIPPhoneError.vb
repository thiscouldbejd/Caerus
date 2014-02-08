Imports System.ComponentModel
Imports System.Web.UI

Namespace Cisco

    Partial Public Class CiscoIPPhoneError

		#Region " Rendering Methods "

	        Protected Overrides Sub Render( _
	            ByVal output As System.Web.UI.HtmlTextWriter _
	        )
	
	            Select Case [Error]
	
	                Case CiscoIPPhoneErrorCodes.AuthenticationError
	                    output.WriteLine("<CiscoIPPhoneError Number=""4"" />")
	
	                Case CiscoIPPhoneErrorCodes.CiscoIPPhoneExecuteParsingError
	                    output.WriteLine("<CiscoIPPhoneError Number=""1"" />")
	
	                Case CiscoIPPhoneErrorCodes.CiscoIPPhoneResponseResponseFramingError
	                    output.WriteLine("<CiscoIPPhoneError Number=""2"" />")
	
	                Case CiscoIPPhoneErrorCodes.InternalError
	                    output.WriteLine("<CiscoIPPhoneError Number=""3"" />")
	
	            End Select
	
	        End Sub

		#End Region

    End Class

End Namespace

