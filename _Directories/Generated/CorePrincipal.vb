Namespace Directories

	''' <summary>This Class Effectively wraps an IIdentity Object with a Display Name and Custom Roles/Groups</summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 18:10:15</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_Directories\Generated\CorePrincipal.tt</generator-source>
	''' <generator-template>Text-Templates\Classes\VB_Object.tt</generator-template>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_Directories\Generated\CorePrincipal.tt", "1")> _
	Partial Public Class CorePrincipal
		Inherits System.Object

		#Region " Public Constructors "

			''' <summary>Default Constructor</summary>
			Public Sub New()

				MyBase.New()

				m_Roles = New ArrayList
			End Sub

			''' <summary>Parametered Constructor (1 Parameters)</summary>
			Public Sub New( _
				ByVal _Identity As System.Security.Principal.IIdentity _
			)

				MyBase.New()

				m_Identity = _Identity

				m_Roles = New ArrayList
			End Sub

			''' <summary>Parametered Constructor (2 Parameters)</summary>
			Public Sub New( _
				ByVal _Identity As System.Security.Principal.IIdentity, _
				ByVal _Roles As ArrayList _
			)

				MyBase.New()

				m_Identity = _Identity
				m_Roles = _Roles

			End Sub

			''' <summary>Parametered Constructor (3 Parameters)</summary>
			Public Sub New( _
				ByVal _Identity As System.Security.Principal.IIdentity, _
				ByVal _Roles As ArrayList, _
				ByVal _DisplayName As System.String _
			)

				MyBase.New()

				m_Identity = _Identity
				m_Roles = _Roles
				DisplayName = _DisplayName

			End Sub

			''' <summary>Parametered Constructor (4 Parameters)</summary>
			Public Sub New( _
				ByVal _Identity As System.Security.Principal.IIdentity, _
				ByVal _Roles As ArrayList, _
				ByVal _DisplayName As System.String, _
				ByVal _EmailAddress As System.String _
			)

				MyBase.New()

				m_Identity = _Identity
				m_Roles = _Roles
				DisplayName = _DisplayName
				EmailAddress = _EmailAddress

			End Sub

			''' <summary>Parametered Constructor (5 Parameters)</summary>
			Public Sub New( _
				ByVal _Identity As System.Security.Principal.IIdentity, _
				ByVal _Roles As ArrayList, _
				ByVal _DisplayName As System.String, _
				ByVal _EmailAddress As System.String, _
				ByVal _Id As System.Guid _
			)

				MyBase.New()

				m_Identity = _Identity
				m_Roles = _Roles
				DisplayName = _DisplayName
				EmailAddress = _EmailAddress
				Id = _Id

			End Sub

		#End Region

		#Region " Class Plumbing/Interface Code "

			#Region " Settable Implementation "

				#Region " Public Methods "

					Public Function SetDisplayName(_DisplayName As System.String) As CorePrincipal

						DisplayName = _DisplayName
						Return Me

					End Function

					Public Function SetEmailAddress(_EmailAddress As System.String) As CorePrincipal

						EmailAddress = _EmailAddress
						Return Me

					End Function

					Public Function SetId(_Id As System.Guid) As CorePrincipal

						Id = _Id
						Return Me

					End Function

				#End Region

			#End Region

		#End Region

		#Region " Public Constants "

			''' <summary>Public Shared Reference to the Name of the Property: Identity</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_IDENTITY As String = "Identity"

			''' <summary>Public Shared Reference to the Name of the Property: Roles</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_ROLES As String = "Roles"

			''' <summary>Public Shared Reference to the Name of the Property: DisplayName</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_DISPLAYNAME As String = "DisplayName"

			''' <summary>Public Shared Reference to the Name of the Property: EmailAddress</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_EMAILADDRESS As String = "EmailAddress"

			''' <summary>Public Shared Reference to the Name of the Property: Id</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_ID As String = "Id"

		#End Region

		#Region " Private Variables "

			''' <summary>Private Data Storage Variable for Property: Identity</summary>
			''' <remarks></remarks>
			Private m_Identity As System.Security.Principal.IIdentity

			''' <summary>Private Data Storage Variable for Property: Roles</summary>
			''' <remarks></remarks>
			Private m_Roles As ArrayList

			''' <summary>Private Data Storage Variable for Property: DisplayName</summary>
			''' <remarks></remarks>
			Private m_DisplayName As System.String

			''' <summary>Private Data Storage Variable for Property: EmailAddress</summary>
			''' <remarks></remarks>
			Private m_EmailAddress As System.String

			''' <summary>Private Data Storage Variable for Property: Id</summary>
			''' <remarks></remarks>
			Private m_Id As System.Guid

		#End Region

		#Region " Public Properties "

			''' <summary>Provides Access to the Property: Identity</summary>
			''' <remarks></remarks>
			Public ReadOnly Property Identity() As System.Security.Principal.IIdentity Implements System.Security.Principal.IPrincipal.Identity
				Get
					Return m_Identity
				End Get
			End Property

			''' <summary>Provides Access to the Property: DisplayName</summary>
			''' <remarks></remarks>
			Public Property DisplayName() As System.String
				Get
					Return m_DisplayName
				End Get
				Set(value As System.String)
					m_DisplayName = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: EmailAddress</summary>
			''' <remarks></remarks>
			Public Property EmailAddress() As System.String
				Get
					Return m_EmailAddress
				End Get
				Set(value As System.String)
					m_EmailAddress = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: Id</summary>
			''' <remarks></remarks>
			Public Property Id() As System.Guid
				Get
					Return m_Id
				End Get
				Set(value As System.Guid)
					m_Id = value
				End Set
			End Property

		#End Region

	End Class

End Namespace