Imports Caerus.BerDecoder
Imports Caerus.BerEncoder
Imports Caerus.Snmp.SnmpDataType

Namespace Snmp
	
	Partial Public Class SnmpV2cMessageHeader
	    Implements IPacketEncoder, IPacketDecoder
	
		#Region " IPacketDecoder Implementation "
		
		    Public Sub DecodePacket( _
		        ByVal packet() As Byte, _
		        ByRef currentIndex As Integer, _
		        ByVal ParamArray types As Type() _
		    ) _
		    Implements IPacketDecoder.DecodePacket
		
		        If CheckBerType(packet, currentIndex, ASN1_INTEGER) Then
		            m_Version = DecodeBerInteger(DecodeBerLength(packet, currentIndex), packet, currentIndex)
		
		            If CheckBerType(packet, currentIndex, ASN1_OCTET_STRING) Then
		                m_Community = DecodeBerString(DecodeBerLength(packet, currentIndex), packet, currentIndex)
		            End If
		
		        End If
		
		    End Sub
		
		#End Region
		
		#Region " IPacketEncoder Implementation "
		
		    Public Function EncodePacket( _
		        ) As Byte() _
		    Implements IPacketEncoder.EncodePacket
		
		        Dim bytes As New ArrayList()
		
		        bytes.Add(CByte(ASN1_INTEGER))
		
		        bytes.AddRange(EncodeBerInteger(Version))
		
		        bytes.Add(CByte(ASN1_OCTET_STRING))
		
		        bytes.AddRange(EncodeBerString(Community))
		
		        Return bytes.ToArray(GetType(Byte))
		
		    End Function
		
		#End Region
	
	End Class
	
End Namespace