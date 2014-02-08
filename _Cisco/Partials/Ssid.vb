Imports Caerus.Snmp.SnmpConnection

Namespace Cisco

	Partial Public Class Ssid

		#Region " Public Properties "

			Public ReadOnly Property NameOid As String
				Get
					Return StringToOid(Name)
				End Get
			End Property

		#End Region

	End Class

End Namespace
