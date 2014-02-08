Imports Leviathan.Configuration
Imports System.DirectoryServices

Namespace Directories

    Partial Public Class AdPrincipleProvider
        Implements IPrincipalProvider

#Region " Private Constants "

        Private Const PARAMETER_NAME_OBJECTCLASS As String = "objectClass"
        
        Private Const PARAMETER_VALUE_USER As String = "user"
        
        Private Const PARAMETER_VALUE_GROUP As String = "group"
        
#End Region

#Region " Protected Properties "

        Protected ReadOnly Property GetUserName( _
        	ByVal identity As System.Security.Principal.IIdentity _
        ) As String
            Get
                If String.IsNullOrEmpty(AdUserImpersonate) Then
                    Return identity.Name
                Else
                    Return AdUserImpersonate
                End If
            End Get
        End Property

#End Region

#Region " IPrincipalProvider Implementation "

        Public Function CreateIPrincipal( _
            ByVal identity As System.Security.Principal.IIdentity _
        ) As CorePrincipal _
        Implements IPrincipalProvider.CreateIPrincipal

            If identity.IsAuthenticated Then
                Dim adUser As UserDirectoryEntry = GetUser(identity)
                Return PopulateIPrincipal(adUser, identity)
            Else
                ' TODO: Should we return a non-authenticated identity here?
                Return Nothing
            End If

        End Function

        Public Function CreateIPrincipal( _
            ByVal identity As System.Security.Principal.IIdentity, _
            ByVal password As String _
        ) As CorePrincipal _
        Implements IPrincipalProvider.CreateIPrincipal

            If identity.IsAuthenticated Then
                Dim adUser As UserDirectoryEntry = GetUser(GetUserName(identity), password)
                Return PopulateIPrincipal(adUser, identity)
            Else
                ' TODO: Should we return a non-authenticated identity here?
                Return Nothing
            End If

        End Function

        Private Function PopulateIPrincipal( _
            ByVal adUser As UserDirectoryEntry, _
            ByVal identity As System.Security.Principal.IIdentity _
        ) As CorePrincipal

            If Not adUser Is Nothing Then
                Dim grps As GroupDirectoryEntry() = adUser.Groups(m_cn)
                Dim roleList As New ArrayList
                For Each grp As GroupDirectoryEntry In grps
                    roleList.Add(grp.CommonName())
                Next
                Dim c As New CorePrincipal(identity, roleList)
                c.EmailAddress = adUser.EmailAddress
                c.DisplayName = adUser.DisplayName
                c.Id = adUser.Id
                Return c
            Else
                Return Nothing
            End If

        End Function

        Public Function UpdateIPrincipal( _
            ByVal principle As CorePrincipal _
        ) As CorePrincipal _
        Implements IPrincipalProvider.UpdateIPrincipal

            If principle.Identity.IsAuthenticated Then
                Dim roles As New ArrayList
                For Each r As String In principle.Roles
                    roles.Add(r)
                Next
                Dim adUser As UserDirectoryEntry = GetUser(principle.Identity)
                If Not adUser Is Nothing Then
                    Dim grps As GroupDirectoryEntry() = adUser.Groups(m_cn)
                    For Each grp As GroupDirectoryEntry In grps
                        roles.Add(grp.CommonName())
                    Next
                End If
                Dim c As New CorePrincipal(principle.Identity, roles)
                c.EmailAddress = adUser.EmailAddress
                c.DisplayName = adUser.DisplayName
                c.Id = adUser.Id
                Return c
            Else
                ' TODO: Should we return a non-authenticated identity here?
                Return Nothing
            End If

        End Function

        Public Function CreateIPrincipals( _
            ByVal role As String _
        ) As CorePrincipal() _
        Implements IPrincipalProvider.CreateIPrincipals

            Dim adGroup As GroupDirectoryEntry = GetGroup(role)

            If Not adGroup Is Nothing Then

                Dim retList As New ArrayList

                Dim members As BaseDirectoryEntry() = adGroup.Members

                For Each adUser As BaseDirectoryEntry In members
                    If adUser.GetType Is GetType(UserDirectoryEntry) Then
                        retList.Add(PopulateIPrincipal(adUser, New System.Security.Principal.GenericIdentity(adUser.Username)))
                    End If
                Next

                Return retList.ToArray(GetType(CorePrincipal))

            End If

            Return Nothing
        End Function
#End Region

#Region " Private Methods "

		Private Sub CreateConnection()
			
			If Cn Is Nothing Then Cn = New AdConnection(AuthType, AdServer, AdBase, AdUsername, AdPassword)
			
		End Sub
		
        Private Function GetUser( _
            ByVal identity As System.Security.Principal.IIdentity _
        ) As UserDirectoryEntry

            Dim adUser As UserDirectoryEntry

            Dim adParam As New Parameter(PARAMETER_NAME_OBJECTCLASS, PARAMETER_VALUE_USER, ParameterComparator.EqualTo, _
            	ParameterOperator.AndOperator, New Parameter(AdUserFieldMapping, BaseDirectoryEntry.ParseUsername(GetUserName(identity))))
            
            Try
                adUser = Searcher.ExecuteQuery(Cn, SearchScope.SubTree, adParam, True)(0)
            Catch ex As Exception
                adUser = Nothing
            End Try

            Return adUser
        End Function

        Private Function GetUser( _
            ByVal username As String, _
            ByVal password As String _
        ) As UserDirectoryEntry

            Dim l_cn As AdConnection
            
            If String.IsNullOrEmpty(Cn.AdServer) Then
            	
                l_cn = New AdConnection(AuthenticationType.Basic, Cn.AdBase, username, password)
                
            Else
            	
                l_cn = New AdConnection(AuthenticationType.Basic, Cn.AdBase, Cn.AdServer, username, password)
                
            End If

            Dim adUser As UserDirectoryEntry

			Dim adParam As New Parameter(PARAMETER_NAME_OBJECTCLASS, PARAMETER_VALUE_USER, ParameterComparator.EqualTo, _
            	ParameterOperator.AndOperator, New Parameter(AdUserFieldMapping, BaseDirectoryEntry.ParseUsername(username)))

            Try
                adUser = Searcher.ExecuteQuery(Cn, SearchScope.SubTree, adParam, True)(0)
            Catch ex As Exception
                adUser = Nothing
            End Try

            Return adUser

        End Function

        Private Function GetGroup( _
            ByVal groupName As String _
        ) As GroupDirectoryEntry

            Dim adGroup As GroupDirectoryEntry

			Dim adParam As New Parameter(PARAMETER_NAME_OBJECTCLASS, PARAMETER_VALUE_GROUP, ParameterComparator.EqualTo, _
            	ParameterOperator.AndOperator, New Parameter(AdUserFieldMapping, BaseDirectoryEntry.ParseUsername(groupName)))
            	
            Try
                adGroup = Searcher.ExecuteQuery(Cn, SearchScope.SubTree, adParam, True)(0)
            Catch ex As Exception
                adGroup = Nothing
            End Try

            Return adGroup

        End Function

#End Region

    End Class

End Namespace