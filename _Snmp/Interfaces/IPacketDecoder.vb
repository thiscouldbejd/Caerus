Namespace Snmp
	
	Public Interface IPacketDecoder
	
	    Sub DecodePacket( _
	        ByVal packet As Byte(), _
	        ByRef currentIndex As Integer, _
	        ParamArray ByVal types As Type() _
	    )
	
	End Interface

End Namespace