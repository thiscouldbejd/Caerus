Namespace Directories

    ''' <summary>
    ''' Base Class for Strongly-Typed Directory Entries.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BaseDirectoryEntry
        Inherits DirectoryEntry

#Region " Public Properties "
        ''' <summary>
        ''' Public Property to Return a Strongly Typed Guid Representing the Native ID of the Directory Entry
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Id() As Guid
            Get
                Return New Guid(MyBase.NativeGuid)
            End Get
        End Property

        ''' <summary>
        ''' Public Property to Access the 'cn' Property of the Directory Entry.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CommonName() As String
            Get
                Return MyBase.Properties("cn").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("cn").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Provides Generic Access to Properties of the Directory Entry.
        ''' </summary>
        ''' <param name="propertyName">The Name of the Property to Retrieve.</param>
        ''' <value></value>
        ''' <returns>The Property Value Object or Nothing.</returns>
        ''' <remarks></remarks>
        Public Property GeneralProperty(ByVal propertyName As String) As Object
            Get
                If MyBase.Properties.Contains(propertyName) Then
                    Return MyBase.Properties(propertyName)
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal Value As Object)
                Try
                    If MyBase.Properties.Contains(propertyName) Then
                        MyBase.Properties(propertyName)(0) = Value
                    Else
                        MyBase.Properties(propertyName).Add(Value)
                    End If
                Catch ex As Exception
                    Throw New Exception("Could not set Active Directory Property", ex)
                End Try
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
            MyBase.New(entry.Path, entry.Username, String.Empty, entry.AuthenticationType)

            Dim ty As System.Type = entry.GetType
            Dim meth As System.Reflection.MethodInfo = ty.GetMethod("GetPassword", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
            If Not meth Is Nothing Then
                MyBase.Password = meth.Invoke(entry, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing)
            End If
        End Sub
#End Region

#Region " Public Methods "
        ''' <summary>
        ''' Public Method to Move this Directory Entry to a new Position in the Directory Service.
        ''' </summary>
        ''' <param name="parentDistinguishedName">The DN/Distinguished Name of the Parent Object/Container
        ''' to move this object into.</param>
        ''' <returns>A Boolean value indicating whether the move was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function Move(ByVal parentDistinguishedName As String) As Boolean
            Dim connection As IConnection = AdConnection.ParseConnection(Me)
            Return Move(parentDistinguishedName, connection)
        End Function

        ''' <summary>
        ''' Public Method to Move this Directory Entry to a new Position in the Directory Service.
        ''' </summary>
        ''' <param name="parentDistinguishedName">The DN/Distinguished Name of the Parent Object/Container
        ''' to move this object into.</param>
        ''' <param name="connection">The Connection to the Parent DN.</param>
        ''' <returns>A Boolean value indicating whether the move was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function Move(ByVal parentDistinguishedName As String, ByVal connection As IConnection) As Boolean
            Dim parent As DirectoryEntry = connection.DirectoryEntry(parentDistinguishedName)
            Return Move(parent)
        End Function

        ''' <summary>
        ''' Public Method to Move this Directory Entry to a new Position in the Directory Service.
        ''' </summary>
        ''' <param name="parent">The Parent Object/Container to move this object into.</param>
        ''' <returns>A Boolean value indicating whether the move was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function Move(ByVal parent As DirectoryEntry) As Boolean
            Try
                Me.MoveTo(parent)
                Me.CommitChanges()
                Return True
            Catch ex As System.Runtime.InteropServices.COMException
                Return False
            End Try
        End Function
#End Region

#Region " Public Shared Methods "
        ''' <summary>
        ''' Public Shared Method that parses a Full Username into it's username constituent part.
        ''' </summary>
        ''' <param name="fullUsername">The full username.</param>
        ''' <returns>A string representing the Username.</returns>
        ''' <remarks>This method can handle usernames in the format of username,
        ''' DOMAIN\username or username@domain.</remarks>
        Public Shared Function ParseUsername(ByVal fullUsername As String) As String
            If fullUsername.IndexOf("\") > 0 Then
                Return fullUsername.Split("\")(1)
            ElseIf fullUsername.IndexOf("@") > 0 Then
                Return fullUsername.Split("@")(0)
            Else
                Return fullUsername
            End If
        End Function

        ''' <summary>
        ''' Public Shared Method that parses a Full Username and Domain into a SAM Format Username.
        ''' </summary>
        ''' <param name="fullUsername">The full username.</param>
        ''' <param name="domainName">The domain name is use.</param>
        ''' <returns>A string representing the SAM Username in the format DOMAIN\Username.</returns>
        ''' <remarks></remarks>
        Public Shared Function ParseSamUsername(ByVal fullUsername As String, ByVal domainName As String) As String
            Dim strBuilder As New System.Text.StringBuilder
            strBuilder.Append(ParseUsername(fullUsername))
            strBuilder.Append("\")
            strBuilder.Append(domainName)
            Return strBuilder.ToString
        End Function
#End Region

    End Class

End Namespace
