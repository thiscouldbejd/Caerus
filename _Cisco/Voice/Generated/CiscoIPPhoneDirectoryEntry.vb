Namespace Cisco

	''' <summary>Cisco IP-Phone Directory Entry</summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 18:05:49</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_Cisco\Voice\Generated\CiscoIPPhoneDirectoryEntry.tt</generator-source>
	''' <generator-template>Text-Templates\Classes\VB_Object.tt</generator-template>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_Cisco\Voice\Generated\CiscoIPPhoneDirectoryEntry.tt", "1")> _
	Partial Public Class CiscoIPPhoneDirectoryEntry
		Inherits System.Web.UI.WebControls.WebControl
		Implements System.IFormattable

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
				ByVal _Telephone As System.String _
			)

				MyBase.New()

				Name = _Name
				Telephone = _Telephone

			End Sub

		#End Region

		#Region " Class Plumbing/Interface Code "

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

				#End Region

				#Region " Public Methods "

					Public Overloads Overrides Function ToString() As String

						Return Me.ToString(String.Empty, Nothing)

					End Function

					Public Overloads Function ToString( _
						ByVal format As String _
					) As String

						Return String.Empty

					End Function

					Public Overloads Function ToString( _
						ByVal format As String, _
						ByVal formatProvider As System.IFormatProvider _
					) As String Implements System.IFormattable.ToString

						Return String.Empty

					End Function

				#End Region

			#End Region

		#End Region

		#Region " Public Constants "

			''' <summary>Public Shared Reference to the Name of the Property: Name</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_NAME As String = "Name"

			''' <summary>Public Shared Reference to the Name of the Property: Telephone</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_TELEPHONE As String = "Telephone"

		#End Region

		#Region " Private Variables "

			''' <summary>Private Data Storage Variable for Property: Name</summary>
			''' <remarks></remarks>
			Private m_Name As System.String

			''' <summary>Private Data Storage Variable for Property: Telephone</summary>
			''' <remarks></remarks>
			Private m_Telephone As System.String

		#End Region

		#Region " Public Properties "

			''' <summary>Provides Access to the Property: Name</summary>
			''' <remarks></remarks>
			Public Property Name() As System.String
				Get
					Return m_Name
				End Get
				Set(value As System.String)
					m_Name = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: Telephone</summary>
			''' <remarks></remarks>
			Public Property Telephone() As System.String
				Get
					Return m_Telephone
				End Get
				Set(value As System.String)
					m_Telephone = value
				End Set
			End Property

		#End Region

	End Class

End Namespace