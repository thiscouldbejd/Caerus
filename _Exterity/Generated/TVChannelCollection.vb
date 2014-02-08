Namespace Exterity

	''' <summary></summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 18:14:14</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_Exterity\Generated\TVChannelCollection.tt</generator-source>
	''' <generator-template>Text-Templates\Classes\VB_Object.tt</generator-template>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_Exterity\Generated\TVChannelCollection.tt", "1")> _
	<Leviathan.Name(Name:="TV Channels")> _
	<Leviathan.Collections.ElementType(GetType(TVChannel))> _
	Partial Public Class TVChannelCollection
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
					) As TVChannel
						Get
							Return MyBase.Item(index)
						End Get
						Set(value As TVChannel)
							MyBase.Item(index) = value
						End Set
					End Property

				#End Region

				#Region " Item/Items Properties "

					Default Public Shadows Property Item( _
						ByVal _Uri As System.String _
					) As TVChannel
						Get
							For i As Integer = 0 To Me.Count - 1
								If Leviathan.Comparison.Comparer.AreEqual(_Uri, Me(i).Uri) Then
									Return Me(i)
								End If
							Next
							Return Nothing
						End Get
						Set(ByVal value As TVChannel)
							For i As Integer = 0 To Me.Count - 1
								If Leviathan.Comparison.Comparer.AreEqual(_Uri, Me(i).Uri) Then
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