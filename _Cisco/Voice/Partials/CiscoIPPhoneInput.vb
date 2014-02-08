Namespace Cisco

    Partial Public Class CiscoIPPhoneInput

#Region " Public Methods "

        Public Sub AddInputItem( _
            ByVal item As CiscoIPPhoneInputItem _
        )
            InputItems.Add(item)
        End Sub

        Public Sub AddInputItem( _
            ByVal displayName As String, _
            ByVal queryStringParameter As String, _
            ByVal defaultValue As String, ByVal flags As CiscoIPPhoneInputItemFlags)
            Dim ii As New CiscoIPPhoneInputItem
            ii.DisplayName = displayName
            ii.QueryStringParamater = queryStringParameter
            ii.DefaultValue = defaultValue
            ii.SetInputFlags(flags)
            InputItems.Add(ii)
        End Sub

        Public Sub RemoveInputItem( _
            ByVal item As CiscoIPPhoneInputItem _
        )
            InputItems.Remove(item)
        End Sub

        Public Sub RemoveInputItem( _
            ByVal displayName As String, ByVal queryStringParameter As String, ByVal defaultValue As String, ByVal flags As CiscoIPPhoneInputItemFlags)
            Dim ii As New CiscoIPPhoneInputItem
            ii.DisplayName = displayName
            ii.QueryStringParamater = queryStringParameter
            ii.DefaultValue = defaultValue
            ii.SetInputFlags(flags)
            InputItems.Remove(ii)
        End Sub

        Public Sub ClearInputItems()
            InputItems.Clear()
        End Sub

#End Region

#Region " Rendering Methods "

        Protected Overrides Sub Render( _
            ByVal output As System.Web.UI.HtmlTextWriter _
        )
            output.WriteLine("<CiscoIPPhoneInput>")

            output.WriteLine("<Title>" & Title & "</Title>")

            output.WriteLine("<Prompt>" & Prompt & "</Prompt>")

            output.WriteLine("<URL>" & Url & "</URL>")

            For Each i As CiscoIPPhoneInputItem In InputItems
                i.RenderControl(output)
            Next

            For Each s As CiscoIPPhoneSoftKey In SoftKeys
                s.RenderControl(output)
            Next

            output.WriteLine("</CiscoIPPhoneInput>")
        End Sub

#End Region

    End Class

End Namespace