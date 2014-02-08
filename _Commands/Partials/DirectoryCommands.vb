Imports Caerus.Directories
Imports Caerus.Directories.DirectoryConstants
Imports Leviathan.Visualisation
Imports System.IO
Imports System.Security
Imports System.Text
Imports IT = Leviathan.Visualisation.InformationType

Namespace Commands

	Partial Public Class DirectoryCommands

		#Region " Private Structures "

			Private Structure ConnectionDetails

				Public Server As String

				Public LDAPRoot As String

				Public Username As String

				Public Password As String

				Public Sub New( _
					ByVal server As String, _
					ByVal ldapRoot As String, _
					ByVal username As String, _
					ByVal password As String _
				)

					Me.Server = server
					Me.LDAPRoot = ldapRoot
					Me.Username = username
					Me.Password = password

				End Sub

			End Structure

		#End Region

		#Region " Private Methods "

			Private Function CreateDirectory( _
				ByVal directoryPath As String, _
				ByVal domainName As String, _
				ByVal userName As String _
			) As Boolean

				Dim secDescSuccess As Boolean = False

				If Not directoryPath = Nothing Then

					Try

						If Not Directory.Exists(directoryPath) Then Directory.CreateDirectory(directoryPath)

						Dim secDesc As System.Security.AccessControl.DirectorySecurity = Directory.GetAccessControl(directoryPath)

						Dim idReference As New Principal.NTAccount(domainName, userName)

						secDesc.ModifyAccessRule(System.Security.AccessControl.AccessControlModification.Add, _
							New AccessControl.FileSystemAccessRule(idReference, AccessControl.FileSystemRights.Modify, _
							AccessControl.InheritanceFlags.ObjectInherit Or AccessControl.InheritanceFlags.ContainerInherit, _
							AccessControl.PropagationFlags.None, AccessControl.AccessControlType.Allow), secDescSuccess)

						Directory.SetAccessControl(directoryPath, secDesc)

					Catch ex As Exception
					End Try

				End If

				Return secDescSuccess

			End Function

			Private Function CreateAccount( _
				ByVal connection As IConnection, _
				ByVal ldapRoot As String, _
				ByVal givenName As String, _
				ByVal surName As String, _
				ByVal userName As String, _
				ByVal passWord As String, _
				ByVal description As String, _
				ByVal department As String, _
				ByVal profileDirBase As String, _
				ByVal homeDirBase As String, _
				ByVal homeDirDrive As String, _
				ByVal principleNameSuffix As String, _
				ByVal accountGroups As String() _
			) As IFixedWidthWriteable

				Dim resultRow As New Row()

				If Not Directory.Exists(profileDirBase) Then

					Directory.CreateDirectory(profileDirBase)
					resultRow.Add(True)

				Else

					resultRow.Add(False)

				End If

				If Not Directory.Exists(homeDirBase) Then

					Directory.CreateDirectory(homeDirBase)
					resultRow.Add(True)

				Else

					resultRow.Add(False)

				End If

				Dim userAccountPhoneticPassword As String = Nothing

				Dim userAccount As UserDirectoryEntry

				If String.IsNullOrEmpty(passWord) AndAlso String.IsNullOrEmpty(userName) Then

					userAccount = UserDirectoryEntry.CreateWithUsername(connection, givenName, surName, description, department, profileDirBase, homeDirBase, _
						homeDirDrive, principleNameSuffix, ldapRoot, userName, passWord, userAccountPhoneticPassword)

				Else

					userAccount = UserDirectoryEntry.Create(connection, userName, passWord, givenName, surName, description, department, profileDirBase, _
						homeDirBase, homeDirDrive, principleNameSuffix, ldapRoot, userAccountPhoneticPassword)

				End If

				If Not userAccount Is Nothing Then

					Dim domainName As String = CStr(connection.Root.Properties(connection.GetDirectoryPropertyName(CommonProperties.DomainController))(0))

					' Write Account Created Log Entry
					resultRow.Add(True)

					' Write Account Username Log Entry
					resultRow.Add(userName)

					' Write Password Log Entry
					resultRow.Add(passWord)

					' Write Phonetic Password Created Log Entry
					resultRow.Add(userAccountPhoneticPassword)

					Dim addedGroups As Boolean = True

					If Not accountGroups Is Nothing AndAlso accountGroups.Length > 0 Then

						For i As Integer = 0 To accountGroups.Length - 1

							Dim groups As System.DirectoryServices.DirectoryEntry() = Searcher.ExecuteQuery(connection, SearchScope.SubTree, New Parameter( _
								connection.GetDirectoryPropertyName(CommonProperties.CommonName), accountGroups(i), ParameterComparator.EqualTo), False)

							If Not groups Is Nothing AndAlso groups.Length = 1 Then

								userAccount.AddToGroup(groups(0))
								If Not addedGroups = False Then addedGroups = True

							Else

								addedGroups = False

							End If

						Next

					End If

					' Write Groups Added Log Entry
					If addedGroups Then

						resultRow.Add(True)

					Else

						resultRow.Add(False)

					End If

					Dim userHomeDirectory As String = CStr(userAccount.Properties(connection.GetDirectoryPropertyName(CommonProperties.HomeDirectory))(0))

					' Create Home Directory and Write Set Security Log Entry
					If CreateDirectory(userHomeDirectory, domainName, userName) Then

						resultRow.Add(True)

					Else

						resultRow.Add(False)

					End If

				Else

					' Write Account Created Log Entry
					resultRow.Add(False)

				End If

				Return Cube.Create(IT.Information, "Account Creation Results", LOG_CREATEDPROFILEDIRBASE, LOG_CREATEDHOMEDIRBASE, LOG_CREATEDACCOUNT, _
					LOG_ACCOUNTUSERNAME, LOG_ACCOUNTPASSWORD, LOG_ACCOUNTPHONETICPASSWORD, LOG_ADDEDTOGROUPS, LOG_SETHOMEDIRECTORYSECURITY).Add( _
					New Slice(New List(Of Row)(New Row() {resultRow})))

			End Function

		#End Region

		#Region " Command Processing Methods "

			<Command( _
				ResourceContainingType:=GetType(DirectoryCommands), _
				ResourceName:="CommandDetails", _
				Name:="create-account", _
				Description:="@commandDirectoryDescriptionCreateAccount@" _
			)> _
			Public Function ProcessCommandCreate( _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionServer@" _
				)> _
				ByVal connectionServer As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionRoot@" _
				)> _
				ByVal connectionLDAPRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionUsername@" _
				)> _
				ByVal connectionUsername As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionPassword@" _
				)> _
				ByVal connectionPassword As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionEntryRoot@" _
				)> _
				ByVal ldapRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountGivenname@" _
				)> _
				ByVal givenName As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountSurname@" _
				)> _
				ByVal surName As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountUsername@" _
				)> _
				ByVal userName As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountPassword@" _
				)> _
				ByVal passWord As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountDescription@" _
				)> _
				ByVal description As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountDepartment@" _
				)> _
				ByVal department As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountProfile@" _
				)> _
				ByVal profileDirBase As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountHome@" _
				)> _
				ByVal homeDirBase As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountDrive@" _
				)> _
				ByVal homeDirDrive As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountSuffix@" _
				)> _
				ByVal principleNameSuffix As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountGroups@" _
				)> _
				ByVal accountGroups As String() _
			) As IFixedWidthWriteable

				Return CreateAccount(New AdConnection(AuthenticationType.Basic, connectionLDAPRoot, connectionServer, connectionUsername, _
					connectionPassword), ldapRoot, givenName, surName, userName, passWord, description, department, profileDirBase, homeDirBase, _
					homeDirDrive, principleNameSuffix, accountGroups)

			End Function

			<Command( _
				ResourceContainingType:=GetType(DirectoryCommands), _
				ResourceName:="CommandDetails", _
				Name:="create-account", _
				Description:="@commandDirectoryDescriptionCreateAccount@" _
			)> _
			Public Function ProcessCommandCreate( _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionServer@" _
				)> _
				ByVal connectionServer As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionRoot@" _
				)> _
				ByVal connectionLDAPRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionUsername@" _
				)> _
				ByVal connectionUsername As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionPassword@" _
				)> _
				ByVal connectionPassword As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionEntryRoot@" _
				)> _
				ByVal lDAPRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountGivenname@" _
				)> _
				ByVal givenName As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountSurname@" _
				)> _
				ByVal surName As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountDescription@" _
				)> _
				ByVal description As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountDepartment@" _
				)> _
				ByVal department As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountProfile@" _
				)> _
				ByVal profileDirBase As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountHome@" _
				)> _
				ByVal homeDirBase As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountDrive@" _
				)> _
				ByVal homeDirDrive As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountSuffix@" _
				)> _
				ByVal principleNameSuffix As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountGroups@" _
				)> _
				ByVal accountGroups As String() _
			) As IFixedWidthWriteable

				Return CreateAccount(New AdConnection(AuthenticationType.Basic, connectionLDAPRoot, connectionServer, connectionUsername, _
					connectionPassword), ldapRoot, givenName, surName, Nothing, Nothing, description, department, profileDirBase, homeDirBase, homeDirDrive, _
					principleNameSuffix, accountGroups)

			End Function

			<Command( _
				ResourceContainingType:=GetType(DirectoryCommands), _
				ResourceName:="CommandDetails", _
				Name:="create-group", _
				Description:="@commandDirectoryDescriptionCreateGroup@" _
			)> _
			Public Function ProcessCommandCreateGroup( _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionServer@" _
				)> _
				ByVal connectionServer As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionRoot@" _
				)> _
				ByVal connectionLDAPRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionUsername@" _
				)> _
				ByVal connectionUsername As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionPassword@" _
				)> _
				ByVal connectionPassword As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionEntryRoot@" _
				)> _
				ByVal lDAPRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionGroupName@" _
				)> _
				ByVal groupName As String _
			) As Boolean

				Dim dirConn As IConnection = New AdConnection(AuthenticationType.Basic, connectionLDAPRoot, connectionServer, connectionUsername, _
					connectionPassword)

				Dim groupEntry As GroupDirectoryEntry = GroupDirectoryEntry.Create(dirConn, groupName, lDAPRoot)

				If Not groupEntry Is Nothing Then

					Return True

				Else

					Return False

				End If

			End Function

			<Command( _
				ResourceContainingType:=GetType(DirectoryCommands), _
				ResourceName:="CommandDetails", _
				Name:="get-user", _
				Description:="@commandDirectoryDescriptionGetUser@" _
			)> _
			Public Function ProcessCommandGetUser( _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionServer@" _
				)> _
				ByVal connectionServer As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionRoot@" _
				)> _
				ByVal connectionLDAPRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionUsername@" _
				)> _
				ByVal connectionUsername As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionPassword@" _
				)> _
				ByVal connectionPassword As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionEntryRoot@" _
				)> _
				ByVal ldapRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountUsername@" _
				)> _
				ByVal userName As String _
			) As UserDirectoryEntry

				Dim dirConn As IConnection = New AdConnection(AuthenticationType.Basic, connectionLDAPRoot, connectionServer, connectionUsername, _
					connectionPassword)

				Dim userAccounts As System.DirectoryServices.DirectoryEntry() = Searcher.ExecuteQuery(dirConn, SearchScope.SubTree, _
					New Parameter(dirConn.GetDirectoryPropertyName(CommonProperties.AccountUsername), userName, ParameterComparator.EqualTo), True)

				If Not userAccounts Is Nothing AndAlso userAccounts.Length = 1 Then

					Return CType(userAccounts(0), UserDirectoryEntry)

				Else

					Return Nothing

				End If

			End Function

			<Command( _
				ResourceContainingType:=GetType(DirectoryCommands), _
				ResourceName:="CommandDetails", _
				Name:="get-user", _
				Description:="@commandDirectoryDescriptionGetUser@" _
			)> _
			Public Function ProcessCommandGetUser( _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionServer@" _
				)> _
				ByVal connectionServer As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionRoot@" _
				)> _
				ByVal connectionLDAPRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionUsername@" _
				)> _
				ByVal connectionUsername As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionPassword@" _
				)> _
				ByVal connectionPassword As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionAccountId@" _
				)> _
				ByVal userId As Guid _
			) As UserDirectoryEntry

				Dim dirConn As IConnection = New AdConnection(AuthenticationType.Basic, connectionLDAPRoot, connectionServer, connectionUsername, _
					connectionPassword)

				Dim dirEntry As System.DirectoryServices.DirectoryEntry = dirConn.DirectoryEntry(userId)

				If Not dirEntry Is Nothing Then

					Return New UserDirectoryEntry(dirEntry)

				Else

					Return Nothing

				End If

			End Function

			<Command( _
				ResourceContainingType:=GetType(DirectoryCommands), _
				ResourceName:="CommandDetails", _
				Name:="get-group", _
				Description:="@commandDirectoryDescriptionGetGroup@" _
			)> _
			Public Function ProcessCommandGetGroup( _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionServer@" _
				)> _
				ByVal connectionServer As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionRoot@" _
				)> _
				ByVal connectionLDAPRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionUsername@" _
				)> _
				ByVal connectionUsername As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionPassword@" _
				)> _
				ByVal connectionPassword As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionEntryRoot@" _
				)> _
				ByVal ldapRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionGroupName@" _
				)> _
				ByVal groupName As String _
			) As GroupDirectoryEntry

				Dim dirConn As IConnection = New AdConnection(AuthenticationType.Basic, connectionLDAPRoot, connectionServer, connectionUsername, _
					connectionPassword)

				Dim groups As System.DirectoryServices.DirectoryEntry() = Searcher.ExecuteQuery(dirConn, SearchScope.SubTree, _
					New Parameter(dirConn.GetDirectoryPropertyName(CommonProperties.CommonName), groupName, ParameterComparator.EqualTo), True)

				If Not groups Is Nothing AndAlso groups.Length = 1 Then

					Return CType(groups(0), GroupDirectoryEntry)

				Else

					Return Nothing

				End If

			End Function

			<Command( _
				ResourceContainingType:=GetType(DirectoryCommands), _
				ResourceName:="CommandDetails", _
				Name:="get-groups", _
				Description:="@commandDirectoryDescriptionGetGroups@" _
			)> _
			Public Function ProcessCommandGetGroups( _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionServer@" _
				)> _
				ByVal connectionServer As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionRoot@" _
				)> _
				ByVal connectionLDAPRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionUsername@" _
				)> _
				ByVal connectionUsername As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionPassword@" _
				)> _
				ByVal connectionPassword As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionEntryRoot@" _
				)> _
				ByVal ldapRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionGroupName@" _
				)> _
				ByVal groupName As String _
			) As GroupDirectoryEntry()

				Dim dirConn As IConnection = New AdConnection(AuthenticationType.Basic, connectionLDAPRoot, connectionServer, connectionUsername, _
					connectionPassword)

				Dim groups As System.DirectoryServices.DirectoryEntry() = Searcher.ExecuteQuery(dirConn, SearchScope.SubTree, _
					New Parameter(dirConn.GetDirectoryPropertyName(CommonProperties.DisplayName), groupName, ParameterComparator.EqualTo), True)

				Dim return_List As New List(Of GroupDirectoryEntry)

				If Not groups Is Nothing Then

					For i As Integer = 0 To groups.Length - 1

						If Not groups(i) Is Nothing AndAlso groups(i).GetType Is GetType(GroupDirectoryEntry) Then return_List.Add(CType(groups(i), GroupDirectoryEntry))
					Next

				End If

				Return return_List.ToArray()

			End Function

			<Command( _
				ResourceContainingType:=GetType(DirectoryCommands), _
				ResourceName:="CommandDetails", _
				Name:="get-computer", _
				Description:="@commandDirectoryDescriptionGetComputer@" _
			)> _
			Public Function ProcessCommandGetComputer( _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionServer@" _
				)> _
				ByVal connectionServer As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionRoot@" _
				)> _
				ByVal connectionLDAPRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionUsername@" _
				)> _
				ByVal connectionUsername As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionConnectionPassword@" _
				)> _
				ByVal connectionPassword As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionEntryRoot@" _
				)> _
				ByVal ldapRoot As String, _
				<Configurable( _
					ResourceContainingType:=GetType(DirectoryCommands), _
					ResourceName:="CommandDetails", _
					Description:="@commandDirectoryParameterDescriptionComputerName@" _
				)> _
				ByVal computerName As String _
			) As ComputerDirectoryEntry

				Dim dirConn As IConnection = New AdConnection(AuthenticationType.Basic, connectionLDAPRoot, connectionServer, connectionUsername, _
					connectionPassword)

				If Not computerName.EndsWith(DOLLAR) Then computerName = computerName & DOLLAR

				Dim computers As System.DirectoryServices.DirectoryEntry() = Searcher.ExecuteQuery(dirConn, SearchScope.SubTree, _
					New Parameter(dirConn.GetDirectoryPropertyName(CommonProperties.AccountUsername), computerName, ParameterComparator.EqualTo), True)

				If Not computers Is Nothing AndAlso computers.Length = 1 Then

					Return CType(computers(0), ComputerDirectoryEntry)

				Else

					Return Nothing

				End If

			End Function

		#End Region

	End Class

End Namespace