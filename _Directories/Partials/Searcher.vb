Namespace Directories

    ''' <summary>
    ''' This Class Provides Simplified Methods for Searching Directory Services.
    ''' </summary>
    ''' <remarks></remarks>
    Public NotInheritable Class Searcher
    	
#Region " Private Constructors "

        ''' <summary>
        ''' Private Constructor to Ensure this Class Cannot be directly instantiated.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub New()
        End Sub

#End Region

#Region " Private Shared Methods "

        ''' <summary>
        ''' Private Method to Prepare a Searcher with a Search Scope.
        ''' </summary>
        ''' <param name="searcher">The Search to Prepare.</param>
        ''' <param name="scope"></param>
        ''' <remarks></remarks>
        Private Shared Sub PrepareSearchScope( _
            ByRef searcher As DirectorySearcher, _
            ByVal scope As SearchScope _
        )
            Select Case scope
                Case SearchScope.Base
                    searcher.SearchScope = DirectoryServices.SearchScope.Base
                Case SearchScope.OneLevel
                    searcher.SearchScope = DirectoryServices.SearchScope.OneLevel
                Case SearchScope.SubTree
                    searcher.SearchScope = DirectoryServices.SearchScope.Subtree
            End Select
        End Sub

#End Region

#Region " Public Shared Methods "

        ''' <summary>
        ''' Public Searching Method which will return an array of DirectoryEntry Objects.
        ''' </summary>
        ''' <param name="connection">The connection to use for the Search.</param>
        ''' <param name="scope">The scope of the Search.</param>
        ''' <param name="parameter">The parameter to filter the Search Results.</param>
        ''' <param name="strongTypes">A Boolean Parameter indicating whether generic (False) or
        ''' strongly-typed (True) Directory Entries should be returned.</param>
        ''' <param name="sortProperty">The Property to Sort the Return Object by.</param>
        ''' <returns>An Array of DirectoryEntry Objects or Strongly-Typed Objects
        ''' dervied from DirectoryEntry.</returns>
        ''' <remarks></remarks>
        Public Shared Function ExecuteQuery( _
            ByVal connection As IConnection, _
            ByVal scope As SearchScope, _
            ByVal parameter As Parameter, _
            ByVal strongTypes As Boolean, _
            Optional ByVal sortProperty As String = Nothing _
        ) As DirectoryEntry()
            Try
                Dim results As New ArrayList

                Dim adSearcher As New DirectorySearcher(connection.Root, parameter.ToString)

                If Not sortProperty = Nothing Then
                    Dim srt As New System.DirectoryServices.SortOption(sortProperty, System.DirectoryServices.SortDirection.Ascending)
                    adSearcher.Sort = srt
                End If

                PrepareSearchScope(adSearcher, scope)

                Dim coll As SearchResultCollection = adSearcher.FindAll()

                If Not coll Is Nothing AndAlso coll.Count > 0 Then
                    For Each adSearchResult As SearchResult In coll
                        If strongTypes Then
                            Select Case adSearchResult.Properties("objectClass").Item(adSearchResult.Properties("objectClass").Count - 1).ToString
                                Case "user"
                                    results.Add(New UserDirectoryEntry(adSearchResult.GetDirectoryEntry))
                                Case "group"
                                    results.Add(New GroupDirectoryEntry(adSearchResult.GetDirectoryEntry))
                                Case "computer"
                                    results.Add(New ComputerDirectoryEntry(adSearchResult.GetDirectoryEntry))
                                Case Else
                                    results.Add(New BaseDirectoryEntry(adSearchResult.GetDirectoryEntry))
                            End Select
                        Else
                            results.Add(adSearchResult.GetDirectoryEntry)
                        End If
                    Next
                End If

                Return results.ToArray(GetType(DirectoryEntry))
            Catch ex As Exception
                Select Case ex.Message
                	Case "Logon failure: unknown user name or bad password"
                		Throw New SearchException("Logon Error", ex)
                	Case Else
                		Throw New SearchException("Search Error", ex)
                End Select
            End Try
        End Function

#End Region

    End Class

End Namespace