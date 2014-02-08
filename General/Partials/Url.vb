Imports System.Text
Imports System.Web

Public Class Url
    Implements ICloneable

#Region " Public Constants "

    ''' <summary></summary>				
    Public Const QUERY_START As String = "?"

    ''' <summary></summary>				
    Public Const QUERY_DELINEATOR As String = "&"

    ''' <summary></summary>				
    Public Const QUERY_OPERATOR As String = "="

    ''' <summary></summary>				
    Public Const PATH_DELINEATOR As String = "/"

    ''' <summary></summary>				
    Public Const BOOKMARK_DELINEATOR As String = "#"

#End Region

#Region " Private Variables "

    ' This stops the Web Tree View Query Strings screwing things up!
    Private REMOVED_QUERYVARIABLES As String() = New String() {"_wtv"}

#End Region

#Region " Public Constructors "

    Public Sub New( _
        ByVal context As HttpContext _
    )
        RawUrl = context.Request.RawUrl
    End Sub

    Public Sub New( _
        ByVal context As HttpContext, _
        ByVal ParamArray updateParameters As DictionaryEntry() _
    )
        RawUrl = context.Request.RawUrl
        Me.AddOrUpdateQueryStringParameters(updateParameters)
    End Sub

    Public Sub New( _
        ByVal url As String, _
        ByVal ParamArray updateParameters As DictionaryEntry() _
    )
        RawUrl = url
        Me.AddOrUpdateQueryStringParameters(updateParameters)
    End Sub

#End Region

#Region " Public ReadOnly Properties "

    Public ReadOnly Property Full() As String
        Get
            Return BuildUrl(BaseUrl)
        End Get
    End Property

    Public ReadOnly Property Relative() As String
        Get
            Return BuildUrl(RelativeUrl)
        End Get
    End Property

#End Region

#Region " Public WriteOnly Properties "

    Public WriteOnly Property RawUrl() As String
        Set(ByVal value As String)
            Me.Queries.Clear()

            If value.Contains(QUERY_START) Then
                BaseUrl = value.Split(QUERY_START)(0)
            Else
                BaseUrl = value
            End If

            If BaseUrl.Contains(PATH_DELINEATOR) Then
                RelativeUrl = BaseUrl.Split(PATH_DELINEATOR)(BaseUrl.Split(PATH_DELINEATOR).Length - 1)
            Else
                RelativeUrl = BaseUrl
            End If

            If value.Contains(QUERY_START) Then
                Dim queries As String() = value.Split(QUERY_START)(1).Split(QUERY_DELINEATOR)
                If Not queries Is Nothing AndAlso queries.Length > 0 Then

                    For Each query As String In queries
                        Dim query_field As String = query.Split(QUERY_OPERATOR)(0)
                        Dim query_value As String = query.Split(QUERY_OPERATOR)(1)

                        Dim ignoreQueryField As Boolean = False

                        For i As Integer = 0 To REMOVED_QUERYVARIABLES.Length - 1
                            If query_field.ToLower.StartsWith(REMOVED_QUERYVARIABLES(i)) Then
                                ignoreQueryField = True
                                Exit For
                            End If
                        Next

                        If Not ignoreQueryField Then
                            If Me.Queries.Contains(query_field) Then
                                Me.Queries(query_field) = query_value
                            Else
                                Me.Queries.Add(query_field, query_value)
                            End If
                        End If
                    Next
                End If
            End If

        End Set
    End Property

#End Region

#Region " Private Methods "

    Private Function BuildUrl( _
        ByVal urlBase As String _
    ) As String

        Dim sb As New StringBuilder

        sb.Append(urlBase)

        AddQueries(sb)

        If Not Bookmark = Nothing AndAlso Bookmark.Length > 0 Then
            If Not Bookmark.StartsWith(BOOKMARK_DELINEATOR) Then sb.Append(BOOKMARK_DELINEATOR)
            sb.Append(Bookmark.TrimEnd)
        End If

        Return sb.ToString

    End Function

    Private Sub AddQueries( _
        ByRef sb As StringBuilder _
    )

        If Queries.Count > 0 Then
            sb.Append(QUERY_START)

            For Each dict As DictionaryEntry In Queries
                sb.Append(dict.Key)
                sb.Append(QUERY_OPERATOR)
                sb.Append(dict.Value)
                sb.Append(QUERY_DELINEATOR)
            Next

            sb.Remove(sb.Length - 1, 1)
        End If

    End Sub

#End Region

#Region " Public Methods "

    Public Sub AddOrUpdateQueryStringParameters( _
        ByVal ParamArray parametersAndValues As DictionaryEntry() _
    )

        If Not parametersAndValues Is Nothing AndAlso parametersAndValues.Length > 0 Then
            For i As Integer = 0 To parametersAndValues.Length - 1
                If Queries.Contains(parametersAndValues(i).Key) Then
                    Queries.Item(parametersAndValues(i).Key) = parametersAndValues(i).Value
                Else
                    Queries.Add(parametersAndValues(i).Key, parametersAndValues(i).Value)
                End If
            Next
        End If

    End Sub

    Public Sub AddOrUpdateQueryStringParameter( _
        ByVal parameter As String, _
        ByVal value As String _
    )

        If Queries.Contains(parameter) Then

            Queries.Item(parameter) = value

        Else

            Queries.Add(parameter, value)

        End If

    End Sub

    Public Sub RemoveQueryStringParameter( _
        ByVal parameter As String _
    )

        If Queries.Contains(parameter) Then Queries.Remove(parameter)

    End Sub

    Public Sub ClearQueryStringParameters()

        Queries.Clear()

    End Sub

    Public Sub ChangePage( _
        ByVal newPage As String _
    )

        If Not newPage = Nothing AndAlso newPage.Length > 0 Then

            RelativeUrl = ChangePage(RelativeUrl, newPage)
            BaseUrl = ChangePage(BaseUrl, newPage)

        End If

    End Sub

    Public Sub TransferToPage( _
        ByRef context As HttpContext _
    )

        context.Server.Transfer(Me.ToString)

    End Sub

    Public Sub RedirectToPage( _
        ByVal context As HttpContext _
    )

        context.Response.Redirect(Me.ToString, True)

    End Sub

    Public Overrides Function ToString() As String

        Return Relative

    End Function

#End Region

#Region " Private Shared Methods "

    Private Shared Function ChangePage( _
        ByVal url As String, _
        ByVal newPage As String _
    ) As String

        Dim parts() As String = url.Split(PATH_DELINEATOR)
        Dim oldPage As String = parts(parts.Length - 1)

        Dim pos As String = url.LastIndexOf(oldPage)

        url = url.Remove(pos, oldPage.Length)
        url = url.Insert(pos, newPage)

        Return url

    End Function

#End Region

#Region " Public Shared Methods "

    Public Shared Function BuildSimpleUrl( _
        ByVal basePage As String, _
        ByVal ParamArray parameters() As DictionaryEntry _
    ) As String

        If parameters Is Nothing OrElse parameters.Length = 0 Then

            Return basePage

        ElseIf parameters.Length = 1 Then

            Return basePage & QUERY_START & parameters(0).Key & QUERY_OPERATOR & parameters(0).Value

        Else

            Dim sb As New System.Text.StringBuilder()

            sb.Append(basePage)
            sb.Append(QUERY_START)

            For i As Integer = 0 To parameters.Length - 1

                sb.Append(parameters(i).Key)
                sb.Append(QUERY_OPERATOR)
                sb.Append(parameters(i).Value)
                If Not i = parameters.Length - 1 Then sb.Append(QUERY_DELINEATOR)

            Next

            Return sb.ToString

        End If

    End Function

    Public Shared Function BuildSimpleUrl( _
        ByVal basePage As String, _
        ByVal bookmark As String, _
        ByVal ParamArray parameters() As DictionaryEntry _
    ) As String

        Return BuildSimpleUrl(basePage, parameters) & BOOKMARK_DELINEATOR & bookmark

    End Function

    Public Shared Function GetNewUrl( _
        ByVal context As HttpContext, _
        ByVal page As String _
    ) As String

        Dim currentUrl As Uri = context.Request.Url
        Dim baseUrl As String = currentUrl.AbsoluteUri.Substring(0, currentUrl.AbsoluteUri.LastIndexOf("/"))
        If baseUrl.EndsWith(PATH_DELINEATOR) Then

            Return baseUrl & page

        Else

            If page.StartsWith(PATH_DELINEATOR) Then
                Return baseUrl & page
            Else
                Return baseUrl & PATH_DELINEATOR & page
            End If

        End If

    End Function

    Public Shared Function GetCurrentPage( _
        ByVal context As HttpContext _
    ) As String

        Dim currentUrl As Uri = context.Request.Url
        Return currentUrl.LocalPath.Substring(currentUrl.LocalPath.LastIndexOf(PATH_DELINEATOR))

    End Function

#End Region

#Region " ICloneable Implementation "

    Public Function Clone() As Object Implements System.ICloneable.Clone

        Dim cln As New Url()

        cln.BaseUrl = BaseUrl.Clone
        cln.RelativeUrl = RelativeUrl.Clone
        cln.Bookmark = Bookmark.Clone

        For Each dict As DictionaryEntry In Queries

            cln.Queries.Add(dict.Key.ToString.Clone, dict.Value.ToString.Clone)

        Next

        Return cln

    End Function
#End Region

End Class