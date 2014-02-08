Namespace Cisco

    Public Class CiscoIPPhoneDirectory
        
		#Region " Public Methods "

	        Public Sub AddDirectoryEntry( _
	            ByVal item As CiscoIPPhoneDirectoryEntry _
	        )
	            DirectoryEntries.Add(item)
	        End Sub
	
	        Public Sub AddDirectoryEntry( _
	            ByVal name As String, _
	            ByVal telephone As String _
	        )
	            Dim de As New CiscoIPPhoneDirectoryEntry
	            de.Name = name
	            de.Telephone = telephone
	            DirectoryEntries.Add(de)
	        End Sub
	
	        Public Sub RemoveDirectoryEntry( _
	            ByVal item As CiscoIPPhoneDirectoryEntry _
	        )
	            DirectoryEntries.Remove(item)
	        End Sub
	
	        Public Sub RemoveDirectoryEntry( _
	            ByVal name As String, _
	            ByVal telephone As String _
	        )
	            Dim de As New CiscoIPPhoneDirectoryEntry
	            de.Name = name
	            de.Telephone = telephone
	            DirectoryEntries.Remove(de)
	        End Sub
	
	        Public Sub ClearDirectoryEntries()
	            DirectoryEntries.Clear()
	        End Sub

		#End Region

		#Region " Rendering Methods "

	        Protected Overrides Sub Render( _
	            ByVal output As System.Web.UI.HtmlTextWriter _
	        )
	            output.WriteLine("<CiscoIPPhoneDirectory>")
	
	            output.WriteLine("<Title>" & Title & "</Title>")
	
	            output.WriteLine("<Prompt>" & Prompt & "</Prompt>")
	
	            For Each d As CiscoIPPhoneDirectoryEntry In DirectoryEntries
	                d.RenderControl(output)
	            Next
	
	            For Each s As CiscoIPPhoneSoftKey In SoftKeys
	                s.RenderControl(output)
	            Next
	
	            output.WriteLine("</CiscoIPPhoneDirectory>")
	        End Sub

		#End Region

    End Class

End Namespace