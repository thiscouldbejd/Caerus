Namespace Directories

    ''' <summary>
    ''' Base Class for Strongly-Typed Directory Entries that hold Accounts in the Directory Service.
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class AccountDirectoryEntry
        Inherits BaseDirectoryEntry

#Region " Public Shared Constants "

        ''' <summary>
        ''' Private Constant to Define the Name of the Method: Add.
        ''' </summary>
        ''' <remarks></remarks>
        Public Const METHOD_ADD As String = "Add"

        ''' <summary>
        ''' Private Constant to Define the Name of the Method: SetPassword.
        ''' </summary>
        ''' <remarks></remarks>
        Public Const METHOD_SETPASSWORD As String = "SetPassword"

        ''' <summary>
        ''' Private Constant to Define the Name of the Method: Remove.
        ''' </summary>
        ''' <remarks></remarks>
        Public Const METHOD_REMOVE As String = "Remove"

#End Region

#Region " Public Properties "

        ''' <summary>
        ''' Bad Password Count.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BadPasswordCount() As Integer
            Get
                Return MyBase.Properties("badPwdCount").Value
            End Get
            Set(ByVal Value As Integer)
                MyBase.Properties("badPwdCount").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which wraps the Display Name Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DisplayName() As String
            Get
                Return MyBase.Properties("displayName").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("displayName").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which provides Access to a Last Logon Date/Time.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LastLogon() As DateTime
            Get
                Dim intLastLogon As Int64 = MyBase.Properties("lastLogon").Value
                Dim dte As DateTime = DateTime.Parse("01/01/1601")
                Return dte.AddSeconds(intLastLogon / 10000000)
            End Get
        End Property

        ''' <summary>
        ''' Public Property which provides Access to a Last Password Change Date/Time.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LastPasswordChange() As DateTime
            Get
                Dim intLastLogon As Int64 = MyBase.Properties("pwdLastSet").Value
                Dim dte As DateTime = DateTime.Parse("01/01/1601")
                Return dte.AddSeconds(intLastLogon / 10000000)
            End Get
        End Property

        ''' <summary>
        ''' Public Property which wraps the Logon Count Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LogonCount() As Integer
            Get
                Return MyBase.Properties("logonCount").Value
            End Get
        End Property

        ''' <summary>
        ''' Public Property which wraps the Created Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Created() As DateTime
            Get
                Return MyBase.Properties("whenCreated").Value
            End Get
        End Property

        ''' <summary>
        ''' Public Property which wraps the Changed Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Changed() As DateTime
            Get
                Return MyBase.Properties("whenChanged").Value
            End Get
        End Property

        ''' <summary>
        ''' Public Property which wraps the Is Locked Out Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsLockedOut() As Boolean
            Get
                Return EnumContains( _
                    MyBase.Properties("userAccountControl").Value, AccountOptions.UF_ACCOUNT_LOCKOUT)
            End Get
        End Property

        ''' <summary>
        ''' Public Property which wraps the Is Disabled Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsDisabled() As Boolean
            Get
                Return EnumContains( _
                    MyBase.Properties("userAccountControl").Value, AccountOptions.UF_ACCOUNTDISABLE)
            End Get
        End Property
        
        ''' <summary>
        ''' Public Property which wraps the Has Expired Password Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property HasExpiredPassword() As Boolean
            Get
                Return EnumContains( _
                    MyBase.Properties("userAccountControl").Value, AccountOptions.UF_PASSWD_NOTREQD)
            End Get
        End Property
        
#End Region

#Region " Public Constructors "
        ''' <summary>
        ''' Default Public Constructor for the Class.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()
        End Sub

        ''' <summary>
        ''' Public Constructor for the Class.
        ''' </summary>
        ''' <param name="path">The Path of the Directory Entry Object this class wraps.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal path As String)
            MyBase.New(path)
        End Sub

        ''' <summary>
        ''' Public Constructor for the Class.
        ''' </summary>
        ''' <param name="path">The Path of the Directory Entry Object this class wraps.</param>
        ''' <param name="username">The Username to be used when Authenticating/Binding.</param>
        ''' <param name="password">The Password to be used when Authenticating/Binding.</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal path As String, ByVal username As String, ByVal password As String)
            MyBase.New(path, username, password)
        End Sub

        ''' <summary>
        ''' Public Constructor for the Class.
        ''' </summary>
        ''' <param name="path">The Path of the Directory Entry Object this class wraps.</param>
        ''' <param name="username">The Username to be used when Authenticating/Binding.</param>
        ''' <param name="password">The Password to be used when Authenticating/Binding.</param>
        ''' <param name="authenticationType"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal path As String, ByVal username As String, ByVal password As String, ByVal authenticationType As AuthenticationTypes)
            MyBase.New(path, username, password, authenticationType)
        End Sub

        ''' <summary>
        ''' Public Constructor for the Class.
        ''' </summary>
        ''' <param name="entry">The Directory Entry Object this class wraps.</param>
        ''' <remarks>The Directory Entry willed be parsed and re-connected.</remarks>
        Public Sub New(ByVal entry As DirectoryEntry)
            MyBase.New(entry)
        End Sub
#End Region

#Region " Public Group Handling Method Overloads"
        ''' <summary>
        ''' Method to return the groups to which this Directory Entry belongs.
        ''' </summary>
        ''' <returns>An Array of Group Directory Entries.</returns>
        ''' <remarks></remarks>
        Public Function Groups() As GroupDirectoryEntry()
            Return Groups(AdConnection.ParseConnection(Me), True)
        End Function

        ''' <summary>
        ''' Method to return the groups to which this Directory Entry belongs.
        ''' </summary>
        ''' <param name="connection">The IConnection used to retrieve the groups.</param>
        ''' <returns>An Array of Group Directory Entries.</returns>
        ''' <remarks></remarks>
        Public Function Groups(ByVal connection As IConnection) As GroupDirectoryEntry()
            Return Groups(connection, True)
        End Function

        ''' <summary>
        ''' Method to return the first level (e.g. not implicit through group-in-group memberships)
        ''' groups to which this Directory Entry belongs.
        ''' </summary>
        ''' <returns>An Array of Group Directory Entries.</returns>
        ''' <remarks></remarks>
        Public Function FirstLevelGroups() As GroupDirectoryEntry()
            Return Groups(AdConnection.ParseConnection(Me), False)
        End Function

        ''' <summary>
        ''' Method to return the first level (e.g. not implicit through group-in-group memberships)
        ''' groups to which this Directory Entry belongs.
        ''' </summary>
        ''' <param name="connection">The IConnection used to retrieve the groups.</param>
        ''' <returns>An Array of Group Directory Entries.</returns>
        ''' <remarks></remarks>
        Public Function FirstLevelGroups(ByVal connection As IConnection) As GroupDirectoryEntry()
            Return Groups(connection, False)
        End Function

        ''' <summary>
        ''' Method to return the groups to which this Directory Entry belongs.
        ''' </summary>
        ''' <param name="connection">The IConnection used to retrieve the groups.</param>
        ''' <param name="allLevels">A Boolean Value indicating whether all Levels of groups should
        ''' be returned.</param>
        ''' <returns>An Array of Group Directory Entries.</returns>
        ''' <remarks></remarks>
        Private Function Groups(ByVal connection As IConnection, ByVal allLevels As Boolean) _
            As GroupDirectoryEntry()
            Dim returnList As New ArrayList
            For i As Integer = 0 To MyBase.Properties("memberOf").Count - 1
                Try
                    Dim grp As New GroupDirectoryEntry(connection.DirectoryEntry(Convert.ToString(MyBase.Properties("memberOf")(i))))
                    returnList.Add(grp)
                    If allLevels Then
                        returnList.AddRange(grp.MemberOf)
                    End If
                Catch ex As Exception
                End Try
            Next
            Return returnList.ToArray(GetType(GroupDirectoryEntry))
        End Function
#End Region

#Region " Public Add To Group Method Overloads "
        ''' <summary>
        ''' Method to add this Directory Entry to a particular group.
        ''' </summary>
        ''' <param name="groupDistinguishedName">The Group to Add To.</param>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function AddToGroup(ByVal groupDistinguishedName As String) As Boolean
            Dim group As DirectoryEntry = New DirectoryEntry(groupDistinguishedName)
            Return AddToGroup(group)
        End Function

        ''' <summary>
        ''' Method to add this Directory Entry to a particular group.
        ''' </summary>
        ''' <param name="groupDistinguishedName">The Group to Add To.</param>
        ''' <param name="connection">The IConnection used to action the addition.</param>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function AddToGroup(ByVal groupDistinguishedName As String, ByVal connection As IConnection) As Boolean
            Dim group As DirectoryEntry = connection.DirectoryEntry(groupDistinguishedName)
            Return AddToGroup(group)
        End Function

        ''' <summary>
        ''' Method to add this Directory Entry to a particular group.
        ''' </summary>
        ''' <param name="group">The Group to Add To.</param>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function AddToGroup(ByVal group As DirectoryEntry) As Boolean
            Try
                group.Invoke(METHOD_ADD, New Object() {MyBase.Path.ToString})
                group.CommitChanges()
                Return True
            Catch ex As System.Runtime.InteropServices.COMException
                Return False
            End Try
        End Function
#End Region

#Region " Public Add Remove From Group Method Overloads "
        ''' <summary>
        ''' Method to remove this Directory Entry from a particular group.
        ''' </summary>
        ''' <param name="groupDistinguishedName">The Group to Remove From</param>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function RemoveFromGroup(ByVal groupDistinguishedName As String) As Boolean
            Dim connection As IConnection = AdConnection.ParseConnection(Me)
            Return RemoveFromGroup(groupDistinguishedName, connection)
        End Function

        ''' <summary>
        ''' Method to remove this Directory Entry from a particular group.
        ''' </summary>
        ''' <param name="groupDistinguishedName">The Group to Remove From.</param>
        ''' <param name="connection">The IConnection used to action the removal.</param>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function RemoveFromGroup(ByVal groupDistinguishedName As String, ByVal connection As IConnection) As Boolean
            Dim group As DirectoryEntry = connection.DirectoryEntry(groupDistinguishedName)
            Return RemoveFromGroup(group)
        End Function

        ''' <summary>
        ''' Method to remove this Directory Entry from a particular group.
        ''' </summary>
        ''' <param name="group">The Group to Remove From</param>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function RemoveFromGroup(ByVal group As DirectoryEntry) As Boolean
            Try
                group.Invoke(METHOD_REMOVE, New Object() {MyBase.Path.ToString})
                group.CommitChanges()
                Return True
            Catch ex As System.Runtime.InteropServices.COMException
                Return False
            End Try
        End Function
#End Region

#Region " Public General Functions "

        ''' <summary>
        ''' Public Method to Change the Password of the Account of this Directory Entry.
        ''' </summary>
        ''' <param name="password">The Password to Change to.</param>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Function SetPassword(ByVal password As String) As Boolean
            Try
                MyBase.Invoke(METHOD_SETPASSWORD, New Object() {password})
                Return True
            Catch ex As Exception
                Throw New Exception("Could not set password", ex)
            End Try
        End Function

        ''' <summary>
        ''' Public Method to Enable the Account of this Directory Entry.
        ''' </summary>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Function EnableAccount() As Boolean
            Try
                MyBase.Properties("userAccountControl").Value = EnumRemove( _
                    MyBase.Properties("userAccountControl").Value, AccountOptions.UF_ACCOUNTDISABLE)
                MyBase.CommitChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Public Method to Disable the Account of this Directory Entry.
        ''' </summary>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Function DisableAccount() As Boolean
            Try
                Properties("userAccountControl").Value = EnumAdd( _
                    Properties("userAccountControl").Value, AccountOptions.UF_ACCOUNTDISABLE)
                MyBase.Properties("userAccountControl")(0) = AccountOptions.UF_ACCOUNTDISABLE
                MyBase.CommitChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Public Method to LockOut the Account of this Directory Entry.
        ''' </summary>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Function LockoutAccount() As Boolean
            Try
                Properties("userAccountControl").Value = EnumAdd( _
                    Properties("userAccountControl").Value, AccountOptions.UF_ACCOUNT_LOCKOUT)
                MyBase.CommitChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function UnlockAccount() As Boolean
            Try
                Properties("userAccountControl").Value = EnumRemove( _
                    Properties("userAccountControl").Value, AccountOptions.UF_ACCOUNT_LOCKOUT)
                MyBase.CommitChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

#End Region

    End Class

End Namespace