Namespace Cisco

	''' <summary>Enum Representing Interface Types</summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 17:53:32</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_Cisco\Enums\InterfaceType.tt</generator-source>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_Cisco\Enums\InterfaceType.tt", "1")> _
	Public Enum InterfaceType As System.Int64

		''' <summary>Interface Type is Unknown.</summary>
		Unknown = 1

		''' <summary>Interface Type is Regular1822.</summary>
		Regular1822 = 2

		''' <summary>Interface Type is HDH1822.</summary>
		HDH1822 = 3

		''' <summary>Interface Type is DDNX25.</summary>
		DDNX25 = 4

		''' <summary>Interface Type is RFC877x25.</summary>
		RFC877x25 = 5

		''' <summary>Interface Type is EthernetCsmacd.</summary>
		EthernetCsmacd = 6

		''' <summary>Interface Type is ISO88023Csmacd.</summary>
		ISO88023Csmacd = 7

		''' <summary>Interface Type is ISO88024TokenBus.</summary>
		ISO88024TokenBus = 8

		''' <summary>Interface Type is ISO88025TokenRing.</summary>
		ISO88025TokenRing = 9

		''' <summary>Interface Type is ISO88026Man.</summary>
		ISO88026Man = 10

		''' <summary>Interface Type is StarLan.</summary>
		StarLan = 11

		''' <summary>Interface Type is Proteon10Mbit.</summary>
		Proteon10Mbit = 12

		''' <summary>Interface Type is Proteon80Mbit.</summary>
		Proteon80Mbit = 13

		''' <summary>Interface Type is HyperChannel.</summary>
		HyperChannel = 14

		''' <summary>Interface Type is FDDI.</summary>
		FDDI = 15

		''' <summary>Interface Type is LAPB.</summary>
		LAPB = 16

		''' <summary>Interface Type is SDLC.</summary>
		SDLC = 17

		''' <summary>Interface Type is DS1.</summary>
		DS1 = 18

		''' <summary>Interface Type is E1.</summary>
		E1 = 19

		''' <summary>Interface Type is BasicISDN.</summary>
		BasicISDN = 20

		''' <summary>Interface Type is PrimaryISDN.</summary>
		PrimaryISDN = 21

		''' <summary>Interface Type is PropPointToPointSerial.</summary>
		PropPointToPointSerial = 22

		''' <summary>Interface Type is PPP.</summary>
		PPP = 23

		''' <summary>Interface Type is SoftwareLoopback.</summary>
		SoftwareLoopback = 24

		''' <summary>Interface Type is Eon.</summary>
		Eon = 25

		''' <summary>Interface Type is Ethernet3Mbit.</summary>
		Ethernet3Mbit = 26

		''' <summary>Interface Type is Nsip.</summary>
		Nsip = 27

		''' <summary>Interface Type is Slip.</summary>
		Slip = 28

		''' <summary>Interface Type is Ultra.</summary>
		Ultra = 29

		''' <summary>Interface Type is DS3.</summary>
		DS3 = 30

		''' <summary>Interface Type is SIP.</summary>
		SIP = 31

		''' <summary>Interface Type is FrameRelay.</summary>
		FrameRelay = 32

		''' <summary>Interface Type is RS232.</summary>
		RS232 = 33

		''' <summary>Interface Type is Para.</summary>
		Para = 34

		''' <summary>Interface Type is ArcNet.</summary>
		ArcNet = 35

		''' <summary>Interface Type is ArcNetPlus.</summary>
		ArcNetPlus = 36

		''' <summary>Interface Type is ATM.</summary>
		ATM = 37

		''' <summary>Interface Type is MIOX25.</summary>
		MIOX25 = 38

		''' <summary>Interface Type is SONET.</summary>
		SONET = 39

		''' <summary>Interface Type is X25ple.</summary>
		X25ple = 40

		''' <summary>Interface Type is ISO88022llc.</summary>
		ISO88022llc = 41

		''' <summary>Interface Type is LocalTalk.</summary>
		LocalTalk = 42

		''' <summary>Interface Type is SMDSDxi.</summary>
		SMDSDxi = 43

		''' <summary>Interface Type is FrameRelayService.</summary>
		FrameRelayService = 44

		''' <summary>Interface Type is V35.</summary>
		V35 = 45

		''' <summary>Interface Type is HSSI.</summary>
		HSSI = 46

		''' <summary>Interface Type is Hippi.</summary>
		Hippi = 47

		''' <summary>Interface Type is Modem.</summary>
		Modem = 48

		''' <summary>Interface Type is AAL5.</summary>
		AAL5 = 49

		''' <summary>Interface Type is SonetPath.</summary>
		SonetPath = 50

		''' <summary>Interface Type is SonetVT.</summary>
		SonetVT = 51

		''' <summary>Interface Type is SMDSIcip.</summary>
		SMDSIcip = 52

		''' <summary>Interface Type is PropVirtual.</summary>
		PropVirtual = 53

		''' <summary>Interface Type is PropMultiplexor.</summary>
		PropMultiplexor = 54

		''' <summary>Interface Type is IEEE80212.</summary>
		IEEE80212 = 55

		''' <summary>Interface Type is FibreChannel.</summary>
		FibreChannel = 56

		''' <summary>Interface Type is HippiInterface.</summary>
		HippiInterface = 57

		''' <summary>Interface Type is FrameRelayInterconnect.</summary>
		FrameRelayInterconnect = 58

		''' <summary>Interface Type is AFLane8023.</summary>
		AFLane8023 = 59

		''' <summary>Interface Type is AFLane8025.</summary>
		AFLane8025 = 60

		''' <summary>Interface Type is CCTEmul.</summary>
		CCTEmul = 61

		''' <summary>Interface Type is FastEthernet.</summary>
		FastEthernet = 62

		''' <summary>Interface Type is ISDN.</summary>
		ISDN = 63

		''' <summary>Interface Type is V11.</summary>
		V11 = 64

		''' <summary>Interface Type is V36.</summary>
		V36 = 65

		''' <summary>Interface Type is G703at64k.</summary>
		G703at64k = 66

		''' <summary>Interface Type is G703at2mb.</summary>
		G703at2mb = 67

		''' <summary>Interface Type is GLLC.</summary>
		GLLC = 68

		''' <summary>Interface Type is FastEthernetFX.</summary>
		FastEthernetFX = 69

		''' <summary>Interface Type is Channel.</summary>
		Channel = 70

		''' <summary>Interface Type is IEEE80211.</summary>
		IEEE80211 = 71

		''' <summary>Interface Type is IBM370parChan.</summary>
		IBM370parChan = 72

		''' <summary>Interface Type is EsCon.</summary>
		EsCon = 73

		''' <summary>Interface Type is DLSW.</summary>
		DLSW = 74

		''' <summary>Interface Type is ISDNs.</summary>
		ISDNs = 75

		''' <summary>Interface Type is ISDNu.</summary>
		ISDNu = 76

		''' <summary>Interface Type is LAPD.</summary>
		LAPD = 77

		''' <summary>Interface Type is IPSwitch.</summary>
		IPSwitch = 78

		''' <summary>Interface Type is RSRB.</summary>
		RSRB = 79

		''' <summary>Interface Type is ATMLogical.</summary>
		ATMLogical = 80

		''' <summary>Interface Type is DS0.</summary>
		DS0 = 81

		''' <summary>Interface Type is DS0Bundle.</summary>
		DS0Bundle = 82

		''' <summary>Interface Type is BSC.</summary>
		BSC = 83

		''' <summary>Interface Type is ASync.</summary>
		ASync = 84

		''' <summary>Interface Type is CNR.</summary>
		CNR = 85

		''' <summary>Interface Type is ISO88025Dtr.</summary>
		ISO88025Dtr = 86

		''' <summary>Interface Type is EPLRSlrs.</summary>
		EPLRSlrs = 87

		''' <summary>Interface Type is ARAP.</summary>
		ARAP = 88

		''' <summary>Interface Type is PropCnls.</summary>
		PropCnls = 89

		''' <summary>Interface Type is HostPad.</summary>
		HostPad = 90

		''' <summary>Interface Type is TermPad.</summary>
		TermPad = 91

		''' <summary>Interface Type is FrameRelayMPI.</summary>
		FrameRelayMPI = 92

		''' <summary>Interface Type is X213.</summary>
		X213 = 93

		''' <summary>Interface Type is ADSL.</summary>
		ADSL = 94

		''' <summary>Interface Type is RADSL.</summary>
		RADSL = 95

		''' <summary>Interface Type is SDSL.</summary>
		SDSL = 96

		''' <summary>Interface Type is VDSL.</summary>
		VDSL = 97

		''' <summary>Interface Type is ISO88025CRFPInt.</summary>
		ISO88025CRFPInt = 98

		''' <summary>Interface Type is Myrinet.</summary>
		Myrinet = 99

		''' <summary>Interface Type is VoiceEM.</summary>
		VoiceEM = 100

		''' <summary>Interface Type is VoiceFXO.</summary>
		VoiceFXO = 101

		''' <summary>Interface Type is VoiceFXS.</summary>
		VoiceFXS = 102

		''' <summary>Interface Type is VoiceEncap.</summary>
		VoiceEncap = 103

		''' <summary>Interface Type is VoiceOverIp.</summary>
		VoiceOverIp = 104

		''' <summary>Interface Type is AtmDxi.</summary>
		AtmDxi = 105

		''' <summary>Interface Type is AtmFuni.</summary>
		AtmFuni = 106

		''' <summary>Interface Type is AtmIma.</summary>
		AtmIma = 107

		''' <summary>Interface Type is PPPMultilinkBundle.</summary>
		PPPMultilinkBundle = 108

		''' <summary>Interface Type is IpOverCdlc.</summary>
		IpOverCdlc = 109

		''' <summary>Interface Type is IpOverClaw.</summary>
		IpOverClaw = 110

		''' <summary>Interface Type is StackToStack.</summary>
		StackToStack = 111

		''' <summary>Interface Type is VirtualIpAddress.</summary>
		VirtualIpAddress = 112

		''' <summary>Interface Type is MPC.</summary>
		MPC = 113

		''' <summary>Interface Type is IPOverAtm.</summary>
		IPOverAtm = 114

		''' <summary>Interface Type is ISO88025Fiber.</summary>
		ISO88025Fiber = 115

		''' <summary>Interface Type is TDLC.</summary>
		TDLC = 116

		''' <summary>Interface Type is GigabitEthernet.</summary>
		GigabitEthernet = 117

		''' <summary>Interface Type is HDLC.</summary>
		HDLC = 118

		''' <summary>Interface Type is LAPF.</summary>
		LAPF = 119

		''' <summary>Interface Type is V37.</summary>
		V37 = 120

		''' <summary>Interface Type is X25mlp.</summary>
		X25mlp = 121

		''' <summary>Interface Type is X25huntGroup.</summary>
		X25huntGroup = 122

		''' <summary>Interface Type is TrasnpHdlc.</summary>
		TrasnpHdlc = 123

		''' <summary>Interface Type is Interleave.</summary>
		Interleave = 124

		''' <summary>Interface Type is Fast.</summary>
		Fast = 125

		''' <summary>Interface Type is IP.</summary>
		IP = 126

		''' <summary>Interface Type is DocsCableMaclayer.</summary>
		DocsCableMaclayer = 127

		''' <summary>Interface Type is DocsCableDownstream.</summary>
		DocsCableDownstream = 128

		''' <summary>Interface Type is DocsCableUpstream.</summary>
		DocsCableUpstream = 129

		''' <summary>Interface Type is A12MppSwitch.</summary>
		A12MppSwitch = 130

		''' <summary>Interface Type is Tunnel.</summary>
		Tunnel = 131

		''' <summary>Interface Type is Coffee.</summary>
		Coffee = 132

		''' <summary>Interface Type is CES.</summary>
		CES = 133

		''' <summary>Interface Type is ATMSubInterface.</summary>
		ATMSubInterface = 134

		''' <summary>Interface Type is L2Vlan.</summary>
		L2Vlan = 135

		''' <summary>Interface Type is L3IPVlan.</summary>
		L3IPVlan = 136

		''' <summary>Interface Type is L3IPXVlan.</summary>
		L3IPXVlan = 137

		''' <summary>Interface Type is DigitalPowerline.</summary>
		DigitalPowerline = 138

		''' <summary>Interface Type is MediaMailOverIp.</summary>
		MediaMailOverIp = 139

		''' <summary>Interface Type is DTM.</summary>
		DTM = 140

		''' <summary>Interface Type is DCN.</summary>
		DCN = 141

		''' <summary>Interface Type is IPForward.</summary>
		IPForward = 142

		''' <summary>Interface Type is MSDSL.</summary>
		MSDSL = 143

		''' <summary>Interface Type is IEEE1394.</summary>
		IEEE1394 = 144

		''' <summary>Interface Type is IFgsn.</summary>
		IFgsn = 145

		''' <summary>Interface Type is DVBRccMacLayer.</summary>
		DVBRccMacLayer = 146

		''' <summary>Interface Type is DVBRccDownstream.</summary>
		DVBRccDownstream = 147

		''' <summary>Interface Type is DVBRccUpstream.</summary>
		DVBRccUpstream = 148

		''' <summary>Interface Type is ATMVirtual.</summary>
		ATMVirtual = 149

		''' <summary>Interface Type is MPLSTunnel.</summary>
		MPLSTunnel = 150

		''' <summary>Interface Type is SRP.</summary>
		SRP = 151

		''' <summary>Interface Type is VoiceOverAtm.</summary>
		VoiceOverAtm = 152

		''' <summary>Interface Type is VoiceOverFrameRelay.</summary>
		VoiceOverFrameRelay = 153

		''' <summary>Interface Type is IDSL.</summary>
		IDSL = 154

		''' <summary>Interface Type is CompositeLink.</summary>
		CompositeLink = 155

		''' <summary>Interface Type is SS7SigLink.</summary>
		SS7SigLink = 156

		''' <summary>Interface Type is PropWirelessP2P.</summary>
		PropWirelessP2P = 157

		''' <summary>Interface Type is FRForward.</summary>
		FRForward = 158

		''' <summary>Interface Type is RFC1483.</summary>
		RFC1483 = 159

		''' <summary>Interface Type is USB.</summary>
		USB = 160

		''' <summary>Interface Type is IEEE8023adLag.</summary>
		IEEE8023adLag = 161

		''' <summary>Interface Type is BGPpolicyaccounting.</summary>
		BGPpolicyaccounting = 162

		''' <summary>Interface Type is FRF16MfrBundle.</summary>
		FRF16MfrBundle = 163

		''' <summary>Interface Type is H323Gatekeeper.</summary>
		H323Gatekeeper = 164

		''' <summary>Interface Type is H323Proxy.</summary>
		H323Proxy = 165

		''' <summary>Interface Type is MPLS.</summary>
		MPLS = 166

		''' <summary>Interface Type is MFSigLink.</summary>
		MFSigLink = 167

		''' <summary>Interface Type is HDSl2.</summary>
		HDSl2 = 168

		''' <summary>Interface Type is SHDSL.</summary>
		SHDSL = 169

		''' <summary>Interface Type is DS1FDL.</summary>
		DS1FDL = 170

		''' <summary>Interface Type is POS.</summary>
		POS = 171

		''' <summary>Interface Type is DVBAsiIn.</summary>
		DVBAsiIn = 172

		''' <summary>Interface Type is DVBAsiOut.</summary>
		DVBAsiOut = 173

		''' <summary>Interface Type is PLC.</summary>
		PLC = 174

		''' <summary>Interface Type is NFAS.</summary>
		NFAS = 175

		''' <summary>Interface Type is TR008.</summary>
		TR008 = 176

		''' <summary>Interface Type is GR303RDT.</summary>
		GR303RDT = 177

		''' <summary>Interface Type is GR303IDT.</summary>
		GR303IDT = 178

		''' <summary>Interface Type is ISUP.</summary>
		ISUP = 179

		''' <summary>Interface Type is PropDocsWirelessMaclayer.</summary>
		PropDocsWirelessMaclayer = 180

		''' <summary>Interface Type is PropDocsWirelessDownstream.</summary>
		PropDocsWirelessDownstream = 181

		''' <summary>Interface Type is PropDocsWirelessUpstream.</summary>
		PropDocsWirelessUpstream = 182

		''' <summary>Interface Type is Hiperlan2.</summary>
		Hiperlan2 = 183

		''' <summary>Interface Type is PropBWAp2Mp.</summary>
		PropBWAp2Mp = 184

		''' <summary>Interface Type is SonetOverheadChannel.</summary>
		SonetOverheadChannel = 185

		''' <summary>Interface Type is DigitalWrapperOverheadChannel.</summary>
		DigitalWrapperOverheadChannel = 186

		''' <summary>Interface Type is AAL2.</summary>
		AAL2 = 187

		''' <summary>Interface Type is RadioMAC.</summary>
		RadioMAC = 188

		''' <summary>Interface Type is ATMRadio.</summary>
		ATMRadio = 189

		''' <summary>Interface Type is IMT.</summary>
		IMT = 190

		''' <summary>Interface Type is MVL.</summary>
		MVL = 191

		''' <summary>Interface Type is ReachDSL.</summary>
		ReachDSL = 192

		''' <summary>Interface Type is FRDlciEndPt.</summary>
		FRDlciEndPt = 193

		''' <summary>Interface Type is ATMVciEndPt.</summary>
		ATMVciEndPt = 194

		''' <summary>Interface Type is OpticalChannel.</summary>
		OpticalChannel = 195

		''' <summary>Interface Type is OpticalTransport.</summary>
		OpticalTransport = 196

		''' <summary>Interface Type is PropAtm.</summary>
		PropAtm = 197

		''' <summary>Interface Type is VoiceOverCable.</summary>
		VoiceOverCable = 198

		''' <summary>Interface Type is Infiniband.</summary>
		Infiniband = 199

		''' <summary>Interface Type is TELink.</summary>
		TELink = 200

		''' <summary>Interface Type is Q2931.</summary>
		Q2931 = 201

		''' <summary>Interface Type is VirtualTg.</summary>
		VirtualTg = 202

		''' <summary>Interface Type is SipTg.</summary>
		SipTg = 203

		''' <summary>Interface Type is SipSig.</summary>
		SipSig = 204

		''' <summary>Interface Type is DocsCableUpstreamChannel.</summary>
		DocsCableUpstreamChannel = 205

		''' <summary>Interface Type is Econet.</summary>
		Econet = 206

		''' <summary>Interface Type is PON155.</summary>
		PON155 = 207

		''' <summary>Interface Type is PON622.</summary>
		PON622 = 208

		''' <summary>Interface Type is Bridge.</summary>
		Bridge = 209

		''' <summary>Interface Type is LineGroup.</summary>
		LineGroup = 210

		''' <summary>Interface Type is VoiceEMFGD.</summary>
		VoiceEMFGD = 211

		''' <summary>Interface Type is VoiceFGDEANA.</summary>
		VoiceFGDEANA = 212

		''' <summary>Interface Type is VoiceDID.</summary>
		VoiceDID = 213

		''' <summary>Interface Type is MPEGTransport.</summary>
		MPEGTransport = 214

		''' <summary>Interface Type is SixToFour.</summary>
		SixToFour = 215

		''' <summary>Interface Type is GTP.</summary>
		GTP = 216

		''' <summary>Interface Type is PDNEtherLoop1.</summary>
		PDNEtherLoop1 = 217

		''' <summary>Interface Type is PDNEtherLoop2.</summary>
		PDNEtherLoop2 = 218

		''' <summary>Interface Type is OpticalChannelGroup.</summary>
		OpticalChannelGroup = 219

		''' <summary>Interface Type is HomePNA.</summary>
		HomePNA = 220

		''' <summary>Interface Type is GFP.</summary>
		GFP = 221

		''' <summary>Interface Type is CiscoISLvlan.</summary>
		CiscoISLvlan = 222

		''' <summary>Interface Type is ActelisMetaLOOP.</summary>
		ActelisMetaLOOP = 223

		''' <summary>Interface Type is FCIPLink.</summary>
		FCIPLink = 224

		''' <summary>Interface Type is RPR.</summary>
		RPR = 225

		''' <summary>Interface Type is QAM.</summary>
		QAM = 226

		''' <summary>Interface Type is LMP.</summary>
		LMP = 227

		''' <summary>Interface Type is CBLVectaStar.</summary>
		CBLVectaStar = 228

		''' <summary>Interface Type is DOCSCableMCmtsDownstream.</summary>
		DOCSCableMCmtsDownstream = 229

		''' <summary>Interface Type is ADSL2.</summary>
		ADSL2 = 230

		''' <summary>Interface Type is MacSecControlledIF.</summary>
		MacSecControlledIF = 231

		''' <summary>Interface Type is MacSecUncontrolledIF.</summary>
		MacSecUncontrolledIF = 232

		''' <summary>Interface Type is AviciOpticalEther.</summary>
		AviciOpticalEther = 233

		''' <summary>Interface Type is ATMbond.</summary>
		ATMbond = 234

	End Enum

End Namespace