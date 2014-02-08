''' <summary>Location Information for an Entity</summary>
''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
''' <generator-date>08/02/2014 17:49:34</generator-date>
''' <generator-functions>1</generator-functions>
''' <generator-source>Caerus\General\Generated\Location.tt</generator-source>
''' <generator-template>Text-Templates\Classes\VB_Object.tt</generator-template>
''' <generator-version>1</generator-version>
<System.CodeDom.Compiler.GeneratedCode("Caerus\General\Generated\Location.tt", "1")> _
<System.Serializable()> _
Partial Public Class Location
	Inherits System.Object
	Implements System.Xml.Serialization.IXmlSerializable

	#Region " Public Constructors "

		''' <summary>Default Constructor</summary>
		Public Sub New()

			MyBase.New()

		End Sub

		''' <summary>Parametered Constructor (1 Parameters)</summary>
		Public Sub New( _
			ByVal _Organisation As System.String _
		)

			MyBase.New()

			Organisation = _Organisation

		End Sub

		''' <summary>Parametered Constructor (2 Parameters)</summary>
		Public Sub New( _
			ByVal _Organisation As System.String, _
			ByVal _Site As System.String _
		)

			MyBase.New()

			Organisation = _Organisation
			Site = _Site

		End Sub

		''' <summary>Parametered Constructor (3 Parameters)</summary>
		Public Sub New( _
			ByVal _Organisation As System.String, _
			ByVal _Site As System.String, _
			ByVal _Block As System.String _
		)

			MyBase.New()

			Organisation = _Organisation
			Site = _Site
			Block = _Block

		End Sub

		''' <summary>Parametered Constructor (4 Parameters)</summary>
		Public Sub New( _
			ByVal _Organisation As System.String, _
			ByVal _Site As System.String, _
			ByVal _Block As System.String, _
			ByVal _Room As System.String _
		)

			MyBase.New()

			Organisation = _Organisation
			Site = _Site
			Block = _Block
			Room = _Room

		End Sub

		''' <summary>Parametered Constructor (5 Parameters)</summary>
		Public Sub New( _
			ByVal _Organisation As System.String, _
			ByVal _Site As System.String, _
			ByVal _Block As System.String, _
			ByVal _Room As System.String, _
			ByVal _Area As System.String _
		)

			MyBase.New()

			Organisation = _Organisation
			Site = _Site
			Block = _Block
			Room = _Room
			Area = _Area

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

		''' <summary>Public Shared Reference to the Name of the Property: Organisation</summary>
		''' <remarks></remarks>
		Public Const PROPERTY_ORGANISATION As String = "Organisation"

		''' <summary>Public Shared Reference to the Name of the Property: Site</summary>
		''' <remarks></remarks>
		Public Const PROPERTY_SITE As String = "Site"

		''' <summary>Public Shared Reference to the Name of the Property: Block</summary>
		''' <remarks></remarks>
		Public Const PROPERTY_BLOCK As String = "Block"

		''' <summary>Public Shared Reference to the Name of the Property: Room</summary>
		''' <remarks></remarks>
		Public Const PROPERTY_ROOM As String = "Room"

		''' <summary>Public Shared Reference to the Name of the Property: Area</summary>
		''' <remarks></remarks>
		Public Const PROPERTY_AREA As String = "Area"

	#End Region

	#Region " Private Variables "

		''' <summary>Private Data Storage Variable for Property: Organisation</summary>
		''' <remarks></remarks>
		Private m_Organisation As System.String

		''' <summary>Private Data Storage Variable for Property: Site</summary>
		''' <remarks></remarks>
		Private m_Site As System.String

		''' <summary>Private Data Storage Variable for Property: Block</summary>
		''' <remarks></remarks>
		Private m_Block As System.String

		''' <summary>Private Data Storage Variable for Property: Room</summary>
		''' <remarks></remarks>
		Private m_Room As System.String

		''' <summary>Private Data Storage Variable for Property: Area</summary>
		''' <remarks></remarks>
		Private m_Area As System.String

	#End Region

	#Region " Public Properties "

		''' <summary>Provides Access to the Property: Organisation</summary>
		''' <remarks></remarks>
		<System.Xml.Serialization.XmlElement(ElementName:="Organisation")> _
		Public Property Organisation() As System.String
			Get
				Return m_Organisation
			End Get
			Set(value As System.String)
				m_Organisation = value
			End Set
		End Property

		''' <summary>Provides Access to the Property: Site</summary>
		''' <remarks></remarks>
		<System.Xml.Serialization.XmlElement(ElementName:="Site")> _
		Public Property Site() As System.String
			Get
				Return m_Site
			End Get
			Set(value As System.String)
				m_Site = value
			End Set
		End Property

		''' <summary>Provides Access to the Property: Block</summary>
		''' <remarks></remarks>
		<System.Xml.Serialization.XmlElement(ElementName:="Block")> _
		Public Property Block() As System.String
			Get
				Return m_Block
			End Get
			Set(value As System.String)
				m_Block = value
			End Set
		End Property

		''' <summary>Provides Access to the Property: Room</summary>
		''' <remarks></remarks>
		<System.Xml.Serialization.XmlElement(ElementName:="Room")> _
		Public Property Room() As System.String
			Get
				Return m_Room
			End Get
			Set(value As System.String)
				m_Room = value
			End Set
		End Property

		''' <summary>Provides Access to the Property: Area</summary>
		''' <remarks></remarks>
		<System.Xml.Serialization.XmlElement(ElementName:="Area")> _
		Public Property Area() As System.String
			Get
				Return m_Area
			End Get
			Set(value As System.String)
				m_Area = value
			End Set
		End Property

	#End Region

End Class