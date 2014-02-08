Imports Caerus.BerDecoder
Imports Caerus.BerEncoder
Imports Caerus.Snmp.SnmpDataType
Imports Caerus.Snmp.SnmpMessageType

Namespace Snmp
	
	Partial Public Class SnmpProtocolDataUnitBase
	    Implements IPacketEncoder, IPacketDecoder
	    
	#Region " Public MustOverride Properties "
	
	    Public MustOverride Property MessageType() As SnmpMessageType
	
	#End Region
	
	#Region " Public Methods "
	
	    Public Sub AddVariableBinding( _
	        ByVal objectId As String _
	    )
	
	        AddVariableBinding(objectId, ASN1_NULL, Nothing)
	
	    End Sub
	
	    Public Sub AddVariableBinding( _
	        ByVal objectId As String, _
	        ByVal objectType As SnmpDataType, _
	        ByVal objectValue As Object _
	    )
	
	        Dim variable As New SnmpVariableBind(objectId)

	        If Not objectValue Is Nothing Then _
	            variable.SetObjectType(objectType).SetObjectValue(objectValue)

	        If VariableBindings Is Nothing OrElse VariableBindings.Length = 0 Then
	            VariableBindings = New SnmpVariableBind() {variable}
	        Else
	            Array.Resize(VariableBindings, VariableBindings.Length + 1)
	            VariableBindings(VariableBindings.Length - 1) = variable
	        End If
	
	    End Sub
	
	#End Region
	
	#Region " IPacketDecoder Implementation "
	
	    Public Sub DecodePacket( _
	        ByVal packet() As Byte, _
	        ByRef currentIndex As Integer, _
	        ParamArray ByVal types As Type() _
	    ) _
	    Implements IPacketDecoder.DecodePacket
	
	        Type = DecodeBerInteger(1, packet, currentIndex)
	
	        SetLength(packet, currentIndex)
	
	        If CheckBerType(packet, currentIndex, ASN1_INTEGER) Then _
	            RequestId = DecodeBerInteger(DecodeBerLength(packet, currentIndex), packet, currentIndex)
	
	        If CheckBerType(packet, currentIndex, ASN1_INTEGER) Then _
	            [Error] = DecodeBerInteger(DecodeBerLength(packet, currentIndex), packet, currentIndex)
	
	        If CheckBerType(packet, currentIndex, ASN1_INTEGER) Then _
	            ErrorIndex = DecodeBerInteger(DecodeBerLength(packet, currentIndex), packet, currentIndex)
	
	        If [Error] = SnmpErrorStatus.NO_ERROR Then
	
	            If CheckBerType(packet, currentIndex, ASN1_SEQUENCE) Then
	
	                Dim l_VariableBindings As New ArrayList
	
	                Dim l_VariableBindingLengths As Integer = DecodeBerLength(packet, currentIndex)
	
	                Dim l_variableBindingsStart As Integer = currentIndex
	
	                Do Until currentIndex >= (l_variableBindingsStart + l_VariableBindingLengths)
	
	                    Dim l_variableBinding As New SnmpVariableBind()
	                    Dim l_variableBindingType As System.Type = Nothing
	                    If Not types Is Nothing AndAlso types.Length >= (l_VariableBindings.Count - 1) Then _
	                    	l_variableBindingType = types(l_VariableBindings.Count)
	                    	
	                    l_variableBinding.DecodePacket(packet, currentIndex, l_variableBindingType)
	                    l_VariableBindings.Add(l_variableBinding)
	
	                Loop
	
	                If l_VariableBindings.Count > 0 Then
	                	
	                    VariableBindings = l_VariableBindings.ToArray(GetType(SnmpVariableBind))
	                    
	                Else
	                	
	                    VariableBindings = New SnmpVariableBind() {}
	                    
	                End If
	
	            End If
	
	        End If
	
	    End Sub
	
	#End Region
	
	#Region " IPacketEncoder Implementation "
	
	    Public Function EncodePacket( _
	        ) As Byte() _
	    Implements IPacketEncoder.EncodePacket
	
	        Dim bytes As New ArrayList()
	
	        bytes.Add(CByte(Type))
	
	        Dim sequenceStart As Integer = bytes.Count
	
	        bytes.Add(CByte(ASN1_INTEGER))
	        bytes.AddRange(EncodeBerInteger(RequestId))
	
	        bytes.Add(CByte(ASN1_INTEGER))
	        bytes.AddRange(EncodeBerInteger([Error]))
	
	        bytes.Add(CByte(ASN1_INTEGER))
	        bytes.AddRange(EncodeBerInteger(ErrorIndex))
	
	        If Not VariableBindings Is Nothing AndAlso VariableBindings.Length > 0 Then
	
	            bytes.Add(CByte(ASN1_SEQUENCE))
	
	            Dim variableSequenceStart As Integer = bytes.Count
	
	            For i As Integer = 0 To VariableBindings.Length - 1
	
	                bytes.AddRange(VariableBindings(i).EncodePacket())
	
	            Next
	
	            bytes.InsertRange(variableSequenceStart, EncodeBerLength(bytes.Count - variableSequenceStart))
	
	        End If
	
	        bytes.InsertRange(sequenceStart, EncodeBerLength(bytes.Count - sequenceStart))
	
	        Return bytes.ToArray(GetType(Byte))
	
	    End Function
	
	#End Region
	
	End Class
	
End Namespace