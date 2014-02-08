Namespace Cisco

	''' <summary></summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 17:56:14</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_Cisco\Generated\BridgeForwardingAddressCollection.tt</generator-source>
	''' <generator-template>Text-Templates\Classes\VB_Object.tt</generator-template>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_Cisco\Generated\BridgeForwardingAddressCollection.tt", "1")> _
	<Leviathan.Name(Name:="Forwarding Addresses")> _
	<Leviathan.Collections.ElementType(GetType(BridgeForwardingAddress))> _
	Partial Public Class BridgeForwardingAddressCollection
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
					) As BridgeForwardingAddress
						Get
							Return MyBase.Item(index)
						End Get
						Set(value As BridgeForwardingAddress)
							MyBase.Item(index) = value
						End Set
					End Property

				#End Region

				#Region " Item/Items Properties "

					Default Public Shadows Property Item( _
						ByVal _ForwardingAddress As System.Net.NetworkInformation.PhysicalAddress _
					) As BridgeForwardingAddress
						Get
							For i As Integer = 0 To Me.Count - 1
								If Leviathan.Comparison.Comparer.AreEqual(_ForwardingAddress, Me(i).ForwardingAddress) Then
									Return Me(i)
								End If
							Next
							Return Nothing
						End Get
						Set(ByVal value As BridgeForwardingAddress)
							For i As Integer = 0 To Me.Count - 1
								If Leviathan.Comparison.Comparer.AreEqual(_ForwardingAddress, Me(i).ForwardingAddress) Then
									Me(i) = value
									Exit For
								End If
							Next
						End Set
					End Property

				#End Region

			#End Region

		#End Region

	End Class

End Namespace