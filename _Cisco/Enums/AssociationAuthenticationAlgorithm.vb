Namespace Cisco

	''' <summary></summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 17:53:17</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_Cisco\Enums\AssociationAuthenticationAlgorithm.tt</generator-source>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_Cisco\Enums\AssociationAuthenticationAlgorithm.tt", "1")> _
	<Flags()> _
	Public Enum AssociationAuthenticationAlgorithm As System.Int64

		''' <summary>Message-digest algorithm</summary>
		MD5 = 128

		''' <summary>Cisco Light-weight EAP</summary>
		LEAP = 64

		''' <summary>Protected EAP</summary>
		PEAP = 32

		''' <summary>EAP Transport Layer Security</summary>
		EAPTLS = 16

		''' <summary>EAP Enhanced GSM Authentication</summary>
		EAPSIM = 8

		''' <summary>Cisco EAP Fast</summary>
		EAPFAST = 4

		''' <summary>All Flags</summary>
		All = MD5 Or _
			LEAP Or _
			PEAP Or _
			EAPTLS Or _
			EAPSIM Or _
			EAPFAST

	End Enum

End Namespace