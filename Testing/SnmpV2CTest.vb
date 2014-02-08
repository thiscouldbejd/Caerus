#If TESTING Then

Imports Caerus.Snmp
Imports System.Configuration
Imports System.Reflection
Imports NUnit.Framework

Namespace Testing

	<TestFixture()> Public Class SnmpV2CTest

		#Region " Private Variables "

			Private m_SimplePacket_1 As Byte() = New Byte() _
				{&H30, &H82, &H1, &H18, &H2, &H1, &H1, &H4, &H7, &H64, &H63, &H67, &H73, &H6D, &H6F, &H6E, &HA2, &H82, &H1, &H8, &H2, &H4, &H5, _
					&HAF, &H31, &H68, &H2, &H1, &H0, &H2, &H1, &H0, &H30, &H81, &HF9, &H30, &H81, &HF6, &H6, _
					&H8, &H2B, &H6, &H1, &H2, &H1, &H1, &H1, &H0, &H4, &H81, &HE9, &H43, &H69, &H73, &H63, _
					&H6F, &H20, &H49, &H4F, &H53, &H20, &H53, &H6F, &H66, &H74, &H77, &H61, &H72, &H65, &H2C, &H20, _
					&H43, &H31, &H32, &H30, &H30, &H20, &H53, &H6F, &H66, &H74, &H77, &H61, &H72, &H65, &H20, &H28, _
					&H43, &H31, &H32, &H30, &H30, &H2D, &H4B, &H39, &H57, &H37, &H2D, &H4D, &H29, &H2C, &H20, &H56, _
					&H65, &H72, &H73, &H69, &H6F, &H6E, &H20, &H31, &H32, &H2E, &H33, &H28, &H38, &H29, &H4A, &H41, _
					&H32, &H2C, &H20, &H52, &H45, &H4C, &H45, &H41, &H53, &H45, &H20, &H53, &H4F, &H46, &H54, &H57, _
					&H41, &H52, &H45, &H20, &H28, &H66, &H63, &H31, &H29, &HD, &HA, &H54, &H65, &H63, &H68, &H6E, _
					&H69, &H63, &H61, &H6C, &H20, &H53, &H75, &H70, &H70, &H6F, &H72, &H74, &H3A, &H20, &H68, &H74, _
					&H74, &H70, &H3A, &H2F, &H2F, &H77, &H77, &H77, &H2E, &H63, &H69, &H73, &H63, &H6F, &H2E, &H63, _
					&H6F, &H6D, &H2F, &H74, &H65, &H63, &H68, &H73, &H75, &H70, &H70, &H6F, &H72, &H74, &HD, &HA, _
					&H43, &H6F, &H70, &H79, &H72, &H69, &H67, &H68, &H74, &H20, &H28, &H63, &H29, &H20, &H31, &H39, _
					&H38, &H36, &H2D, &H32, &H30, &H30, &H36, &H20, &H62, &H79, &H20, &H43, &H69, &H73, &H63, &H6F, _
					&H20, &H53, &H79, &H73, &H74, &H65, &H6D, &H73, &H2C, &H20, &H49, &H6E, &H63, &H2E, &HD, &HA, _
					&H43, &H6F, &H6D, &H70, &H69, &H6C, &H65, &H64, &H20, &H54, &H75, &H65, &H20, &H33, &H30, &H2D, _
					&H4D, &H61, &H79, &H2D, &H30, &H36, &H20, &H31, &H38, &H3A, &H30, &H37, &H20, &H62, &H79, &H20, _
					&H70, &H77, &H61, &H64, &H65}

			Private m_SimplePacket_2 As Byte() = New Byte() _
				{&H30, &H2A, &H2, &H1, &H1, &H4, &H7, _
					&H64, &H63, &H67, &H73, &H6D, &H6F, &H6E, _
					&HA0, &H1C, &H2, &H4, &H5D, &H8B, &H4D, _
					&H9F, &H2, &H1, &H0, &H2, &H1, &H0, _
					&H30, &HE, &H30, &HC, &H6, &H8, &H2B, _
					&H6, &H1, &H2, &H1, &H1, &H1, &H0, &H5, &H0}

			Private m_SimplePacket_3 As Byte() = New Byte() _
				{&H30, &H28, &H2, &H1, &H1, &H4, &H7, &H64, &H63, &H67, &H73, &H6D, &H6F, &H6E, &HA2, &H1A, _
					&H2, &H1, &H1, &H2, &H1, &H0, &H2, &H1, &H0, &H30, &HF, &H30, &HD, &H6, &H9, &H1, _
					&H3, &H6, &H1, &H2, &H1, &H1, &H1, &H0, &H80, &H0}

			Private m_SimplePacketVersion As SnmpVersion = SnmpVersion.SNMP_VERSION_2C
			Private m_SimplePacketCommunity As String = "dcgsmon"

			Private m_SimplePacket1Type As SnmpMessageType = SnmpMessageType.GET_RESPONSE
			Private m_SimplePacket1Error As SnmpErrorStatus = SnmpErrorStatus.NO_ERROR
			Private m_SimplePacket1ErrorIndex As Integer = 0
			Private m_SimplePacket1RequestId As Integer = 95367528

			Private m_SimplePacket1VariableBindingCount As Integer = 1
			Private m_SimplePacket1VariableBindingObjectId As String = "1.3.6.1.2.1.1.1.0"
			Private m_SimplePacket1VariableBindingObjectType As SnmpDataType = SnmpDataType.ASN1_OCTET_STRING

			Private m_SimplePacket2Type As SnmpMessageType = SnmpMessageType.GET_REQUEST
			Private m_SimplePacket2Error As SnmpErrorStatus = SnmpErrorStatus.NO_ERROR
			Private m_SimplePacket2ErrorIndex As Integer = 0
			Private m_SimplePacket2RequestId As Integer = 1569410463

			Private m_SimplePacket2VariableBindingObjectId As String = "1.3.6.1.2.1.1.1.0"

			Private m_SimplePacket3VariableBindingObjectId As String = "1.3.6.1.2.1.1.1.0"
			Private m_SimplePacket3VariableBindingObjectType As SnmpDataType = SnmpDataType.ASN1_NULL
			Private m_SimplePacket3Type As SnmpMessageType = SnmpMessageType.GET_RESPONSE
			Private m_SimplePacket3Error As SnmpErrorStatus = SnmpErrorStatus.NO_ERROR
			Private m_SimplePacket3ErrorIndex As Integer = 0
			Private m_SimplePacket3RequestId As Integer = 1

		#End Region

		#Region " General Testing "

			<Test(Description:="Simple String Testing")> _
			Public Sub StringTesting()

				Dim stringBytes As Byte() = BerEncoder.EncodeBerString(m_SimplePacketCommunity)

				Dim currentPosition As Integer = 0
				Dim stringReturnLength As Integer = BerDecoder.DecodeBerLength(stringBytes, currentPosition)

				Dim stringReturn As String = BerDecoder.DecodeBerString( _
					stringReturnLength, stringBytes, currentPosition)

				Assert.AreEqual(m_SimplePacketCommunity, stringReturn)

			End Sub

		#End Region

		#Region " Decode Testing "

			' <Test(Description:="Simple Decoding Testing")> _
			Public Sub SimpleDecodeTest_1()

				Dim message As New SnmpV2cMessage()
				message.DecodePacket(m_SimplePacket_1, 0)

				Assert.AreEqual(m_SimplePacketVersion, message.Header.Version)
				Assert.AreEqual(m_SimplePacketCommunity, message.Header.Community)

				Assert.AreEqual(m_SimplePacket1Type, message.ProtocolDataUnit.MessageType)
				Assert.AreEqual(m_SimplePacket1Error, message.ProtocolDataUnit.Error)
				Assert.AreEqual(m_SimplePacket1ErrorIndex, message.ProtocolDataUnit.ErrorIndex)
				Assert.AreEqual(m_SimplePacket1RequestId, message.ProtocolDataUnit.RequestId)

				Assert.AreEqual(m_SimplePacket1VariableBindingCount, _
					message.ProtocolDataUnit.VariableBindings.Length)
				Assert.AreEqual(m_SimplePacket1VariableBindingObjectId, _
					message.ProtocolDataUnit.VariableBindings(0).ObjectId)
				Assert.AreEqual(m_SimplePacket1VariableBindingObjectType, _
					message.ProtocolDataUnit.VariableBindings(0).ObjectType)
				Assert.IsNotEmpty(message.ProtocolDataUnit.VariableBindings(0).ObjectValue)

			End Sub

			' <Test(Description:="Simple Decoding Testing")> _
			Public Sub SimpleDecodeTest_2()

				Dim message As New SnmpV2cMessage
				message.DecodePacket(m_SimplePacket_3, 0)

				Assert.AreEqual(m_SimplePacketVersion, message.Header.Version)
				Assert.AreEqual(m_SimplePacketCommunity, message.Header.Community)

				Assert.AreEqual(m_SimplePacket3Type, message.ProtocolDataUnit.MessageType)
				Assert.AreEqual(m_SimplePacket3Error, message.ProtocolDataUnit.Error)
				Assert.AreEqual(m_SimplePacket3ErrorIndex, message.ProtocolDataUnit.ErrorIndex)
				Assert.AreEqual(m_SimplePacket3RequestId, message.ProtocolDataUnit.RequestId)

				Assert.AreEqual(m_SimplePacket3VariableBindingObjectId, _
					message.ProtocolDataUnit.VariableBindings(0).ObjectId)

			End Sub

		#End Region

		#Region " Encode Testing "

			<Test(Description:="Simple Encoding Testing")> _
			Public Sub SimpleEncodeTest()

				Dim message As New SnmpV2cMessage

				message.Header = New SnmpV2cMessageHeader
				message.Header.Version = m_SimplePacketVersion
				message.Header.Community = m_SimplePacketCommunity

				message.ProtocolDataUnit = New SnmpV2cProtocolDataUnit
				message.ProtocolDataUnit.MessageType = m_SimplePacket2Type
				message.ProtocolDataUnit.Error = m_SimplePacket2Error
				message.ProtocolDataUnit.ErrorIndex = m_SimplePacket2ErrorIndex
				message.ProtocolDataUnit.RequestId = m_SimplePacket2RequestId

				message.ProtocolDataUnit.VariableBindings = _
					New SnmpVariableBind() {New SnmpVariableBind}
				message.ProtocolDataUnit.VariableBindings(0).ObjectId = _
					m_SimplePacket2VariableBindingObjectId

				Assert.AreEqual(m_SimplePacket_2, message.EncodePacket())

			End Sub

		#End Region

	End Class

End Namespace

#End If
