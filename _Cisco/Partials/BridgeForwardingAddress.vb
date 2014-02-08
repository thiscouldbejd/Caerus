Imports Caerus.Snmp.SnmpConnection

Namespace Cisco

	Partial Public Class BridgeForwardingAddress

		#Region " Public Properties "

			Public ReadOnly Property ForwardingOid As String
				Get
					Return PhysicalAddressToOid(ForwardingAddress)
				End Get
			End Property

		#End Region

	End Class

End Namespace
