''' <summary>The Speed of an Interface</summary>
''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
''' <generator-date>08/02/2014 17:49:23</generator-date>
''' <generator-functions>1</generator-functions>
''' <generator-source>Caerus\General\Generated\InterfaceSpeed.tt</generator-source>
''' <generator-template>Text-Templates\Classes\VB_Object.tt</generator-template>
''' <generator-version>1</generator-version>
<System.CodeDom.Compiler.GeneratedCode("Caerus\General\Generated\InterfaceSpeed.tt", "1")> _
Partial Public Class InterfaceSpeed
	Inherits System.Object

	#Region " Public Constructors "

		''' <summary>Default Constructor</summary>
		Public Sub New()

			MyBase.New()

		End Sub

		''' <summary>Parametered Constructor (1 Parameters)</summary>
		Public Sub New( _
			ByVal _Value As System.Int64 _
		)

			MyBase.New()

			Value = _Value

		End Sub

	#End Region

	#Region " Public Constants "

		''' <summary>Public Shared Reference to the Name of the Property: Value</summary>
		''' <remarks></remarks>
		Public Const PROPERTY_VALUE As String = "Value"

	#End Region

	#Region " Private Variables "

		''' <summary>Private Data Storage Variable for Property: Value</summary>
		''' <remarks></remarks>
		Private m_Value As System.Int64

	#End Region

	#Region " Public Properties "

		''' <summary>Provides Access to the Property: Value</summary>
		''' <remarks></remarks>
		Public Property Value() As System.Int64
			Get
				Return m_Value
			End Get
			Set(value As System.Int64)
				m_Value = value
			End Set
		End Property

	#End Region

End Class