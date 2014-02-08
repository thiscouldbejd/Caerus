Namespace Directories

    ''' <summary>
    ''' Class for Strongly-Typed Computer Directory Entries.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ComputerDirectoryEntry
        Inherits AccountDirectoryEntry

#Region " Public Properties "

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
        ''' Public Property which wraps the DNS Host Name Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DnsHostName() As String
            Get
                Return MyBase.Properties("dNSHostName").Value
            End Get
            Set(ByVal Value As String)
                MyBase.Properties("dNSHostName").Value = Value
                MyBase.CommitChanges()
            End Set
        End Property

        ''' <summary>
        ''' Public Property which provides Access to a Strongly Type IP Host Entry.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DnsName() As System.Net.IPHostEntry
            Get
                Dim ip As New System.Net.IPHostEntry()
                ip.HostName = DnsHostName
                Return ip
            End Get
        End Property

        ''' <summary>
        ''' Public Property which wraps the Operating System Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property OperatingSystem() As String
            Get
                Return MyBase.Properties("operatingSystem").Value
            End Get
        End Property

        ''' <summary>
        ''' Public Property which wraps the Operating System Service Patch Version Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property OperatingSystemServicePack() As String
            Get
                Return MyBase.Properties("operatingSystemServicePack").Value
            End Get
        End Property

        ''' <summary>
        ''' Public Property which wraps the Operating System Version Field.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property OperatingSystemVersion() As String
            Get
                Return MyBase.Properties("operatingSystemValue").Value
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

