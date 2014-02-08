Namespace Snmp
	
	Partial Public Class SnmpLengthedBase
	
		#Region " Protected Methods "
		
		    Protected Sub SetLength( _
		        ByVal packet() As Byte, _
		        ByRef currentIndex As Integer _
		    )
		
		        m_Length = BerDecoder.DecodeBerLength(packet, currentIndex)
		
		    End Sub
		
		#End Region
	
	End Class
	
End Namespace