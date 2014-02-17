Imports Hermes.Cryptography.Cipher
Imports System.IO

Namespace Directories

    ''' <summary>
    ''' Class for Strongly-Typed User Directory Entries.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class UserDirectoryEntry
        Inherits AccountDirectoryEntry

#Region " Public Properties "
        '

        ''' <summary>
        ''' Public Property which wraps the Admin Description Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AdminDescription() As String
            Get
                Return MyBase.Properties("adminDescription").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("adminDescription").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which wraps the Admin Display Name Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AdminDisplayName() As String
            Get
                Return MyBase.Properties("adminDisplayName").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("adminDisplayName").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which wraps the Given Name Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GivenName() As String
            Get
                Return MyBase.Properties("givenName").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("givenName").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which wraps the Surname Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Surname() As String
            Get
                Return MyBase.Properties("sn").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("sn").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which wraps the Telephone Number Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TelephoneNumber() As String
            Get
                Return MyBase.Properties("telephoneNumber").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("telephoneNumber").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which wraps the Email Address Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property EmailAddress() As String
            Get
                Return MyBase.Properties("mail").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("mail").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which wraps the Description Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Description() As String
            Get
                Return MyBase.Properties("description").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("description").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which wraps the Department Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Department() As String
            Get
                Return MyBase.Properties("department").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("department").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which wraps the Company Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Company() As String
            Get
                Return MyBase.Properties("company").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("company").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which wraps the Office Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Office() As String
            Get
                Return MyBase.Properties("physicalDeliveryOfficeName").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("physicalDeliveryOfficeName").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which wraps the Title Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Title() As String
            Get
                Return MyBase.Properties("title").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("title").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which wraps the WWW Home Page Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WebPage() As Uri
            Get
                Return New Uri(MyBase.Properties("wWWHomePage").Value)
            End Get
            Set(ByVal Value As Uri)
                MyBase.Properties("wWWHomePage").Value = Value.ToString
            End Set
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

#Region " Public Shared Methods "

        Public Shared Function Create( _
            ByRef adConn As IConnection, _
            ByVal userName As String, _
            ByVal userPassword As String, _
            ByVal userGivenName As String, _
            ByVal userSurname As String, _
            ByVal userDescription As String, _
            ByVal userDepartment As String, _
            ByVal profileDirectoryBase As String, _
            ByVal homeDirectoryBase As String, _
            ByVal homeDirectoryDrive As String, _
            ByVal principleNameSuffix As String, _
            ByVal adBase As String, _
            ByRef newPhoneticPassword As String _
        ) As UserDirectoryEntry

            Try

                Dim newCommonName As String = _
                    CreateUniqueCommonName(adConn, userGivenName, userSurname, adBase)

                Dim newUser As DirectoryEntry = _
                    adConn.CreateDirectoryEntry(adBase, newCommonName, adConn.GetDirectorySchemaName(CommonSchemas.User))

                ' Add Account Username
                newUser.Properties(adConn.GetDirectoryPropertyName(CommonProperties.AccountUsername)) _
                    .Add(userName)

                ' Add Given Name
                newUser.Properties(adConn.GetDirectoryPropertyName(CommonProperties.GivenName)) _
                    .Add(userGivenName)

                ' Add Surname
                newUser.Properties(adConn.GetDirectoryPropertyName(CommonProperties.Surname)) _
                    .Add(userSurname)

                ' Add Display Name
                newUser.Properties(adConn.GetDirectoryPropertyName(CommonProperties.DisplayName)) _
                    .Add(userGivenName & SPACE & userSurname)

                ' Add Profile Directory
                If Not profileDirectoryBase = Nothing Then
                    If Not profileDirectoryBase.EndsWith(BACK_SLASH) Then _
                                    profileDirectoryBase = profileDirectoryBase & BACK_SLASH
                    newUser.Properties(adConn.GetDirectoryPropertyName(CommonProperties.ProfileDirectory)) _
                        .Add(profileDirectoryBase & userName)
                End If

                ' Add Home Directory
                If Not homeDirectoryBase = Nothing Then
                    If Not homeDirectoryBase.EndsWith(BACK_SLASH) Then _
                                    homeDirectoryBase = homeDirectoryBase & BACK_SLASH
                    newUser.Properties(adConn.GetDirectoryPropertyName(CommonProperties.HomeDirectory)) _
                        .Add(homeDirectoryBase & userName)
                End If

                ' Add Home Directory Drive Mapping
                If Not homeDirectoryDrive = Nothing Then
                    If homeDirectoryDrive.EndsWith(BACK_SLASH) Then _
                                    homeDirectoryDrive = homeDirectoryDrive.TrimEnd(BACK_SLASH)
                    If Not homeDirectoryDrive.EndsWith(COLON) Then _
                        homeDirectoryDrive = homeDirectoryDrive & COLON
                    newUser.Properties(adConn.GetDirectoryPropertyName(CommonProperties.HomeDirectoryDrive)) _
                        .Add(homeDirectoryDrive)
                End If

                ' Add Principle Name
                If Not principleNameSuffix = Nothing Then
                    If Not principleNameSuffix.StartsWith(AT_SIGN) Then _
                        principleNameSuffix = AT_SIGN & principleNameSuffix
                    newUser.Properties(adConn.GetDirectoryPropertyName(CommonProperties.PrincipleName)) _
                        .Add(userName & principleNameSuffix)
                End If

                ' Add Description
                If Not userDescription = Nothing Then
                    newUser.Properties(adConn.GetDirectoryPropertyName(CommonProperties.Description)) _
                        .Add(userDescription)
                End If

                ' Add Department
                If Not userDepartment = Nothing Then
                    newUser.Properties(adConn.GetDirectoryPropertyName(CommonProperties.Department)) _
                        .Add(userDepartment)
                End If

                ' Set Password
                newPhoneticPassword = PhoneticPassword(userPassword)

                newUser.CommitChanges()
                newUser.Invoke(adConn.GetDirectoryActionName(CommonActions.SetPassword), userPassword)
                newUser.InvokeSet(adConn.GetDirectoryActionName(CommonActions.DisabledAccount), False)
                newUser.InvokeSet(adConn.GetDirectoryActionName(CommonActions.LockedAccount), False)
                newUser.InvokeSet(adConn.GetDirectoryActionName(CommonActions.RequiredPassword), False)
                newUser.CommitChanges()

                Return New UserDirectoryEntry(newUser)

            Catch ex As Exception

                Return Nothing

            End Try

        End Function

        Public Shared Function CreateWithUsername( _
            ByRef adConn As IConnection, _
            ByVal userGivenName As String, _
            ByVal userSurname As String, _
            ByVal userDescription As String, _
            ByVal userDepartment As String, _
            ByVal profileDirectoryBase As String, _
            ByVal homeDirectoryBase As String, _
            ByVal homeDirectoryDrive As String, _
            ByVal principleNameSuffix As String, _
            ByVal adBase As String, _
            ByRef newUsername As String, _
            ByRef newPassword As String, _
            ByRef newPhoneticPassword As String _
        ) As UserDirectoryEntry

            Try

                newUsername = _
                    CreateUniqueUsername(adConn, userGivenName, userSurname, adBase)

                newPassword = Create_Password(6, 0)

                Return Create(adConn, newUsername, newPassword, userGivenName, userSurname, _
                    userDescription, userDepartment, profileDirectoryBase, homeDirectoryBase, _
                    homeDirectoryDrive, principleNameSuffix, adBase, newPhoneticPassword)

            Catch ex As Exception

                Return Nothing

            End Try
        End Function

#End Region

#Region " Private Shared Methods "

        ''' <summary>
        ''' Method to Create a Unique Username.
        ''' </summary>
        ''' <param name="adConn">The Connection to use to search for clashes.</param>
        ''' <param name="givenName">The Given Name of the User.</param>
        ''' <param name="surName">The Surname of the User.</param>
        ''' <param name="adBase">The Base where the User is being created.</param>
        ''' <returns>The 'Safe' username.</returns>
        ''' <remarks>This ensures no clashes by appending a number to the end of the username and cutting it down to a set number of characters.</remarks>
        Private Shared Function CreateUniqueUsername( _
            ByRef adConn As IConnection, _
            ByVal givenName As String, _
            ByVal surName As String, _
            ByVal adBase As String _
        ) As String

            Dim foundParentEntry As Boolean = False
            Dim parentEntry As DirectoryEntry = adConn.Root

            Do Until foundParentEntry
                If parentEntry.SchemaClassName = _
                    adConn.GetDirectorySchemaName(CommonSchemas.DNSDomain) _
                    OrElse parentEntry.Parent Is Nothing _
                    OrElse parentEntry.Path = parentEntry.Parent.Path Then

                    foundParentEntry = True

                Else

                    parentEntry = parentEntry.Parent

                End If
            Loop

            Dim conn As AdConnection = AdConnection.ParseConnection(parentEntry)

            Dim userName As String = givenName.ToLower & FULL_STOP & surName.ToLower
            Dim count As Integer = 1
            Dim userNameSafe As Boolean = False

            Do Until userNameSafe

                Dim adEntries As DirectoryEntry() = Searcher.ExecuteQuery(conn, SearchScope.SubTree, _
                    New Parameter(adConn.GetDirectoryPropertyName(CommonProperties.AccountUsername), _
                    userName, ParameterComparator.EqualTo), False)

                If adEntries Is Nothing OrElse adEntries.Length = 0 Then

                    userNameSafe = True

                Else

                    If userName.EndsWith((count - 1).ToString) Then
                        userName = userName.Substring(0, userName.Length - (count - 1).ToString.Length) & count.ToString
                    Else
                        userName = userName & count.ToString
                    End If
                    count += 1

                End If

            Loop

            userName = userName.Replace(SPACE, String.Empty). _
                Replace(QUOTE_SINGLE, String.Empty)

            If userName.Length > 20 Then userName = userName.Substring(0, 20)

            Return userName

        End Function

        ''' <summary>
        ''' Method to Create a Unique Common Name.
        ''' </summary>
        ''' <param name="adConn">The Connection to use to search for clashes.</param>
        ''' <param name="givenName">The Given Name of the User.</param>
        ''' <param name="surName">The Surname of the User.</param>
        ''' <param name="adBase">The Base where the User is being created.</param>
        ''' <returns>The 'Safe' Common Name.</returns>
        ''' <remarks></remarks>
        Private Shared Function CreateUniqueCommonName( _
            ByRef adConn As IConnection, _
            ByVal givenName As String, _
            ByVal surName As String, _
            ByVal adBase As String _
        ) As String

            Dim foundParentEntry As Boolean = False
            Dim parentEntry As DirectoryEntry = adConn.Root

            Do Until foundParentEntry
                If parentEntry.SchemaClassName = adConn.GetDirectorySchemaName(CommonSchemas.DNSDomain) _
                    OrElse parentEntry.Parent Is Nothing _
                    OrElse parentEntry.Path = parentEntry.Parent.Path Then

                    foundParentEntry = True

                Else

                    parentEntry = parentEntry.Parent

                End If
            Loop

            Dim conn As IConnection = _
                AdConnection.ParseConnection(parentEntry)

            Dim commonName As String = givenName & SPACE & surName
            Dim count As Integer = 1
            Dim commonNameSafe As Boolean = False

            Do Until commonNameSafe

                Dim adEntries As DirectoryEntry() = Searcher.ExecuteQuery(conn, SearchScope.SubTree, _
                    New Parameter(adConn.GetDirectoryPropertyName(CommonProperties.CommonName), _
                    commonName, ParameterComparator.EqualTo), False)

                If adEntries Is Nothing OrElse adEntries.Length = 0 Then
                    commonNameSafe = True
                Else
                    If commonName.EndsWith((count - 1).ToString) Then

                        commonName = commonName.Substring(0, commonName.Length - (count - 1).ToString.Length) & _
                        SPACE & count.ToString

                    Else

                        commonName = commonName & SPACE & count.ToString

                    End If
                    count += 1
                End If

            Loop

            Return commonName

        End Function

#End Region

    End Class

End Namespace

