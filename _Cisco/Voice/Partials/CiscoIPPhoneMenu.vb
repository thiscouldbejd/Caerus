Namespace Cisco

    Partial Public Class CiscoIPPhoneMenu

		#Region " Public Properties "
		
			Public ReadOnly Property DisplayTitle As String
				Get
					If Not String.IsNullOrEmpty(Title) AndAlso Title.Length > 32 Then
						Return Title.Substring(0, 30) & ".."
					Else
						Return Title
					End If
				End Get
			End Property
		
			Public ReadOnly Property DisplayPrompt As String
				Get
					If Not String.IsNullOrEmpty(Prompt) AndAlso Prompt.Length > 32 Then
						Return Prompt.Substring(0, 30) & ".."
					Else
						Return Prompt
					End If
				End Get
			End Property
		
		#End Region
		
		#Region " Public Methods "

	        Public Sub AddMenuItem( _
	            ByVal item As CiscoIPPhoneMenuItem _
	        )
	            MenuItems.Add(item)
	        End Sub
	
	        Public Sub AddMenuItem( _
	            ByVal name As String, _
	            ByVal url As String _
	        )
	            Dim mi As New CiscoIPPhoneMenuItem
	            mi.Name = name
	            mi.Url = url
	            MenuItems.Add(mi)
	        End Sub
	
	        Public Sub RemoveMenuItem( _
	            ByVal item As CiscoIPPhoneMenuItem _
	        )
	            MenuItems.Remove(item)
	        End Sub
	
	        Public Sub RemoveMenuItem( _
	            ByVal name As String, _
	            ByVal url As String _
	        )
	            For i As Integer = 0 To m_MenuItems.Count - 1
	                If CType(MenuItems(i), CiscoIPPhoneMenuItem).Name = name AndAlso _
	                CType(MenuItems(i), CiscoIPPhoneMenuItem).Url = url Then
	                    MenuItems.RemoveAt(i)
	                    i -= 1
	                End If
	            Next
	        End Sub
	
	        Public Sub ClearMenuItems()
	            MenuItems.Clear()
	        End Sub

		#End Region

		#Region " Rendering Methods "

	        Protected Overrides Sub Render( _
	            ByVal output As System.Web.UI.HtmlTextWriter _
	        )
	            output.WriteLine("<CiscoIPPhoneMenu>")
	
	            output.Write("<Title>" & DisplayTitle & "</Title>")
	
	            output.WriteLine("<Prompt>" & DisplayTitle & "</Prompt>")
	
	            For Each m As CiscoIPPhoneMenuItem In MenuItems
	                m.RenderControl(output)
	            Next
	
	            For Each s As CiscoIPPhoneSoftKey In SoftKeys
	                s.RenderControl(output)
	            Next
	
	            output.WriteLine("</CiscoIPPhoneMenu>")
	        End Sub

		#End Region

    End Class

End Namespace