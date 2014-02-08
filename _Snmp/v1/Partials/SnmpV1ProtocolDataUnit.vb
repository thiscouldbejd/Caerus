Imports Caerus.Snmp.SnmpDataType
Imports Caerus.Snmp.SnmpMessageType

Namespace Snmp
	
	Public Class SnmpV1ProtocolDataUnit
	
	#Region " Public Overriding Properties "
	
	    Public Overrides Property MessageType() As SnmpMessageType
	        Get
	            If Type = SNMP_PDU_GETNEXTREQUEST Then
	                Return GET_NEXT_REQUEST
	            ElseIf Type = SNMP_PDU_GETREQUEST Then
	                Return GET_REQUEST
	            ElseIf Type = SNMP_PDU_GETRESPONSE Then
	                Return GET_RESPONSE
	            ElseIf Type = SNMP_PDU_SETREQUEST Then
	                Return SET_REQUEST
							Else
								Return GET_RESPONSE
	            End If
	        End Get
	        Set(ByVal value As SnmpMessageType)
	            If value = GET_NEXT_REQUEST Then
	                Type = SNMP_PDU_GETNEXTREQUEST
	            ElseIf value = GET_REQUEST Then
	                Type = SNMP_PDU_GETREQUEST
	            ElseIf value = GET_RESPONSE Then
	                Type = SNMP_PDU_GETRESPONSE
	            ElseIf value = SET_REQUEST Then
	                Type = SNMP_PDU_SETREQUEST
	            End If
	        End Set
	    End Property
	
	#End Region
	
	End Class

End Namespace
