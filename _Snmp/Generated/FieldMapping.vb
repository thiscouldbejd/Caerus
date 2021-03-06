Namespace Snmp

	''' <summary>Snmp Field Mapping Class</summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 18:26:21</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_Snmp\Generated\FieldMapping.tt</generator-source>
	''' <generator-template>Text-Templates\Classes\VB_Object.tt</generator-template>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_Snmp\Generated\FieldMapping.tt", "1")> _
	<System.Serializable()> _
	Partial Public Class FieldMapping
		Inherits System.Object
		Implements System.IComparable
		Implements System.Xml.Serialization.IXmlSerializable

		#Region " Public Constructors "

			''' <summary>Default Constructor</summary>
			Public Sub New()

				MyBase.New()

			End Sub

			''' <summary>Parametered Constructor (1 Parameters)</summary>
			Public Sub New( _
				ByVal _Name As System.String _
			)

				MyBase.New()

				Name = _Name

			End Sub

			''' <summary>Parametered Constructor (2 Parameters)</summary>
			Public Sub New( _
				ByVal _Name As System.String, _
				ByVal _Value As System.String _
			)

				MyBase.New()

				Name = _Name
				Value = _Value

			End Sub

			''' <summary>Parametered Constructor (3 Parameters)</summary>
			Public Sub New( _
				ByVal _Name As System.String, _
				ByVal _Value As System.String, _
				ByVal _OidToEnum As System.String _
			)

				MyBase.New()

				Name = _Name
				Value = _Value
				OidToEnum = _OidToEnum

			End Sub

			''' <summary>Parametered Constructor (4 Parameters)</summary>
			Public Sub New( _
				ByVal _Name As System.String, _
				ByVal _Value As System.String, _
				ByVal _OidToEnum As System.String, _
				ByVal _Transient As System.Boolean _
			)

				MyBase.New()

				Name = _Name
				Value = _Value
				OidToEnum = _OidToEnum
				Transient = _Transient

			End Sub

			''' <summary>Parametered Constructor (5 Parameters)</summary>
			Public Sub New( _
				ByVal _Name As System.String, _
				ByVal _Value As System.String, _
				ByVal _OidToEnum As System.String, _
				ByVal _Transient As System.Boolean, _
				ByVal _Member As Leviathan.Inspection.MemberAnalyser _
			)

				MyBase.New()

				Name = _Name
				Value = _Value
				OidToEnum = _OidToEnum
				Transient = _Transient
				Member = _Member

			End Sub

		#End Region

		#Region " Class Plumbing/Interface Code "

			#Region " IComparable Implementation "

				#Region " Public Methods "

					''' <summary>Comparison Method</summary>
					Public Overridable Function IComparable_CompareTo( _
						ByVal value As System.Object _
					) As System.Int32 Implements System.IComparable.CompareTo

						Dim typed_Value As FieldMapping = TryCast(value, FieldMapping)

						If typed_Value Is Nothing Then

							Throw New ArgumentException(String.Format("Value is not of comparable type: {0}", value.GetType.Name), "Value")

						Else

							Dim return_Value As Integer = 0

							If Not Me.Value Is Nothing Then return_Value = Me.Value.CompareTo(typed_Value.Value)
							If return_Value <> 0 Then Return return_Value

							Return return_Value

						End If

					End Function

				#End Region

			#End Region

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

			''' <summary>Public Shared Reference to the Name of the Property: Name</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_NAME As String = "Name"

			''' <summary>Public Shared Reference to the Name of the Property: Value</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_VALUE As String = "Value"

			''' <summary>Public Shared Reference to the Name of the Property: OidToEnum</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_OIDTOENUM As String = "OidToEnum"

			''' <summary>Public Shared Reference to the Name of the Property: Transient</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_TRANSIENT As String = "Transient"

			''' <summary>Public Shared Reference to the Name of the Property: Member</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_MEMBER As String = "Member"

		#End Region

		#Region " Private Variables "

			''' <summary>Private Data Storage Variable for Property: Name</summary>
			''' <remarks></remarks>
			Private m_Name As System.String

			''' <summary>Private Data Storage Variable for Property: Value</summary>
			''' <remarks></remarks>
			Private m_Value As System.String

			''' <summary>Private Data Storage Variable for Property: OidToEnum</summary>
			''' <remarks></remarks>
			Private m_OidToEnum As System.String

			''' <summary>Private Data Storage Variable for Property: Transient</summary>
			''' <remarks></remarks>
			Private m_Transient As System.Boolean

			''' <summary>Private Data Storage Variable for Property: Member</summary>
			''' <remarks></remarks>
			Private m_Member As Leviathan.Inspection.MemberAnalyser

		#End Region

		#Region " Public Properties "

			''' <summary>Provides Access to the Property: Name</summary>
			''' <remarks></remarks>
			<System.Xml.Serialization.XmlElement(ElementName:="Name")> _
			Public Property Name() As System.String
				Get
					Return m_Name
				End Get
				Set(value As System.String)
					m_Name = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: Value</summary>
			''' <remarks></remarks>
			<System.Xml.Serialization.XmlElement(ElementName:="Value")> _
			Public Property Value() As System.String
				Get
					Return m_Value
				End Get
				Set(value As System.String)
					m_Value = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: OidToEnum</summary>
			''' <remarks></remarks>
			<System.Xml.Serialization.XmlElement(ElementName:="OidToEnum")> _
			Public Property OidToEnum() As System.String
				Get
					Return m_OidToEnum
				End Get
				Set(value As System.String)
					m_OidToEnum = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: Transient</summary>
			''' <remarks></remarks>
			<System.Xml.Serialization.XmlElement(ElementName:="Transient")> _
			Public Property Transient() As System.Boolean
				Get
					Return m_Transient
				End Get
				Set(value As System.Boolean)
					m_Transient = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: Member</summary>
			''' <remarks></remarks>
			<System.Xml.Serialization.XmlElement(ElementName:="Member")> _
			Public Property Member() As Leviathan.Inspection.MemberAnalyser
				Get
					Return m_Member
				End Get
				Set(value As Leviathan.Inspection.MemberAnalyser)
					m_Member = value
				End Set
			End Property

		#End Region

	End Class

End Namespace