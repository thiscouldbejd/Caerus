Namespace Directories

	''' <summary></summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 18:11:15</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_Directories\Providers\Generated\AdPrincipleProvider.tt</generator-source>
	''' <generator-template>Text-Templates\Classes\VB_Object.tt</generator-template>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_Directories\Providers\Generated\AdPrincipleProvider.tt", "1")> _
	Partial Public Class AdPrincipleProvider
		Inherits System.Object

		#Region " Public Constructors "

			''' <summary>Default Constructor</summary>
			Public Sub New()

				MyBase.New()

				m_AdUserFieldMapping = "sAMAccountName"
				m_AdUseSSL = True
				CreateConnection()

			End Sub

			''' <summary>Parametered Constructor (1 Parameters)</summary>
			Public Sub New( _
				ByVal _AdUserFieldMapping As System.String _
			)

				MyBase.New()

				AdUserFieldMapping = _AdUserFieldMapping

				m_AdUseSSL = True
				CreateConnection()

			End Sub

			''' <summary>Parametered Constructor (2 Parameters)</summary>
			Public Sub New( _
				ByVal _AdUserFieldMapping As System.String, _
				ByVal _AdUseSSL As System.Boolean _
			)

				MyBase.New()

				AdUserFieldMapping = _AdUserFieldMapping
				AdUseSSL = _AdUseSSL

				CreateConnection()

			End Sub

			''' <summary>Parametered Constructor (3 Parameters)</summary>
			Public Sub New( _
				ByVal _AdUserFieldMapping As System.String, _
				ByVal _AdUseSSL As System.Boolean, _
				ByVal _AdUserImpersonate As System.String _
			)

				MyBase.New()

				AdUserFieldMapping = _AdUserFieldMapping
				AdUseSSL = _AdUseSSL
				AdUserImpersonate = _AdUserImpersonate

				CreateConnection()

			End Sub

			''' <summary>Parametered Constructor (4 Parameters)</summary>
			Public Sub New( _
				ByVal _AdUserFieldMapping As System.String, _
				ByVal _AdUseSSL As System.Boolean, _
				ByVal _AdUserImpersonate As System.String, _
				ByVal _AuthType As AuthenticationType _
			)

				MyBase.New()

				AdUserFieldMapping = _AdUserFieldMapping
				AdUseSSL = _AdUseSSL
				AdUserImpersonate = _AdUserImpersonate
				AuthType = _AuthType

				CreateConnection()

			End Sub

			''' <summary>Parametered Constructor (5 Parameters)</summary>
			Public Sub New( _
				ByVal _AdUserFieldMapping As System.String, _
				ByVal _AdUseSSL As System.Boolean, _
				ByVal _AdUserImpersonate As System.String, _
				ByVal _AuthType As AuthenticationType, _
				ByVal _AdServer As System.String _
			)

				MyBase.New()

				AdUserFieldMapping = _AdUserFieldMapping
				AdUseSSL = _AdUseSSL
				AdUserImpersonate = _AdUserImpersonate
				AuthType = _AuthType
				AdServer = _AdServer

				CreateConnection()

			End Sub

			''' <summary>Parametered Constructor (6 Parameters)</summary>
			Public Sub New( _
				ByVal _AdUserFieldMapping As System.String, _
				ByVal _AdUseSSL As System.Boolean, _
				ByVal _AdUserImpersonate As System.String, _
				ByVal _AuthType As AuthenticationType, _
				ByVal _AdServer As System.String, _
				ByVal _AdBase As System.String _
			)

				MyBase.New()

				AdUserFieldMapping = _AdUserFieldMapping
				AdUseSSL = _AdUseSSL
				AdUserImpersonate = _AdUserImpersonate
				AuthType = _AuthType
				AdServer = _AdServer
				AdBase = _AdBase

				CreateConnection()

			End Sub

			''' <summary>Parametered Constructor (7 Parameters)</summary>
			Public Sub New( _
				ByVal _AdUserFieldMapping As System.String, _
				ByVal _AdUseSSL As System.Boolean, _
				ByVal _AdUserImpersonate As System.String, _
				ByVal _AuthType As AuthenticationType, _
				ByVal _AdServer As System.String, _
				ByVal _AdBase As System.String, _
				ByVal _AdUsername As System.String _
			)

				MyBase.New()

				AdUserFieldMapping = _AdUserFieldMapping
				AdUseSSL = _AdUseSSL
				AdUserImpersonate = _AdUserImpersonate
				AuthType = _AuthType
				AdServer = _AdServer
				AdBase = _AdBase
				AdUsername = _AdUsername

				CreateConnection()

			End Sub

			''' <summary>Parametered Constructor (8 Parameters)</summary>
			Public Sub New( _
				ByVal _AdUserFieldMapping As System.String, _
				ByVal _AdUseSSL As System.Boolean, _
				ByVal _AdUserImpersonate As System.String, _
				ByVal _AuthType As AuthenticationType, _
				ByVal _AdServer As System.String, _
				ByVal _AdBase As System.String, _
				ByVal _AdUsername As System.String, _
				ByVal _AdPassword As System.String _
			)

				MyBase.New()

				AdUserFieldMapping = _AdUserFieldMapping
				AdUseSSL = _AdUseSSL
				AdUserImpersonate = _AdUserImpersonate
				AuthType = _AuthType
				AdServer = _AdServer
				AdBase = _AdBase
				AdUsername = _AdUsername
				AdPassword = _AdPassword

				CreateConnection()

			End Sub

			''' <summary>Parametered Constructor (9 Parameters)</summary>
			Public Sub New( _
				ByVal _AdUserFieldMapping As System.String, _
				ByVal _AdUseSSL As System.Boolean, _
				ByVal _AdUserImpersonate As System.String, _
				ByVal _AuthType As AuthenticationType, _
				ByVal _AdServer As System.String, _
				ByVal _AdBase As System.String, _
				ByVal _AdUsername As System.String, _
				ByVal _AdPassword As System.String, _
				ByVal _Cn As AdConnection _
			)

				MyBase.New()

				AdUserFieldMapping = _AdUserFieldMapping
				AdUseSSL = _AdUseSSL
				AdUserImpersonate = _AdUserImpersonate
				AuthType = _AuthType
				AdServer = _AdServer
				AdBase = _AdBase
				AdUsername = _AdUsername
				AdPassword = _AdPassword
				Cn = _Cn

				CreateConnection()

			End Sub

		#End Region

		#Region " Public Constants "

			''' <summary>Public Shared Reference to the Name of the Property: AdUserFieldMapping</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_ADUSERFIELDMAPPING As String = "AdUserFieldMapping"

			''' <summary>Public Shared Reference to the Name of the Property: AdUseSSL</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_ADUSESSL As String = "AdUseSSL"

			''' <summary>Public Shared Reference to the Name of the Property: AdUserImpersonate</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_ADUSERIMPERSONATE As String = "AdUserImpersonate"

			''' <summary>Public Shared Reference to the Name of the Property: AuthType</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_AUTHTYPE As String = "AuthType"

			''' <summary>Public Shared Reference to the Name of the Property: AdServer</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_ADSERVER As String = "AdServer"

			''' <summary>Public Shared Reference to the Name of the Property: AdBase</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_ADBASE As String = "AdBase"

			''' <summary>Public Shared Reference to the Name of the Property: AdUsername</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_ADUSERNAME As String = "AdUsername"

			''' <summary>Public Shared Reference to the Name of the Property: AdPassword</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_ADPASSWORD As String = "AdPassword"

			''' <summary>Public Shared Reference to the Name of the Property: Cn</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_CN As String = "Cn"

		#End Region

		#Region " Private Variables "

			''' <summary>Private Data Storage Variable for Property: AdUserFieldMapping</summary>
			''' <remarks></remarks>
			Private m_AdUserFieldMapping As System.String

			''' <summary>Private Data Storage Variable for Property: AdUseSSL</summary>
			''' <remarks></remarks>
			Private m_AdUseSSL As System.Boolean

			''' <summary>Private Data Storage Variable for Property: AdUserImpersonate</summary>
			''' <remarks></remarks>
			Private m_AdUserImpersonate As System.String

			''' <summary>Private Data Storage Variable for Property: AuthType</summary>
			''' <remarks></remarks>
			Private m_AuthType As AuthenticationType

			''' <summary>Private Data Storage Variable for Property: AdServer</summary>
			''' <remarks></remarks>
			Private m_AdServer As System.String

			''' <summary>Private Data Storage Variable for Property: AdBase</summary>
			''' <remarks></remarks>
			Private m_AdBase As System.String

			''' <summary>Private Data Storage Variable for Property: AdUsername</summary>
			''' <remarks></remarks>
			Private m_AdUsername As System.String

			''' <summary>Private Data Storage Variable for Property: AdPassword</summary>
			''' <remarks></remarks>
			Private m_AdPassword As System.String

			''' <summary>Private Data Storage Variable for Property: Cn</summary>
			''' <remarks></remarks>
			Private m_Cn As AdConnection

		#End Region

		#Region " Public Properties "

			''' <summary>Provides Access to the Property: AdUserFieldMapping</summary>
			''' <remarks></remarks>
			<Leviathan.Configuration.Configurable("AdUserFieldMapping")> _
			Public Property AdUserFieldMapping() As System.String
				Get
					Return m_AdUserFieldMapping
				End Get
				Set(value As System.String)
					m_AdUserFieldMapping = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: AdUseSSL</summary>
			''' <remarks></remarks>
			<Leviathan.Configuration.Configurable("AdUseSSL")> _
			Public Property AdUseSSL() As System.Boolean
				Get
					Return m_AdUseSSL
				End Get
				Set(value As System.Boolean)
					m_AdUseSSL = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: AdUserImpersonate</summary>
			''' <remarks></remarks>
			<Leviathan.Configuration.Configurable("AdUserImpersonate")> _
			Public Property AdUserImpersonate() As System.String
				Get
					Return m_AdUserImpersonate
				End Get
				Set(value As System.String)
					m_AdUserImpersonate = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: AuthType</summary>
			''' <remarks></remarks>
			<Leviathan.Configuration.Configurable("AuthType")> _
			Public Property AuthType() As AuthenticationType
				Get
					Return m_AuthType
				End Get
				Set(value As AuthenticationType)
					m_AuthType = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: AdServer</summary>
			''' <remarks></remarks>
			<Leviathan.Configuration.Configurable("AdServer")> _
			Public Property AdServer() As System.String
				Get
					Return m_AdServer
				End Get
				Set(value As System.String)
					m_AdServer = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: AdBase</summary>
			''' <remarks></remarks>
			<Leviathan.Configuration.Configurable("AdBase")> _
			Public Property AdBase() As System.String
				Get
					Return m_AdBase
				End Get
				Set(value As System.String)
					m_AdBase = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: AdUsername</summary>
			''' <remarks></remarks>
			<Leviathan.Configuration.Configurable("AdUsername")> _
			Public Property AdUsername() As System.String
				Get
					Return m_AdUsername
				End Get
				Set(value As System.String)
					m_AdUsername = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: AdPassword</summary>
			''' <remarks></remarks>
			<Leviathan.Configuration.Configurable("AdPassword")> _
			Public Property AdPassword() As System.String
				Get
					Return m_AdPassword
				End Get
				Set(value As System.String)
					m_AdPassword = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: Cn</summary>
			''' <remarks></remarks>
			Public Property Cn() As AdConnection
				Get
					Return m_Cn
				End Get
				Set(value As AdConnection)
					m_Cn = value
				End Set
			End Property

		#End Region

	End Class

End Namespace