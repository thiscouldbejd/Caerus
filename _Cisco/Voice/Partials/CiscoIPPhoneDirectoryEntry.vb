Namespace Cisco

    Partial Public Class CiscoIPPhoneDirectoryEntry

		#Region " Public Properties "
		
			Public ReadOnly Property DisplayName As String
				Get
					If Not String.IsNullOrEmpty(Name) AndAlso Name.Length > 22 Then
						Return Name.Substring(0, 20) & ".."
					Else
						Return Name
					End If
				End Get
			End Property
		#End Region
		
		#Region " Rendering Methods "

	        Protected Overrides Sub Render( _
	            ByVal output As System.Web.UI.HtmlTextWriter _
	        )
	            output.WriteLine("<DirectoryEntry>")
	
	            output.WriteLine("<Name>" & DisplayName & "</Name>")
	
	            output.WriteLine("<Telephone>" & Telephone & "</Telephone>")
	
	            output.WriteLine("</DirectoryEntry>")
	        End Sub

		#End Region

    End Class

End Namespace