Imports Caerus.Snmp.SnmpDataType
Imports Caerus.Snmp.SnmpMessageType

Namespace Snmp

	Partial Public Class SnmpV2cProtocolDataUnit

		#Region " Public Overriding Properties "

			Public Overrides Property MessageType() As SnmpMessageType
				Get
					If Type = SNMP_PDU_GETBULKREQUEST Then
						Return GET_BULK_REQUEST
					ElseIf Type = SNMP_PDU_GETNEXTREQUEST Then
						Return GET_NEXT_REQUEST
					ElseIf Type = SNMP_PDU_GETREQUEST Then
						Return GET_REQUEST
					ElseIf Type = SNMP_PDU_GETRESPONSE Then
						Return GET_RESPONSE
					ElseIf Type = SNMP_PDU_INFORMREQUEST Then
						Return INFORM_REQUEST
					ElseIf Type = SNMP_PDU_SETREQUEST Then
						Return SET_REQUEST
					ElseIf Type = SNMP_PDU_TRAP Then
						Return TRAP_V1
					ElseIf Type = SNMP_PDU_TRAPV2 Then
						Return TRAP_V2
					Else
						Return GET_RESPONSE
					End If
				End Get
				Set(ByVal value As SnmpMessageType)
					If value = GET_BULK_REQUEST Then
						Type = SNMP_PDU_GETBULKREQUEST
					ElseIf value = GET_NEXT_REQUEST Then
						Type = SNMP_PDU_GETNEXTREQUEST
					ElseIf value = GET_REQUEST Then
						Type = SNMP_PDU_GETREQUEST
					ElseIf value = GET_RESPONSE Then
						Type = SNMP_PDU_GETRESPONSE
					ElseIf value = INFORM_REQUEST Then
						Type = SNMP_PDU_INFORMREQUEST
					ElseIf value = SET_REQUEST Then
						Type = SNMP_PDU_SETREQUEST
					ElseIf value = TRAP_V1 Then
						Type = SNMP_PDU_TRAP
					ElseIf value = TRAP_V2 Then
						Type = SNMP_PDU_TRAPV2
					End If
				End Set
			End Property

		#End Region

	End Class

End Namespace
