''' <summary>Health Details for an Entity</summary>
''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
''' <generator-date>08/02/2014 17:49:02</generator-date>
''' <generator-functions>1</generator-functions>
''' <generator-source>Caerus\General\Generated\Health.tt</generator-source>
''' <generator-template>Text-Templates\Classes\VB_Object.tt</generator-template>
''' <generator-version>1</generator-version>
<System.CodeDom.Compiler.GeneratedCode("Caerus\General\Generated\Health.tt", "1")> _
<System.Serializable()> _
Partial Public Class Health
	Inherits System.Object
	Implements System.Xml.Serialization.IXmlSerializable

	#Region " Public Constructors "

		''' <summary>Default Constructor</summary>
		Public Sub New()

			MyBase.New()

		End Sub

		''' <summary>Parametered Constructor (1 Parameters)</summary>
		Public Sub New( _
			ByVal _Status As HealthStatus _
		)

			MyBase.New()

			Status = _Status

		End Sub

		''' <summary>Parametered Constructor (2 Parameters)</summary>
		Public Sub New( _
			ByVal _Status As HealthStatus, _
			ByVal _Details As System.String _
		)

			MyBase.New()

			Status = _Status
			Details = _Details

		End Sub

	#End Region

	#Region " Class Plumbing/Interface Code "

		#Region " IXmlSerialisable Implementation "

			#Region " Public Methods "

				''' <summary>Method to Return Schema Depicting Object/Class</summary>
				''' <remarks></remarks>
				Public Function IXmlSerialisable_GetSchema() As System.Xml.Schema.XmlSchema Implements System.Xml.Serialization.IXmlSerializable.GetSchema
					Return Leviathan.Configuration.XmlSerialiser.GenerateSchema(Me.GetType)
				End Function

				''' <summary></summary>
				''' <remarks></remarks>
				Public Sub IXmlSerialisable_ReadXml( _
					ByVal reader As System.Xml.XmlReader _
				) Implements System.Xml.Serialization.IXmlSerializable.ReadXml
					Leviathan.Configuration.XmlSerialiser.ReadXml(Me, reader)
				End Sub

				''' <summary></summary>
				''' <remarks></remarks>
				Public Sub IXmlSerialisable_WriteXml( _
					ByVal writer As System.Xml.XmlWriter _
				) Implements System.Xml.Serialization.IXmlSerializable.WriteXml
					Leviathan.Configuration.XmlSerialiser.WriteXml(Me, writer)
				End Sub

			#End Region

		#End Region

	#End Region

	#Region " Public Constants "

		''' <summary>Public Shared Reference to the Name of the Property: Status</summary>
		''' <remarks></remarks>
		Public Const PROPERTY_STATUS As String = "Status"

		''' <summary>Public Shared Reference to the Name of the Property: Details</summary>
		''' <remarks></remarks>
		Public Const PROPERTY_DETAILS As String = "Details"

	#End Region

	#Region " Private Variables "

		''' <summary>Private Data Storage Variable for Property: Status</summary>
		''' <remarks></remarks>
		Private m_Status As HealthStatus

		''' <summary>Private Data Storage Variable for Property: Details</summary>
		''' <remarks></remarks>
		Private m_Details As System.String

	#End Region

	#Region " Public Properties "

		''' <summary>Provides Access to the Property: Status</summary>
		''' <remarks></remarks>
		<System.Xml.Serialization.XmlElement(ElementName:="Status")> _
		Public Property Status() As HealthStatus
			Get
				Return m_Status
			End Get
			Set(value As HealthStatus)
				m_Status = value
			End Set
		End Property

		''' <summary>Provides Access to the Property: Details</summary>
		''' <remarks></remarks>
		<System.Xml.Serialization.XmlElement(ElementName:="Details")> _
		Public Property Details() As System.String
			Get
				Return m_Details
			End Get
			Set(value As System.String)
				m_Details = value
			End Set
		End Property

	#End Region

End Class