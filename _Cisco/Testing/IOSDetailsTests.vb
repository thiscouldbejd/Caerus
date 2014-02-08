#If DEBUG Then

Imports NUnit.Framework

Namespace Cisco.Testing

	<TestFixture()> _
	Public Class IOSDetailsTests

		<Test(Description:="Test Parsing to IOS Details")> _
		Public Sub TestParsing()

			Dim details_1 As String = _
				"Cisco IOS Software, C1200 Software (C1200-K9W7-M), Version 12.3(8)JA, RELEASE SOFTWARE (fc2)" & Environment.NewLine & _
				"Technical Support: http://www.cisco.com/techsupport" & Environment.NewLine & _
				"Copyright (c) 1986-2006 by Cisco Systems, Inc." & Environment.NewLine & _
				"Compiled Mon 27-Feb-06 09:09 by ssearch"

			Dim ios_1 As IOSDetails = Nothing
			Assert.IsTrue(IOSDetails.TryParse(details_1, ios_1))
			Assert.IsNotNull(ios_1)
			Assert.AreEqual("C1200-K9W7-M", ios_1.Image)
			Assert.AreEqual(System.Single.Parse("12.3"), ios_1.Version)
			Assert.AreEqual(8, ios_1.Release)
			Assert.AreEqual(27, ios_1.CompilationDate.Day)
			Assert.AreEqual(2, ios_1.CompilationDate.Month)
			Assert.AreEqual(2006, ios_1.CompilationDate.Year)
			Assert.AreEqual(9, ios_1.CompilationDate.Hour)
			Assert.AreEqual(9, ios_1.CompilationDate.Minute)
			Assert.AreEqual("ssearch", ios_1.CompiledBy)
			Assert.AreEqual(IOSTrain.Wireless, ios_1.Train)

			Dim details_2 As String = _
				"Cisco IOS Software, Catalyst 4500 L3 Switch Software (cat4500-IPBASEK9-M), Version 12.2(37)SG, RELEASE SOFTWARE (fc1)" & Environment.NewLine & _
				"Technical Support: http://www.cisco.com/techsupport" & Environment.NewLine & _
				"Copyright (c) 1986-2007 by Cisco Systems, Inc." & Environment.NewLine & _
				"Compiled Tue 17-Apr-07 18:35 by prod_rel_team"

			Dim ios_2 As IOSDetails = Nothing
				Assert.IsTrue(IOSDetails.TryParse(details_2, ios_2))
				Assert.AreEqual("cat4500-IPBASEK9-M", ios_2.Image)
				Assert.AreEqual(System.Single.Parse("12.2"), ios_2.Version)
				Assert.AreEqual(37, ios_2.Release)
				Assert.AreEqual(17, ios_2.CompilationDate.Day)
				Assert.AreEqual(4, ios_2.CompilationDate.Month)
				Assert.AreEqual(2007, ios_2.CompilationDate.Year)
				Assert.AreEqual(18, ios_2.CompilationDate.Hour)
				Assert.AreEqual(35, ios_2.CompilationDate.Minute)
				Assert.AreEqual("prod_rel_team", ios_2.CompiledBy)
				Assert.AreEqual(IOSTrain.ServiceProvider, ios_2.Train)

			Dim details_3 As String = _
				"Cisco Internetwork Operating System Software" & Environment.NewLine & _
				"IOS (tm) C2950 Software (C2950-I6Q4L2-M), Version 12.1(22)EA9, RELEASE SOFTWARE (fc1)" & Environment.NewLine & _
				"Copyright (c) 1986-2006 by cisco Systems, Inc." & Environment.NewLine & _
				"Compiled Fri 01-Dec-06 18:02 by weiliu"

			Dim ios_3 As IOSDetails = Nothing
			Assert.IsTrue(IOSDetails.TryParse(details_3, ios_3))
			Assert.AreEqual("C2950-I6Q4L2-M", ios_3.Image)
			Assert.AreEqual(System.Single.Parse("12.1"), ios_3.Version)
			Assert.AreEqual(22, ios_3.Release)
			Assert.AreEqual(1, ios_3.CompilationDate.Day)
			Assert.AreEqual(12, ios_3.CompilationDate.Month)
			Assert.AreEqual(2006, ios_3.CompilationDate.Year)
			Assert.AreEqual(18, ios_3.CompilationDate.Hour)
			Assert.AreEqual(2, ios_3.CompilationDate.Minute)
			Assert.AreEqual("weiliu", ios_3.CompiledBy)
			Assert.AreEqual(IOSTrain.Enterprise, ios_3.Train)

			Dim details_4 As String = ""

			Dim ios_4 As IOSDetails = Nothing
			Assert.IsFalse(IOSDetails.TryParse(details_4, ios_4))

		End Sub

	End Class

End Namespace

#End If
