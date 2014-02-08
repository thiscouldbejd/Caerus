Namespace Cisco

	''' <summary></summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 17:53:19</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_Cisco\Enums\AssociationCipherType.tt</generator-source>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_Cisco\Enums\AssociationCipherType.tt", "1")> _
	<Flags()> _
	Public Enum AssociationCipherType As System.Int64

		''' <summary>Cisco Per packet key hashing</summary>
		CKIP = 128

		''' <summary>Cisco MMH MIC</summary>
		CMIC = 64

		''' <summary>WPA Temporal Key encryption</summary>
		TKIP = 32

		''' <summary>40-bit WEP key</summary>
		WEP40 = 16

		''' <summary>128-bit WEP key</summary>
		WEP128 = 8

		''' <summary>WPA AES CCMP encryption</summary>
		AESCCM = 4

		''' <summary>All Flags</summary>
		All = CKIP Or _
			CMIC Or _
			TKIP Or _
			WEP40 Or _
			WEP128 Or _
			AESCCM

	End Enum

End Namespace