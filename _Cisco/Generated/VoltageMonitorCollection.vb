Namespace Cisco

	''' <summary></summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 18:05:20</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_Cisco\Generated\VoltageMonitorCollection.tt</generator-source>
	''' <generator-template>Text-Templates\Classes\VB_Object.tt</generator-template>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_Cisco\Generated\VoltageMonitorCollection.tt", "1")> _
	<Leviathan.Name(Name:="Voltage Monitors")> _
	<Leviathan.Collections.ElementType(GetType(VoltageMonitor))> _
	Partial Public Class VoltageMonitorCollection
		Inherits Leviathan.Collections.GeneralCollection

		#Region " Public Constructors "

			''' <summary>Default Constructor</summary>
			Public Sub New()

				MyBase.New()

			End Sub

		#End Region

		#Region " Class Plumbing/Interface Code "

			#Region " Collection Implementation "

				#Region " Public Properties "

					''' <summary>Provides A Strongly Typed Index Property</summary>
					''' <remarks></remarks>
					Default Public Shadows Property Item( _
						ByVal index As System.Int32 _
					) As VoltageMonitor
						Get
							Return MyBase.Item(index)
						End Get
						Set(value As VoltageMonitor)
							MyBase.Item(index) = value
						End Set
					End Property

				#End Region

			#End Region

		#End Region

	End Class

End Namespace