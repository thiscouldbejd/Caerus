Namespace QNAP

	''' <summary>Class Representing a Volume in a QNAP Storage System</summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 18:25:59</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_QNAP\Generated\Volume.tt</generator-source>
	''' <generator-template>Text-Templates\Classes\VB_Object.tt</generator-template>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_QNAP\Generated\Volume.tt", "1")> _
	<System.Serializable()> _
	Partial Public Class Volume
		Inherits System.Object
		Implements System.IComparable
		Implements System.IFormattable
		Implements System.Xml.Serialization.IXmlSerializable

		#Region " Public Constructors "

			''' <summary>Default Constructor</summary>
			Public Sub New()

				MyBase.New()

			End Sub

			''' <summary>Parametered Constructor (1 Parameters)</summary>
			Public Sub New( _
				ByVal _Index As System.Int32 _
			)

				MyBase.New()

				Index = _Index

			End Sub

			''' <summary>Parametered Constructor (2 Parameters)</summary>
			Public Sub New( _
				ByVal _Index As System.Int32, _
				ByVal _Description As System.String _
			)

				MyBase.New()

				Index = _Index
				Description = _Description

			End Sub

			''' <summary>Parametered Constructor (3 Parameters)</summary>
			Public Sub New( _
				ByVal _Index As System.Int32, _
				ByVal _Description As System.String, _
				ByVal _FileSystem As System.String _
			)

				MyBase.New()

				Index = _Index
				Description = _Description
				FileSystem = _FileSystem

			End Sub

			''' <summary>Parametered Constructor (4 Parameters)</summary>
			Public Sub New( _
				ByVal _Index As System.Int32, _
				ByVal _Description As System.String, _
				ByVal _FileSystem As System.String, _
				ByVal _Size As System.String _
			)

				MyBase.New()

				Index = _Index
				Description = _Description
				FileSystem = _FileSystem
				Size = _Size

			End Sub

			''' <summary>Parametered Constructor (5 Parameters)</summary>
			Public Sub New( _
				ByVal _Index As System.Int32, _
				ByVal _Description As System.String, _
				ByVal _FileSystem As System.String, _
				ByVal _Size As System.String, _
				ByVal _Free As System.String _
			)

				MyBase.New()

				Index = _Index
				Description = _Description
				FileSystem = _FileSystem
				Size = _Size
				Free = _Free

			End Sub

			''' <summary>Parametered Constructor (6 Parameters)</summary>
			Public Sub New( _
				ByVal _Index As System.Int32, _
				ByVal _Description As System.String, _
				ByVal _FileSystem As System.String, _
				ByVal _Size As System.String, _
				ByVal _Free As System.String, _
				ByVal _Status As System.String _
			)

				MyBase.New()

				Index = _Index
				Description = _Description
				FileSystem = _FileSystem
				Size = _Size
				Free = _Free
				Status = _Status

			End Sub

		#End Region

		#Region " Class Plumbing/Interface Code "

			#Region " IComparable Implementation "

				#Region " Public Methods "

					''' <summary>Comparison Method</summary>
					Public Overridable Function IComparable_CompareTo( _
						ByVal value As System.Object _
					) As System.Int32 Implements System.IComparable.CompareTo

						Dim typed_Value As Volume = TryCast(value, Volume)

						If typed_Value Is Nothing Then

							Throw New ArgumentException(String.Format("Value is not of comparable type: {0}", value.GetType.Name), "Value")

						Else

							Dim return_Value As Integer = 0

							return_Value = Index.CompareTo(typed_Value.Index)
							If return_Value <> 0 Then Return return_Value

							Return return_Value

						End If

					End Function

				#End Region

			#End Region

			#Region " IFormattable Implementation "

				#Region " Public Constants "

					''' <summary>Public Shared Reference to the Name of the Property: AsString</summary>
					''' <remarks></remarks>
					Public Const PROPERTY_ASSTRING As String = "AsString"

				#End Region

				#Region " Public Properties "

					''' <summary></summary>
					''' <remarks></remarks>
					Public ReadOnly Property AsString() As System.String
						Get
							Return Me.ToString()
						End Get
					End Property

				#End Region

				#Region " Public Shared Methods "

					Public Shared Function ToString_default( _
						ByVal Description As System.String, _
						ByVal Size As System.String _
					) As String

						Return String.Format( _
							"{0} ({1})", _
							Description, _
							Size)

					End Function

				#End Region

				#Region " Public Methods "

					Public Overloads Overrides Function ToString() As String

						Return Me.ToString(String.Empty, Nothing)

					End Function

					Public Overloads Function ToString( _
						ByVal format As String _
					) As String

						If String.IsNullOrEmpty(format) OrElse String.Compare(format, "default", True) = 0 Then

							Return ToString_default( _
								Description, _
								Size _
							)

						End If

						Return String.Empty

					End Function

					Public Overloads Function ToString( _
						ByVal format As String, _
						ByVal formatProvider As System.IFormatProvider _
					) As String Implements System.IFormattable.ToString

						If String.IsNullOrEmpty(format) OrElse String.Compare(format, "default", True) = 0 Then	

							Return ToString_default( _
								Description, _
								Size _
							)

						End If

						Return String.Empty

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

			''' <summary>Public Shared Reference to the Name of the Property: Index</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_INDEX As String = "Index"

			''' <summary>Public Shared Reference to the Name of the Property: Description</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_DESCRIPTION As String = "Description"

			''' <summary>Public Shared Reference to the Name of the Property: FileSystem</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_FILESYSTEM As String = "FileSystem"

			''' <summary>Public Shared Reference to the Name of the Property: Size</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_SIZE As String = "Size"

			''' <summary>Public Shared Reference to the Name of the Property: Free</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_FREE As String = "Free"

			''' <summary>Public Shared Reference to the Name of the Property: Status</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_STATUS As String = "Status"

		#End Region

		#Region " Private Variables "

			''' <summary>Private Data Storage Variable for Property: Index</summary>
			''' <remarks></remarks>
			Private m_Index As System.Int32

			''' <summary>Private Data Storage Variable for Property: Description</summary>
			''' <remarks></remarks>
			Private m_Description As System.String

			''' <summary>Private Data Storage Variable for Property: FileSystem</summary>
			''' <remarks></remarks>
			Private m_FileSystem As System.String

			''' <summary>Private Data Storage Variable for Property: Size</summary>
			''' <remarks></remarks>
			Private m_Size As System.String

			''' <summary>Private Data Storage Variable for Property: Free</summary>
			''' <remarks></remarks>
			Private m_Free As System.String

			''' <summary>Private Data Storage Variable for Property: Status</summary>
			''' <remarks></remarks>
			Private m_Status As System.String

		#End Region

		#Region " Public Properties "

			''' <summary>Provides Access to the Property: Index</summary>
			''' <remarks></remarks>
			<System.Xml.Serialization.XmlElement(ElementName:="Index")> _
			Public Property Index() As System.Int32
				Get
					Return m_Index
				End Get
				Set(value As System.Int32)
					m_Index = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: Description</summary>
			''' <remarks></remarks>
			<System.Xml.Serialization.XmlElement(ElementName:="Description")> _
			Public Property Description() As System.String
				Get
					Return m_Description
				End Get
				Set(value As System.String)
					m_Description = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: FileSystem</summary>
			''' <remarks></remarks>
			<System.Xml.Serialization.XmlElement(ElementName:="FileSystem")> _
			Public Property FileSystem() As System.String
				Get
					Return m_FileSystem
				End Get
				Set(value As System.String)
					m_FileSystem = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: Size</summary>
			''' <remarks></remarks>
			<System.Xml.Serialization.XmlElement(ElementName:="Size")> _
			Public Property Size() As System.String
				Get
					Return m_Size
				End Get
				Set(value As System.String)
					m_Size = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: Free</summary>
			''' <remarks></remarks>
			<System.Xml.Serialization.XmlElement(ElementName:="Free")> _
			Public Property Free() As System.String
				Get
					Return m_Free
				End Get
				Set(value As System.String)
					m_Free = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: Status</summary>
			''' <remarks></remarks>
			<System.Xml.Serialization.XmlElement(ElementName:="Status")> _
			Public Property Status() As System.String
				Get
					Return m_Status
				End Get
				Set(value As System.String)
					m_Status = value
				End Set
			End Property

		#End Region

	End Class

End Namespace