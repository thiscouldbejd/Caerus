Namespace Directories

    ''' <summary>
    ''' Class to Provide Strongly Typed Read-Only Properties around a Directory Entry.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ReadOnlyStrongDirectoryEntryBase
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
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property CommonName() As String
            Get
                Return MyBase.Properties("cn").Value
            End Get
        End Property

        ''' <summary>
        ''' Provides Generic Access to Properties of the Directory Entry.
        ''' </summary>
        ''' <param name="propertyName">The Name of the Property to Retrieve.</param>
        ''' <returns>The Property Value Object or Nothing.</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property GeneralProperty(ByVal propertyName As String) As Object
            Get
                If MyBase.Properties.Contains(propertyName) Then
                    Return MyBase.Properties(propertyName)
                Else
                    Return Nothing
                End If
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

    End Class

End Namespace

