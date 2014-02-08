#If DEBUG Then

Imports NUnit.Framework

Namespace Cisco.Testing

    <TestFixture()> _
    Public Class CiscoNetworkInterfaceTests

        Private Function GetShortNameConversion( _
            ByVal fullName As String _
        ) As String

			Dim ifName As InterfaceName = Nothing
			If InterfaceName.TryParse(fullName, ifName) Then _
				Return ifName.ShortName
				
			Return String.Empty
			
        End Function

        <Test(Description:="Test Names To ShortNames Conversion")> _
        Public Sub TestShortNameConversions()

            Assert.AreEqual("do0", GetShortNameConversion("Dot11Radio0"))
            Assert.AreEqual("do0.2", GetShortNameConversion("Dot11Radio0.2"))
            Assert.AreEqual("do1", GetShortNameConversion("Dot11Radio1"))
            Assert.AreEqual("bv1", GetShortNameConversion("BVI1"))
            Assert.AreEqual("fa0/1", GetShortNameConversion("FastEthernet0/1"))
            Assert.AreEqual("fa0/11", GetShortNameConversion("FastEthernet0/11"))
            Assert.AreEqual("fa0/12", GetShortNameConversion("FastEthernet0/12"))
            Assert.AreEqual("fa0.50", GetShortNameConversion("FastEthernet0.50"))
            Assert.AreEqual("gi1/1", GetShortNameConversion("GigabitEthernet1/1"))
            Assert.AreEqual("gi0/0/1", GetShortNameConversion("GigabitEthernet0/0/1"))
            Assert.AreEqual("nu0", GetShortNameConversion("Null0"))
            Assert.AreEqual("vl1", GetShortNameConversion("Vlan1"))
            Assert.AreEqual("po1", GetShortNameConversion("PortChannel1"))
            Assert.AreEqual("sv1", GetShortNameConversion("SVI1"))

        End Sub
    End Class

End Namespace

#End If