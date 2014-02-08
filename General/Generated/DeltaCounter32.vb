''' <summary>General Device Type</summary>
''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
''' <generator-date>08/02/2014 17:47:47</generator-date>
''' <generator-functions>1</generator-functions>
''' <generator-source>Caerus\General\Generated\DeltaCounter32.tt</generator-source>
''' <generator-template>Text-Templates\Classes\VB_Object.tt</generator-template>
''' <generator-version>1</generator-version>
<System.CodeDom.Compiler.GeneratedCode("Caerus\General\Generated\DeltaCounter32.tt", "1")> _
Partial Public Class DeltaCounter32
	Inherits System.Object

	#Region " Public Constructors "

		''' <summary>Default Constructor</summary>
		Public Sub New()

			MyBase.New()

		End Sub

		''' <summary>Parametered Constructor (1 Parameters)</summary>
		Public Sub New( _
			ByVal _LastValue As System.Int64 _
		)

			MyBase.New()

			m_LastValue = _LastValue

		End Sub

		''' <summary>Parametered Constructor (2 Parameters)</summary>
		Public Sub New( _
			ByVal _LastValue As System.Int64, _
			ByVal _LastValueSet As System.DateTime _
		)

			MyBase.New()

			m_LastValue = _LastValue
			m_LastValueSet = _LastValueSet

		End Sub

		''' <summary>Parametered Constructor (3 Parameters)</summary>
		Public Sub New( _
			ByVal _LastValue As System.Int64, _
			ByVal _LastValueSet As System.DateTime, _
			ByVal _CurrentValue As System.Int64 _
		)

			MyBase.New()

			m_LastValue = _LastValue
			m_LastValueSet = _LastValueSet
			m_CurrentValue = _CurrentValue

		End Sub

		''' <summary>Parametered Constructor (4 Parameters)</summary>
		Public Sub New( _
			ByVal _LastValue As System.Int64, _
			ByVal _LastValueSet As System.DateTime, _
			ByVal _CurrentValue As System.Int64, _
			ByVal _CurrentValueSet As System.DateTime _
		)

			MyBase.New()

			m_LastValue = _LastValue
			m_LastValueSet = _LastValueSet
			m_CurrentValue = _CurrentValue
			m_CurrentValueSet = _CurrentValueSet

		End Sub

	#End Region

	#Region " Public Constants "

		''' <summary>Public Shared Reference to the Name of the Property: LastValue</summary>
		''' <remarks></remarks>
		Public Const PROPERTY_LASTVALUE As String = "LastValue"

		''' <summary>Public Shared Reference to the Name of the Property: LastValueSet</summary>
		''' <remarks></remarks>
		Public Const PROPERTY_LASTVALUESET As String = "LastValueSet"

		''' <summary>Public Shared Reference to the Name of the Property: CurrentValue</summary>
		''' <remarks></remarks>
		Public Const PROPERTY_CURRENTVALUE As String = "CurrentValue"

		''' <summary>Public Shared Reference to the Name of the Property: CurrentValueSet</summary>
		''' <remarks></remarks>
		Public Const PROPERTY_CURRENTVALUESET As String = "CurrentValueSet"

	#End Region

	#Region " Private Variables "

		''' <summary>Private Data Storage Variable for Property: LastValue</summary>
		''' <remarks></remarks>
		Private m_LastValue As System.Int64

		''' <summary>Private Data Storage Variable for Property: LastValueSet</summary>
		''' <remarks></remarks>
		Private m_LastValueSet As System.DateTime

		''' <summary>Private Data Storage Variable for Property: CurrentValue</summary>
		''' <remarks></remarks>
		Private m_CurrentValue As System.Int64

		''' <summary>Private Data Storage Variable for Property: CurrentValueSet</summary>
		''' <remarks></remarks>
		Private m_CurrentValueSet As System.DateTime

	#End Region

	#Region " Public Properties "

		''' <summary>Provides Access to the Property: LastValue</summary>
		''' <remarks></remarks>
		Public ReadOnly Property LastValue() As System.Int64
			Get
				Return m_LastValue
			End Get
		End Property

		''' <summary>Provides Access to the Property: LastValueSet</summary>
		''' <remarks></remarks>
		Public ReadOnly Property LastValueSet() As System.DateTime
			Get
				Return m_LastValueSet
			End Get
		End Property

		''' <summary>Provides Access to the Property: CurrentValue</summary>
		''' <remarks></remarks>
		Public ReadOnly Property CurrentValue() As System.Int64
			Get
				Return m_CurrentValue
			End Get
		End Property

		''' <summary>Provides Access to the Property: CurrentValueSet</summary>
		''' <remarks></remarks>
		Public ReadOnly Property CurrentValueSet() As System.DateTime
			Get
				Return m_CurrentValueSet
			End Get
		End Property

	#End Region

End Class