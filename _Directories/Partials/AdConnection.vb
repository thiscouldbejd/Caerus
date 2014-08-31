Namespace Directories

    Partial Public Class AdConnection
		Implements IConnection
		
		#Region " Private Shared Constants "

	        ''' <summary>
	        ''' Private Constant to Define the LDAP Prefix.
	        ''' </summary>
	        ''' <remarks></remarks>
	        Private Const LDAP_PREFIX As String = "LDAP://"
	
	        ''' <summary>
	        ''' Private Constant to Define the Base Delineator.
	        ''' </summary>
	        ''' <remarks></remarks>
	        Private Const BASE_DELINEATOR As String = "/"
	
	        ''' <summary>
	        ''' Private Constant to Define the Name of the Method: GetPassword.
	        ''' </summary>
	        ''' <remarks></remarks>
	        Private Const METHOD_GETPASSWORD As String = "GetPassword"
        
		#End Region

		#Region " Private Shared Variables "

	        ''' <summary>
	        ''' Represents an Authentication Type for an Anonymous with Explicit Server Bind.
	        ''' </summary>
	        ''' <remarks></remarks>
	        Private Shared m_AnonymousWithServer As AuthenticationTypes _
	             = AuthenticationTypes.Anonymous Or AuthenticationTypes.ServerBind
	
	        ''' <summary>
	        ''' Represents an Authentication Type for an Anonymous without Explicit Server Bind.
	        ''' </summary>
	        ''' <remarks></remarks>
	        Private Shared m_AnonymousWithoutServer As AuthenticationTypes _
	            = AuthenticationTypes.Anonymous
	
	        ''' <summary>
	        ''' Represents an Authentication Type for a Basic with Explicit Server Bind.
	        ''' </summary>
	        ''' <remarks></remarks>
	        Private Shared m_BasicWithServer As AuthenticationTypes _
	            = AuthenticationTypes.ServerBind
	
	        ''' <summary>
	        ''' Represents an Authentication Type for a Basic without Explicit Server Bind.
	        ''' </summary>
	        ''' <remarks></remarks>
	        Private Shared m_BasicWithoutServer As AuthenticationTypes _
	            = AuthenticationTypes.Encryption
	
	        ''' <summary>
	        ''' Represents an Authentication Type for an Integrated with Explicit Server Bind.
	        ''' </summary>
	        ''' <remarks></remarks>
	        Private Shared m_IntegratedWithServer As AuthenticationTypes _
	            = AuthenticationTypes.Secure Or AuthenticationTypes.Sealing Or AuthenticationTypes.ServerBind
	
	        ''' <summary>
	        ''' Represents an Authentication Type for an Integrated without Explicit Server Bind.
	        ''' </summary>
	        ''' <remarks></remarks>
	        Private Shared m_IntegratedWithoutServer As AuthenticationTypes _
	            = AuthenticationTypes.Secure Or AuthenticationTypes.Sealing
            
		#End Region

		#Region " Public Properties "

	        ''' <summary>
	        ''' Provides Access to the String Representation of the Connection.
	        ''' </summary>
	        ''' <value></value>
	        ''' <returns></returns>
	        ''' <remarks></remarks>
	        Public Overloads ReadOnly Property Connection() As String _
	        Implements IConnection.Connection
	            Get
	                If AdBase.StartsWith(LDAP_PREFIX) Then
	                    Connection = AdBase
	                End If
	                If AdServer = String.Empty Then
	                    Connection = LDAP_PREFIX & AdBase
	                Else
	                    Connection = LDAP_PREFIX & adServer & BASE_DELINEATOR & AdBase
	                End If
	            End Get
	        End Property
	
	        ''' <summary>
	        ''' Provides Access to the Root Directory Entry of the Connection.
	        ''' </summary>
	        ''' <value></value>
	        ''' <returns></returns>
	        ''' <remarks></remarks>
	        Public ReadOnly Property Root() As DirectoryEntry _
	        Implements IConnection.Root
	            Get
	                If Not adRoot Is Nothing Then
	                    Return adRoot
	                End If
	                Select Case AdAuthType
	                    Case AuthenticationType.Anonymous
	                        If String.IsNullOrEmpty(adServer) Then
	                            adRoot = New DirectoryEntry(Connection, Nothing, Nothing, m_AnonymousWithoutServer)
	                        Else
	                            adRoot = New DirectoryEntry(Connection, Nothing, Nothing, m_AnonymousWithServer)
	                        End If
	                    Case AuthenticationType.Basic
	                        If String.IsNullOrEmpty(adServer) Then
	                            adRoot = New DirectoryEntry(Connection, AdUsername, AdPassword, m_BasicWithoutServer)
	                        Else
	                            adRoot = New DirectoryEntry(Connection, AdUsername, AdPassword, m_BasicWithServer)
	                        End If
	                    Case AuthenticationType.Integrated
	                        If String.IsNullOrEmpty(adServer) Then
	                            adRoot = New DirectoryEntry(Connection, Nothing, Nothing, m_IntegratedWithoutServer)
	                        Else
	                            adRoot = New DirectoryEntry(Connection, Nothing, Nothing, m_IntegratedWithServer)
	                        End If
	                End Select
	                Return m_adRoot
	            End Get
	        End Property
	
	        ''' <summary>
	        ''' Provides the Ability to Access and Create a Directory Entry based on a Specific Path.
	        ''' </summary>
	        ''' <param name="ldapPath"></param>
	        ''' <value></value>
	        ''' <returns></returns>
	        ''' <remarks></remarks>
	        Public Overloads ReadOnly Property DirectoryEntry(ByVal ldapPath As String) As DirectoryEntry _
			Implements IConnection.DirectoryEntry
	            Get
	                Try
	                    Dim l_entry As DirectoryEntry = Nothing
	                    Select Case AdAuthType
	                        Case AuthenticationType.Anonymous
	                            If String.IsNullOrEmpty(adServer) Then
	                                l_entry = New DirectoryEntry(Connection(ldapPath), Nothing, Nothing, m_AnonymousWithoutServer)
	                            Else
	                                l_entry = New DirectoryEntry(Connection(ldapPath), Nothing, Nothing, m_AnonymousWithServer)
	                            End If
	                        Case AuthenticationType.Basic
	                            If String.IsNullOrEmpty(adServer) Then
	                                l_entry = New DirectoryEntry(Connection(ldapPath), AdUsername, AdPassword, m_BasicWithoutServer)
	                            Else
	                                l_entry = New DirectoryEntry(Connection(ldapPath), AdUsername, AdPassword, m_BasicWithServer)
	                            End If
	                        Case AuthenticationType.Integrated
	                            If String.IsNullOrEmpty(adServer) Then
	                                l_entry = New DirectoryEntry(Connection(ldapPath), Nothing, Nothing, m_IntegratedWithoutServer)
	                            Else
	                                l_entry = New DirectoryEntry(Connection(ldapPath), Nothing, Nothing, m_IntegratedWithServer)
	                            End If
	                    End Select
	                    Return l_entry
	                Catch ex As System.Runtime.InteropServices.COMException
	                    Return Nothing
	                End Try
	            End Get
	        End Property
	
	        ''' <summary>
	        ''' Provides the Ability to Access and Create a Directory Entry based on a Specific Identifier/Guid.
	        ''' </summary>
	        ''' <param name="nativeGuid"></param>
	        ''' <value></value>
	        ''' <returns></returns>
	        ''' <remarks></remarks>
	        Public Overloads ReadOnly Property DirectoryEntry(ByVal nativeGuid As Guid) As DirectoryEntry _
	        Implements IConnection.DirectoryEntry
	            Get
	                Try
	                    Dim l_entry As DirectoryEntry = Nothing
	                    Select Case AdAuthType
	                        Case AuthenticationType.Anonymous
	                            If String.IsNullOrEmpty(adServer) Then
	                                l_entry = New DirectoryEntry(Connection(nativeGuid), String.Empty, String.Empty, m_AnonymousWithoutServer)
	                            Else
	                                l_entry = New DirectoryEntry(Connection(nativeGuid), String.Empty, String.Empty, m_AnonymousWithServer)
	                            End If
	                        Case AuthenticationType.Basic
	                            If String.IsNullOrEmpty(adServer) Then
	                                l_entry = New DirectoryEntry(Connection(nativeGuid), AdUsername, AdPassword, m_BasicWithoutServer)
	                            Else
	                                l_entry = New DirectoryEntry(Connection(nativeGuid), AdUsername, AdPassword, m_BasicWithServer)
	                            End If
	                        Case AuthenticationType.Integrated
	                            If String.IsNullOrEmpty(adServer) Then
	                                l_entry = New DirectoryEntry(Connection(nativeGuid), Nothing, Nothing, m_IntegratedWithoutServer)
	                            Else
	                                l_entry = New DirectoryEntry(Connection(nativeGuid), Nothing, Nothing, m_IntegratedWithServer)
	                            End If
	                    End Select
	                    Return l_entry
	                Catch ex As System.Runtime.InteropServices.COMException
	                    Return Nothing
	                End Try
	            End Get
	        End Property
        
		#End Region

		#Region " Private Properties "

	        ''' <summary>
	        ''' Provides Access to the String Representation of a Connection for a given LDAP Path.
	        ''' </summary>
	        ''' <param name="ldapPath">The Given Base Path for the Connection.</param>
	        ''' <value></value>
	        ''' <returns></returns>
	        ''' <remarks></remarks>
	        Private Overloads ReadOnly Property Connection(ByVal ldapPath As String) As String
	            Get
	                If ldapPath.StartsWith(LDAP_PREFIX) Then
	                    Return ldapPath
	                Else
	                    If String.IsNullOrEmpty(adServer) Then
	                        Return LDAP_PREFIX & ldapPath
	                    Else
	                        Return LDAP_PREFIX & adServer & BASE_DELINEATOR & ldapPath
	                    End If
	                End If
	            End Get
	        End Property
	
	        ''' <summary>
	        ''' Provides Access to the String Representation of a Connection for a given Identifier/GUID.
	        ''' </summary>
	        ''' <param name="nativeGuid">The Guid to Use in the Creation/Accessing of the Connection.</param>
	        ''' <value></value>
	        ''' <returns></returns>
	        ''' <remarks></remarks>
	        Private Overloads ReadOnly Property Connection(ByVal nativeGuid As Guid) As String
	            Get
	                If String.IsNullOrEmpty(adServer) Then
	                    Return LDAP_PREFIX & "<GUID=" & nativeGuid.ToString("N") & ">"
	                Else
	                    Return LDAP_PREFIX & adServer & BASE_DELINEATOR & "<GUID=" & nativeGuid.ToString("N") & ">"
	                End If
	            End Get
	        End Property
	        
		#End Region

		#Region " Public Methods "

	        ''' <summary>
	        ''' Public Method to Create a Particular Directory Entry from Scratch.
	        ''' </summary>
	        ''' <param name="parentPath">The Path (Parent) at which to Create the Directory Entry.</param>
	        ''' <param name="name">The Name of the Entry to Create.</param>
	        ''' <param name="schemaName">The Schema for the Entry to Create.</param>
	        ''' <returns>A newly created Directory Entry.</returns>
	        ''' <remarks></remarks>
	        Public Function CreateDirectoryEntry( _
	            ByVal parentPath As String, _
	            ByVal name As String, _
	            ByVal schemaName As String _
	        ) As DirectoryEntry _
	        Implements IConnection.CreateDirectoryEntry
	
	            Try
	                Dim parentEntry As DirectoryEntry = DirectoryEntry(parentPath)
	                Dim createdEntry As DirectoryEntry = parentEntry.Children.Add("CN=" + name, schemaName)
	                parentEntry.Close()
	                Return createdEntry
	            Catch ex As Exception
	                Throw New Exception("Could not set Active Directory Entry", ex)
	            End Try
	
	        End Function
	
	        ''' <summary>
	        ''' Public Method to Return a Provider Specific Property Name.
	        ''' </summary>
	        ''' <param name="property">The Enumerated Property to Get.</param>
	        ''' <returns>The Name of the Property.</returns>
	        ''' <remarks></remarks>
	        Public Function GetDirectoryPropertyName( _
	            ByVal [property] As CommonProperties _
	        ) As String _
	        Implements IConnection.GetDirectoryPropertyName
	
	            Select Case [property]
	                Case CommonProperties.AccountUsername
	                    Return "sAMAccountName"
	                Case CommonProperties.Department
	                    Return "department"
	                Case CommonProperties.DisplayName
	                    Return "displayName"
	                Case CommonProperties.EmployeeIdentifier
	                    Return "employeeID"
	                Case CommonProperties.GivenName
	                    Return "givenName"
	                Case CommonProperties.HomeDirectory
	                    Return "homeDirectory"
	                Case CommonProperties.HomeDirectoryDrive
	                    Return "homeDrive"
	                Case CommonProperties.PrincipleName
	                    Return "userPrincipalName"
	                Case CommonProperties.ProfileDirectory
	                    Return "profilePath"
	                Case CommonProperties.Surname
	                    Return "sn"
	                Case CommonProperties.CommonName
	                    Return "cn"
	                Case CommonProperties.Description
	                    Return "description"
	                Case CommonProperties.DomainController
	                    Return "dc"
					Case CommonProperties.ObjectClass
	                    Return "objectClass"
	                Case CommonProperties.ObjectCategory
	                	Return "objectCategory"
	                Case CommonProperties.UnicodePassword
	                	Return "unicodePwd"
	                Case CommonProperties.LockOutTime
	                	Return "LockOutTime"
	                Case Else
	                    Return String.Empty
	            End Select
	
	        End Function
	
	        ''' <summary>
	        ''' Method for Returning a Provider Specific Schema Name.
	        ''' </summary>
	        ''' <param name="schema">The Enumerated Schema to Get.</param>
	        ''' <returns>The Name of the Schema.</returns>
	        ''' <remarks></remarks>
	        Public Function GetDirectorySchemaName( _
	            ByVal schema As CommonSchemas _
	        ) As String _
	        Implements IConnection.GetDirectorySchemaName
	
	            Select Case schema
	                Case CommonSchemas.DNSDomain
	                    Return "domainDNS"
	                Case CommonSchemas.User
	                    Return "user"
	                Case CommonSchemas.Group
	                    Return "group"
	                Case Else
	                    Return String.Empty
	            End Select
	
	        End Function
	
	        ''' <summary>
	        ''' Method for Returning a Provider Specific Action Name.
	        ''' </summary>
	        ''' <param name="action">The Enumerated Action to Get.</param>
	        ''' <returns>The Name of the Action.</returns>
	        ''' <remarks></remarks>
	        Public Function GetDirectoryActionName( _
	            ByVal action As CommonActions _
	        ) As String _
	        Implements IConnection.GetDirectoryActionName
	
	            Select Case action
	                Case CommonActions.SetPassword
	                    Return "SetPassword"
	                Case CommonActions.DisabledAccount
	                    Return "AccountDisabled"
	                Case CommonActions.LockedAccount
	                    Return "IsAccountLocked"
	                Case CommonActions.RequiredPassword
	                    Return "PasswordRequired"
	                Case Else
	                    Return String.Empty
	            End Select
	
	        End Function

		#End Region

		#Region " Shared Methods "

	        ''' <summary>
	        ''' Public Shared Method to Parse a New Connection from an Existing Directory Entry.
	        ''' </summary>
	        ''' <param name="entry">The Directory Entry from which to Parse the Connection.</param>
	        ''' <returns>A New Connection Object.</returns>
	        ''' <remarks></remarks>
	        Public Shared Function ParseConnection(ByVal entry As DirectoryEntry) As AdConnection
	            Dim authType As AuthenticationType
	            Dim serverName As String = ""
	            Dim base As String = ""
	            If entry.Username = Nothing OrElse entry.Username.Length = 0 Then
	                authType = AuthenticationType.Integrated
	            Else
	                authType = AuthenticationType.Basic
	            End If
	
	            Dim ldapPath As String = entry.Path
	            If ldapPath.StartsWith(LDAP_PREFIX) Then
	                ldapPath = ldapPath.Remove(0, LDAP_PREFIX.Length)
	            End If
	
	            Dim pos As Integer = ldapPath.IndexOf(BASE_DELINEATOR)
	            Dim pos1 As Integer = ldapPath.IndexOf("=")
	            If pos > 0 AndAlso pos1 > pos Then
	                serverName = ldapPath.Substring(0, pos)
	                ldapPath = ldapPath.Remove(0, pos + 1)
	            End If
	
	            base = ldapPath.Substring(ldapPath.ToLower(System.Globalization.CultureInfo.InvariantCulture).IndexOf("dc="))
	
	            Select Case authType
	                Case AuthenticationType.Basic
	                    If serverName.Length > 0 Then
	                        Dim ty As System.Type = entry.GetType
	                        Dim meth As System.Reflection.MethodInfo = ty.GetMethod(METHOD_GETPASSWORD, _
	                            Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
	                        If Not meth Is Nothing Then
	                            Return New AdConnection(authType, base, serverName, entry.Username, meth.Invoke(entry, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing))
	                        Else
	                            Return New AdConnection(authType, base, serverName, entry.Username, String.Empty)
	                        End If
	                    Else
	                        Dim ty As System.Type = entry.GetType
	                        Dim meth As System.Reflection.MethodInfo = ty.GetMethod(METHOD_GETPASSWORD, _
	                            Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
	                        If Not meth Is Nothing Then
	                            Return New AdConnection(authType, base, entry.Username, meth.Invoke(entry, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing))
	                        Else
	                            Return New AdConnection(authType, base, entry.Username, String.Empty)
	                        End If
	                    End If
	                Case Else
	                    If serverName.Length > 0 Then
	                        Return New AdConnection(authType, base, serverName)
	                    Else
	                        Return New AdConnection(authType, base)
	                    End If
	            End Select
	        End Function

		#End Region

    End Class

End Namespace

