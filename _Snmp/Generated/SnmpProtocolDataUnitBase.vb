Namespace Snmp

	''' <summary></summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 18:27:06</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_Snmp\Generated\SnmpProtocolDataUnitBase.tt</generator-source>
	''' <generator-template>Text-Templates\Classes\VB_Object.tt</generator-template>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_Snmp\Generated\SnmpProtocolDataUnitBase.tt", "1")> _
	Partial Public MustInherit Class SnmpProtocolDataUnitBase
		Inherits SnmpLengthedBase

		#Region " Public Constructors "

			''' <summary>Default Constructor</summary>
			Public Sub New()

				MyBase.New()

				m_Error = SnmpErrorStatus.NO_ERROR
				m_VariableBindings = New SnmpVariableBind() {}
			End Sub

			''' <summary>Parametered Constructor (1 Parameters)</summary>
			Public Sub New( _
				ByVal _Type As SnmpDataType _
			)

				MyBase.New()

				[Type] = _Type

				m_Error = SnmpErrorStatus.NO_ERROR
				m_VariableBindings = New SnmpVariableBind() {}
			End Sub

			''' <summary>Parametered Constructor (2 Parameters)</summary>
			Public Sub New( _
				ByVal _Type As SnmpDataType, _
				ByVal _RequestId As System.Int64 _
			)

				MyBase.New()

				[Type] = _Type
				RequestId = _RequestId

				m_Error = SnmpErrorStatus.NO_ERROR
				m_VariableBindings = New SnmpVariableBind() {}
			End Sub

			''' <summary>Parametered Constructor (3 Parameters)</summary>
			Public Sub New( _
				ByVal _Type As SnmpDataType, _
				ByVal _RequestId As System.Int64, _
				ByVal _Error As SnmpErrorStatus _
			)

				MyBase.New()

				[Type] = _Type
				RequestId = _RequestId
				[Error] = _Error

				m_VariableBindings = New SnmpVariableBind() {}
			End Sub

			''' <summary>Parametered Constructor (4 Parameters)</summary>
			Public Sub New( _
				ByVal _Type As SnmpDataType, _
				ByVal _RequestId As System.Int64, _
				ByVal _Error As SnmpErrorStatus, _
				ByVal _ErrorIndex As System.Int64 _
			)

				MyBase.New()

				[Type] = _Type
				RequestId = _RequestId
				[Error] = _Error
				ErrorIndex = _ErrorIndex

				m_VariableBindings = New SnmpVariableBind() {}
			End Sub

			''' <summary>Parametered Constructor (5 Parameters)</summary>
			Public Sub New( _
				ByVal _Type As SnmpDataType, _
				ByVal _RequestId As System.Int64, _
				ByVal _Error As SnmpErrorStatus, _
				ByVal _ErrorIndex As System.Int64, _
				ByVal _VariableBindings As SnmpVariableBind() _
			)

				MyBase.New()

				[Type] = _Type
				RequestId = _RequestId
				[Error] = _Error
				ErrorIndex = _ErrorIndex
				VariableBindings = _VariableBindings

			End Sub

		#End Region

		#Region " Public Constants "

			''' <summary>Public Shared Reference to the Name of the Property: Type</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_TYPE As String = "Type"

			''' <summary>Public Shared Reference to the Name of the Property: RequestId</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_REQUESTID As String = "RequestId"

			''' <summary>Public Shared Reference to the Name of the Property: Error</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_ERROR As String = "Error"

			''' <summary>Public Shared Reference to the Name of the Property: ErrorIndex</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_ERRORINDEX As String = "ErrorIndex"

			''' <summary>Public Shared Reference to the Name of the Property: VariableBindings</summary>
			''' <remarks></remarks>
			Public Const PROPERTY_VARIABLEBINDINGS As String = "VariableBindings"

		#End Region

		#Region " Private Variables "

			''' <summary>Private Data Storage Variable for Property: Type</summary>
			''' <remarks></remarks>
			Private m_Type As SnmpDataType

			''' <summary>Private Data Storage Variable for Property: RequestId</summary>
			''' <remarks></remarks>
			Private m_RequestId As System.Int64

			''' <summary>Private Data Storage Variable for Property: Error</summary>
			''' <remarks></remarks>
			Private m_Error As SnmpErrorStatus

			''' <summary>Private Data Storage Variable for Property: ErrorIndex</summary>
			''' <remarks></remarks>
			Private m_ErrorIndex As System.Int64

			''' <summary>Private Data Storage Variable for Property: VariableBindings</summary>
			''' <remarks></remarks>
			Private m_VariableBindings As SnmpVariableBind()

		#End Region

		#Region " Public Properties "

			''' <summary>Provides Access to the Property: Type</summary>
			''' <remarks></remarks>
			Public Property [Type]() As SnmpDataType
				Get
					Return m_Type
				End Get
				Set(value As SnmpDataType)
					m_Type = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: RequestId</summary>
			''' <remarks></remarks>
			Public Property RequestId() As System.Int64
				Get
					Return m_RequestId
				End Get
				Set(value As System.Int64)
					m_RequestId = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: Error</summary>
			''' <remarks></remarks>
			Public Property [Error]() As SnmpErrorStatus
				Get
					Return m_Error
				End Get
				Set(value As SnmpErrorStatus)
					m_Error = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: ErrorIndex</summary>
			''' <remarks></remarks>
			Public Property ErrorIndex() As System.Int64
				Get
					Return m_ErrorIndex
				End Get
				Set(value As System.Int64)
					m_ErrorIndex = value
				End Set
			End Property

			''' <summary>Provides Access to the Property: VariableBindings</summary>
			''' <remarks></remarks>
			Public Property VariableBindings() As SnmpVariableBind()
				Get
					Return m_VariableBindings
				End Get
				Set(value As SnmpVariableBind())
					m_VariableBindings = value
				End Set
			End Property

		#End Region

	End Class

End Namespace