Imports Caerus.BerDecoder
Imports Caerus.BerEncoder
Imports Caerus.Snmp.SnmpDataType
Imports System.Net.NetworkInformation

Namespace Snmp
	
	Partial Public Class SnmpVariableBind
	    Implements IPacketEncoder, IPacketDecoder
	
	#Region " IPacketDecoder Implementation "
	
	    Public Sub DecodePacket( _
	        ByVal packet() As Byte, _
	        ByRef currentIndex As Integer, _
	        ParamArray ByVal types As Type() _
	    ) _
	    Implements IPacketDecoder.DecodePacket
	
	        If CheckBerType(packet, currentIndex, ASN1_SEQUENCE) Then
	
	            Length = DecodeBerLength(packet, currentIndex)
	
	            Dim startIndex As Integer = currentIndex
	
	            If CheckBerType(packet, currentIndex, ASN1_OBJECT_IDENTIFIER) Then
	
	                Dim length_1 As Integer = DecodeBerLength(packet, currentIndex)
	
	                ObjectId = DecodeBerObjectID(Length_1, packet, currentIndex)
	
	                ObjectType = DecodeBerInteger(1, packet, currentIndex)
	
	                Dim length_2 As Integer = DecodeBerLength(packet, currentIndex)
	
	                Select Case ObjectType
	                    Case ASN1_BIT_STRING
	
	                        ObjectValue = DecodeBerOctetString(length_2, packet, currentIndex)
	
	                    Case ASN1_BOOLEAN
	
	                        ObjectValue = CBool(DecodeBerInteger(Length_2, packet, currentIndex))
	
	                    Case ASN1_ENUMERATED
	                        
	                        Throw New NotImplementedException()
	                        
	                    Case ASN1_IA5_STRING
	
	                        ObjectValue = DecodeBerString(Length_2, packet, currentIndex)
	
	                    Case ASN1_INTEGER
	
	                        ObjectValue = DecodeBerInteger(Length_2, packet, currentIndex)
	
	                    Case ASN1_NULL
	
	                        DecodeBerNull(packet, currentIndex)
	
	                    Case ASN1_OCTET_STRING
	
							If Not types Is Nothing AndAlso types.Length = 1 AndALso Not types(0) Is Nothing Then
								
								ObjectValue = DecodeBerOctetString(Length_2, packet, currentIndex, types(0))
								
							Else
								
								ObjectValue = DecodeBerString(Length_2, packet, currentIndex)
								
							End If
								
	                    Case ASN1_PRINTABLE_STRING
	
	                        ObjectValue = DecodeBerString(Length_2, packet, currentIndex)
	
	                    Case ASN1_REAL
	
	                        ObjectValue = DecodeBerInteger(Length_2, packet, currentIndex)
	
	                    Case ASN1_SEQUENCE
	                        
	                        Throw New NotImplementedException()
	                        
	                    Case ASN1_SET
	                        
	                        Throw New NotImplementedException()
	                        
	                    Case SNMP_IP_ADDRESS
	
	                        ObjectValue = DecodeBerIpAddress(Length_2, packet, currentIndex)
	
	                    Case SNMP_TIMETICKS
	
	                        ObjectValue = New TimeSpan(DecodeBerInteger( _
	                            Length_2, packet, currentIndex) * &H186A0)
	
	                    Case SNMP_COUNTER_32
	
	                        ObjectValue = DecodeBerInteger(Length_2, packet, currentIndex)
	
	                    Case SNMP_COUNTER_64
	
	                        ObjectValue = DecodeBerInteger(Length_2, packet, currentIndex)
	
	                    Case SNMP_GAUGE
	
	                        ObjectValue = DecodeBerInteger(Length_2, packet, currentIndex)
	
	                    Case SNMP_PHYSICAL_ADDRESS
	
	                        ObjectValue = DecodeBerInteger(Length_2, packet, currentIndex)
	
	                    Case ASN1_OBJECT_IDENTIFIER
	
	                        ObjectValue = DecodeBerObjectID(Length_2, packet, currentIndex)
	
	                End Select
	
	                If (startIndex + Length) > currentIndex Then _
	                    currentIndex = (startIndex + Length)
	
	            End If
	
	        End If
	
	    End Sub
	
	#End Region
	
	#Region " IPacketEncoder Implementation "
	
	    Public Function EncodePacket( _
	        ) As Byte() _
	    Implements IPacketEncoder.EncodePacket
	
	        Dim bytes As New ArrayList()
	
	        bytes.Add(CByte(ASN1_SEQUENCE))
	
	        Dim sequenceStart As Integer = bytes.Count
	
	        bytes.Add(CByte(ASN1_OBJECT_IDENTIFIER))
	
	        bytes.AddRange(EncodeBerObjectID(ObjectId))
	
	        bytes.Add(CByte(ObjectType))
	
	        Select Case ObjectType
	            Case ASN1_BIT_STRING
	                bytes.AddRange(EncodeBerString(ObjectValue))
	            Case ASN1_BOOLEAN
	                bytes.AddRange(EncodeBerInteger(ObjectValue))
	            Case ASN1_ENUMERATED
	                ' Not Implemented
	            Case ASN1_IA5_STRING
	                bytes.AddRange(EncodeBerString(ObjectValue))
	            Case ASN1_INTEGER
	                bytes.AddRange(EncodeBerInteger(ObjectValue))
	            Case ASN1_NULL
	                bytes.AddRange(EncodeBerNull())
	            Case ASN1_OCTET_STRING
	                bytes.AddRange(EncodeBerString(ObjectValue))
	            Case ASN1_PRINTABLE_STRING
	                bytes.AddRange(EncodeBerString(ObjectValue))
	            Case ASN1_REAL
	                bytes.AddRange(EncodeBerInteger(ObjectValue))
	            Case SNMP_TIMETICKS
	                bytes.AddRange(EncodeBerInteger(CType(ObjectValue, TimeSpan).Ticks / &H186A0))
	            Case ASN1_SEQUENCE
	                ' Not Implemented
	            Case ASN1_SET
	                ' Not Implemented
	            Case SNMP_IP_ADDRESS
	                bytes.AddRange(EncodeBerIpAddress(ObjectValue))
	            Case SNMP_COUNTER_32
	                bytes.AddRange(EncodeBerInteger(ObjectValue))
	            Case SNMP_COUNTER_64
	                bytes.AddRange(EncodeBerInteger(ObjectValue))
	            Case SNMP_GAUGE
	                bytes.AddRange(EncodeBerInteger(ObjectValue))
	            Case SNMP_PHYSICAL_ADDRESS
	                bytes.AddRange(EncodeBerInteger(ObjectValue))
	            Case ASN1_OBJECT_IDENTIFIER
	                bytes.AddRange(EncodeBerObjectID(ObjectValue))
	        End Select
	
	        bytes.InsertRange(sequenceStart, EncodeBerLength(bytes.Count - sequenceStart))
	
	        Return bytes.ToArray(GetType(Byte))
	
	    End Function
	
	#End Region
	
	End Class
	
End Namespace