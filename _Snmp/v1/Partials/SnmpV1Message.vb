Imports Caerus.BerDecoder
Imports Caerus.BerEncoder
Imports Caerus.Snmp.SnmpDataType

Namespace Snmp
	
	Partial Public Class SnmpV1Message
	    Implements IPacketEncoder, IPacketDecoder, ISnmpMessage
	
	#Region " IPacketDecoder Implementation "
	
	    Public Sub DecodePacket( _
	        ByVal packet() As Byte, _
	        ByRef currentIndex As Integer, _
	        ByVal ParamArray types As Type() _
	    ) Implements IPacketDecoder.DecodePacket
	
	        If CheckBerType(packet, currentIndex, ASN1_SEQUENCE) Then
	
	            SetLength(packet, currentIndex)
	
	            If CheckBerType(packet, currentIndex, ASN1_INTEGER) Then
	                m_Version = DecodeBerInteger(DecodeBerLength(packet, currentIndex), packet, currentIndex)
	
	                If CheckBerType(packet, currentIndex, ASN1_OCTET_STRING) Then
	                    m_Community = DecodeBerString(DecodeBerLength(packet, currentIndex), packet, currentIndex)
	                End If
	
	            End If
	
	            ProtocolDataUnit = New SnmpV1ProtocolDataUnit
	            ProtocolDataUnit.DecodePacket(packet, currentIndex, types)
	
	        End If
	
	    End Sub
	
	#End Region
	
	#Region " IPacketEncoder Implementation "
	
	    Public Function EncodePacket() As Byte() _
	        Implements IPacketEncoder.EncodePacket
	
	        Dim bytes As New ArrayList()
	
	        bytes.Add(CByte(ASN1_SEQUENCE))
	
	        Dim sequenceStart As Integer = bytes.Count
	
	        bytes.Add(CByte(ASN1_INTEGER))
	
	        bytes.AddRange(EncodeBerInteger(Version))
	
	        bytes.Add(CByte(ASN1_OCTET_STRING))
	
	        bytes.AddRange(EncodeBerString(Community))
	
	        bytes.AddRange(ProtocolDataUnit.EncodePacket)
	
	        bytes.InsertRange(sequenceStart, EncodeBerLength(bytes.Count - sequenceStart))
	
	        Return bytes.ToArray(GetType(Byte))
	
	    End Function
	
	#End Region
	
	#Region " ISnmpMessage Implementation "
	
	    Public Property PDUs() As SnmpProtocolDataUnitBase _
	        Implements ISnmpMessage.ProtocolDataUnit
	        Get
	            Return ProtocolDataUnit
	        End Get
	        Set(ByVal value As SnmpProtocolDataUnitBase)
	            ProtocolDataUnit = value
	        End Set
	    End Property
	
	#End Region
	
	#Region " Friend Shared Methods "
	
	    Friend Shared Function CreateRequest( _
	        ByVal messageType As SnmpMessageType, _
	        ByVal community As String, _
	        ByVal requestId As Integer _
	    ) As SnmpV1Message
	
	        Return CreateRequest(messageType, community, requestId, Nothing, ASN1_NULL, Nothing)
	
	    End Function
	
	    Friend Shared Function CreateRequest( _
	        ByVal messageType As SnmpMessageType, _
	        ByVal community As String, _
	        ByVal requestId As Integer, _
	        ByVal objectId As String _
	    ) As SnmpV1Message
	
	        Return CreateRequest(messageType, community, requestId, objectId, ASN1_NULL, Nothing)
	
	    End Function
	
	    Friend Shared Function CreateRequest( _
	        ByVal messageType As SnmpMessageType, _
	        ByVal community As String, _
	        ByVal requestId As Integer, _
	        ByVal objectId As String, _
	        ByVal objectType As SnmpDataType, _
	        ByVal objectValue As Object _
	    ) As SnmpV1Message
	
	        Dim message As New SnmpV1Message
	
	        message.Version = SnmpVersion.SNMP_VERSION_1
	        message.Community = community
	
	        message.ProtocolDataUnit = New SnmpV1ProtocolDataUnit
	        message.ProtocolDataUnit.MessageType = messageType
	        message.ProtocolDataUnit.RequestId = requestId
	
	        If Not String.IsNullOrEmpty(objectId) Then
	
	            If Not objectValue Is Nothing Then
	
	                message.ProtocolDataUnit.AddVariableBinding(objectId, objectType, objectValue)
	
	            Else
	
	                message.ProtocolDataUnit.AddVariableBinding(objectId)
	
	            End If
	
	        End If
	
	        Return message
	
	    End Function
	
	#End Region
	
	End Class

End Namespace