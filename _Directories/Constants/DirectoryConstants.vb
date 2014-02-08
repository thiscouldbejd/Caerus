Namespace Directories

	''' <summary>
	''' Class Holding All Directory Constants.
	''' </summary>
	''' <remarks></remarks>
	Public Class DirectoryConstants

		#Region " Private Shared Variables "

			Private Shared ResType As Type = GetType(DirectoryConstants)

		#End Region

		#Region " Public Shared Variables "

			''' <summary>
			''' Provides Access to an Log Message for the Created Profile Directory Base.
			''' </summary>
			''' <remarks></remarks>
			Public Shared LOG_CREATEDPROFILEDIRBASE As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_LOG, _
			"directoryCreatedProfileDirBase")

			''' <summary>
			''' Provides Access to an Log Message for the Created Home Directory Base.
			''' </summary>
			''' <remarks></remarks>
			Public Shared LOG_CREATEDHOMEDIRBASE As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_LOG, _
			"directoryCreatedHomeDirBase")

			''' <summary>
			''' Provides Access to an Log Message for the Account Username.
			''' </summary>
			''' <remarks></remarks>
			Public Shared LOG_ACCOUNTUSERNAME As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_LOG, _
			"directoryAccountUsername")

			''' <summary>
			''' Provides Access to an Log Message for the Account Username.
			''' </summary>
			''' <remarks></remarks>
			Public Shared LOG_ACCOUNTPASSWORD As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_LOG, _
			"directoryAccountPassword")

			''' <summary>
			''' Provides Access to an Log Message for the Account Username.
			''' </summary>
			''' <remarks></remarks>
			Public Shared LOG_ACCOUNTPHONETICPASSWORD As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_LOG, _
			"directoryAccountPasswordPhonetic")

			''' <summary>
			''' Provides Access to an Log Message for Created Account.
			''' </summary>
			''' <remarks></remarks>
			Public Shared LOG_CREATEDACCOUNT As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_LOG, _
			"directoryCreatedAccount")

			''' <summary>
			''' Provides Access to an Log Message for Created Account.
			''' </summary>
			''' <remarks></remarks>
			Public Shared LOG_ADDEDTOGROUPS As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_LOG, _
			"directoryAddedToGroups")

			''' <summary>
			''' Provides Access to an Log Message for Set Home Directory Security.
			''' </summary>
			''' <remarks></remarks>
			Public Shared LOG_SETHOMEDIRECTORYSECURITY As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_LOG, _
			"directorySetHomeDirSecurity")

		#End Region

	End Class

End Namespace