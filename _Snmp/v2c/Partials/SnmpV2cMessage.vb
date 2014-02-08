Imports Caerus.BerDecoder
Imports Caerus.BerEncoder
Imports Caerus.Snmp.SnmpDataType

Namespace Snmp
	
	Partial Public Class SnmpV2cMessage
	    Implements IPacketEncoder, IPacketDecoder, ISnmpMessage
	
	#Region " IPacketDecoder Implementation "
	
	    Public Sub DecodePacket( _
	        ByVal packet() As Byte, _
	        ByRef currentIndex As Integer, _
	        ByVal ParamArray types As Type() _
	    ) _
	    Implements IPacketDecoder.DecodePacket
	
	        If CheckBerType(packet, currentIndex, ASN1_SEQUENCE) Then
	
	            SetLength(packet, currentIndex)
	
	            Header = New SnmpV2cMessageHeader
	            Header.DecodePacket(packet, currentIndex)
	
	            ProtocolDataUnit = New SnmpV2cProtocolDataUnit
	            ProtocolDataUnit.DecodePacket(packet, currentIndex, types)
	
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
	
	        bytes.AddRange(Header.EncodePacket)
	
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
	    ) As SnmpV2cMessage
	
	        Return CreateRequest(messageType, community, requestId, Nothing, ASN1_NULL, Nothing)
	
	    End Function
	
	    Friend Shared Function CreateRequest( _
	        ByVal messageType As SnmpMessageType, _
	        ByVal community As String, _
	        ByVal requestId As Integer, _
	        ByVal objectId As String _
	    ) As SnmpV2cMessage
	
	        Return CreateRequest(messageType, community, requestId, objectId, ASN1_NULL, Nothing)
	
	    End Function
	
	    Friend Shared Function CreateRequest( _
	        ByVal messageType As SnmpMessageType, _
	        ByVal community As String, _
	        ByVal requestId As Integer, _
	        ByVal objectId As String, _
	        ByVal objectType As SnmpDataType, _
	        ByVal objectValue As Object _
	    ) As SnmpV2cMessage
	
	        Dim message As New SnmpV2cMessage
	
	        message.Header = New SnmpV2cMessageHeader
	        message.Header.Version = SnmpVersion.SNMP_VERSION_2C
	        message.Header.Community = community
	
	        message.ProtocolDataUnit = New SnmpV2cProtocolDataUnit
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