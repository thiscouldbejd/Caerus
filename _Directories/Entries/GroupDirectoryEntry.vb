Namespace Directories

    ''' <summary>
    ''' Class for Strongly-Typed Group Directory Entries.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class GroupDirectoryEntry
        Inherits BaseDirectoryEntry

#Region " Private Shared Constants "
        ''' <summary>
        ''' Private Constant to Define the Name of the Method: Add.
        ''' </summary>
        ''' <remarks></remarks>
        Private Const METHOD_ADD As String = "Add"

        ''' <summary>
        ''' Private Constant to Define the Name of the Method: Remove.
        ''' </summary>
        ''' <remarks></remarks>
        Private Const METHOD_REMOVE As String = "Remove"
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
        ''' Public Property which wraps the Display name Field.
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

#End Region

#Region " Public Member Method Overloads "
        ''' <summary>
        ''' Method to Retrieve all the Members of this Group Directory Entry.
        ''' </summary>
        ''' <returns>An Array of Base Directory Entries.</returns>
        ''' <remarks></remarks>
        Public Function Members() As BaseDirectoryEntry()
            Dim connection As IConnection = AdConnection.ParseConnection(Me)
            Return Members(connection)
        End Function

        ''' <summary>
        ''' Method to Retrieve all the Members of this Group Directory Entry.
        ''' </summary>
        ''' <param name="connection">The IConnection used to retrieve the members.</param>
        ''' <returns>An Array of Base Directory Entries.</returns>
        ''' <remarks></remarks>
        Public Function Members(ByVal connection As IConnection) As BaseDirectoryEntry()
            Dim returnList As New ArrayList
            For Each memberDn As String In MyBase.Properties("member")
                Try
                    Dim ad As DirectoryEntry = connection.DirectoryEntry(memberDn)
                    If ad.Properties("objectClass").Contains("user") Then
                        returnList.Add(New UserDirectoryEntry(ad))
                    ElseIf ad.Properties("objectClass").Contains("group") Then
                        returnList.Add(New GroupDirectoryEntry(ad))
                    End If
                Catch
                End Try
            Next
            If Not returnList.Count = 0 Then
                Return returnList.ToArray(GetType(BaseDirectoryEntry))
            Else
                Return New BaseDirectoryEntry() {}
            End If
        End Function

        ''' <summary>
        ''' Method to return the groups to which this Directory Entry belongs.
        ''' </summary>
        ''' <returns>An Array of Base Directory Entries.</returns>
        ''' <remarks></remarks>
        Public Function MemberOf() As BaseDirectoryEntry()
            Dim connection As IConnection = AdConnection.ParseConnection(Me)
            Return MemberOf(connection)
        End Function

        ''' <summary>
        ''' Method to return the groups to which this Directory Entry belongs.
        ''' </summary>
        ''' <param name="connection">The IConnection used to retrieve the groups.</param>
        ''' <returns>An Array of Base Directory Entries.</returns>
        ''' <remarks></remarks>
        Public Function MemberOf(ByVal connection As IConnection) As BaseDirectoryEntry()
            Dim returnList As New ArrayList
            For Each memberOfDn As String In MyBase.Properties("memberOf")
                Try
                    Dim ad As DirectoryEntry = connection.DirectoryEntry(memberOfDn)
                    If ad.Properties("objectClass").Contains("group") Then
                        Dim grp As New GroupDirectoryEntry(ad)
                        returnList.Add(grp)
                        returnList.AddRange(grp.MemberOf(connection))
                    End If
                Catch
                End Try
            Next
            If Not returnList.Count = 0 Then
                Return returnList.ToArray(GetType(BaseDirectoryEntry))
            Else
                Return New BaseDirectoryEntry() {}
            End If
        End Function
#End Region

#Region " Public Add Method Overloads "
        ''' <summary>
        ''' Method to add a Directory Entry to this Group.
        ''' </summary>
        ''' <param name="entryDistinguishedName">The Entry to Add to this Group.</param>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function Add(ByVal entryDistinguishedName As String) As Boolean
            Dim connection As IConnection = AdConnection.ParseConnection(Me)
            Return Add(entryDistinguishedName, connection)
        End Function

        ''' <summary>
        ''' Method to add a Directory Entry to this Group.
        ''' </summary>
        ''' <param name="entryDistinguishedName">The Entry to Add to this Group.</param>
        ''' <param name="connection">The IConnection used in this action.</param>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function Add(ByVal entryDistinguishedName As String, ByVal connection As IConnection) As Boolean
            Dim entry As DirectoryEntry = connection.DirectoryEntry(entryDistinguishedName)
            Return Add(entry)
        End Function

        ''' <summary>
        ''' Method to add a Directory Entry to this Group.
        ''' </summary>
        ''' <param name="entry">The Entry to Add to this Group.</param>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function Add(ByVal entry As DirectoryEntry) As Boolean
            Try
                MyBase.Invoke(METHOD_ADD, New Object() {entry.Path.ToString})
                MyBase.CommitChanges()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
#End Region

#Region " Public Remove Method Overloads "

        ''' <summary>
        ''' Method to remove a Directory Entry to this Group.
        ''' </summary>
        ''' <param name="entryDistinguishedName">The Entry to Remove from this Group.</param>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function Remove( _
            ByVal entryDistinguishedName As String _
        ) As Boolean
            Dim connection As IConnection = AdConnection.ParseConnection(Me)
            Return Remove(entryDistinguishedName, connection)
        End Function

        ''' <summary>
        ''' Method to remove a Directory Entry to this Group.
        ''' </summary>
        ''' <param name="entryDistinguishedName">The Entry to Remove from this Group.</param>
        ''' <param name="connection">The IConnection used in this action.</param>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function Remove( _
            ByVal entryDistinguishedName As String, _
            ByVal connection As IConnection _
        ) As Boolean
            Dim entry As DirectoryEntry = connection.DirectoryEntry(entryDistinguishedName)
            Return Remove(entry)
        End Function

        ''' <summary>
        ''' Method to remove a Directory Entry to this Group.
        ''' </summary>
        ''' <param name="entry">The Entry to Remove from this Group.</param>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Overloads Function Remove( _
            ByVal entry As DirectoryEntry _
        ) As Boolean
            Try
                MyBase.Invoke("Remove", New Object() {entry.Path.ToString})
                MyBase.CommitChanges()
                Return True
            Catch ex As System.Runtime.InteropServices.COMException
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Method to remove all Directory Entres from this Group.
        ''' </summary>
        ''' <returns>A Boolean value indicating whether the Action was successful.</returns>
        ''' <remarks></remarks>
        Public Function RemoveAll() As Boolean

            Dim removeList As New List(Of String)

            For Each memberDn As String In MyBase.Properties("member")
                removeList.Add(memberDn)
            Next

            For i As Integer = 0 To removeList.Count - 1

                If Not Remove(removeList(i)) Then Return False

            Next

            Return True

        End Function

#End Region

#Region " Public Shared Methods "

        Public Shared Function Create( _
            ByRef adConn As IConnection, _
            ByVal groupName As String, _
            ByVal adBase As String _
        ) As GroupDirectoryEntry

            Try

                Dim newGroup As DirectoryEntry = _
                    adConn.CreateDirectoryEntry(adBase, groupName, adConn.GetDirectorySchemaName(CommonSchemas.Group))

                ' Add Group Username
                newGroup.Properties(adConn.GetDirectoryPropertyName(CommonProperties.AccountUsername)) _
                    .Add(groupName)

                newGroup.CommitChanges()


                Return New GroupDirectoryEntry(newGroup)

            Catch ex As Exception

                Return Nothing

            End Try

        End Function

#End Region

    End Class

End Namespace

