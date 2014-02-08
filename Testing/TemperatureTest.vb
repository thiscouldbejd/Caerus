#If TESTING Then

Imports System.Configuration
Imports System.Reflection
Imports NUnit.Framework

Namespace Testing

	<TestFixture()> Public Class TemperatureTest

		#Region " Encode Testing "

			<Test(Description:="Temperature Parsing Testing")> _
			Public Sub ParseTest()

				Dim t_1 As Caerus.Temperature = Nothing
				Dim v_1 As String = "29 C/80 F"

				Dim t_2 As Caerus.Temperature = Nothing
				Dim v_2 As String = "46 C/114 F"

				Dim t_3 As Caerus.Temperature = Nothing
				Dim v_3 As String = "15.5 C/100.111 F"

				Dim t_4 As Caerus.Temperature = Nothing
				Dim v_4 As String = "30 C"

				Dim t_5 As Caerus.Temperature = Nothing
				Dim v_5 As String = "30C"

				Assert.IsTrue(Caerus.Temperature.TryParse(v_1, t_1))
				Assert.AreEqual(29, t_1.Value)
				Assert.AreEqual(80, t_1.Farenheit)
				Assert.AreEqual("29C", t_1.ToString())

				Assert.IsTrue(Caerus.Temperature.TryParse(v_2, t_2))
				Assert.AreEqual(46, t_2.Value)
				Assert.AreEqual(114, t_2.Farenheit)
				Assert.AreEqual("46C", t_2.ToString())

				Assert.IsTrue(Caerus.Temperature.TryParse(v_3, t_3))
				Assert.AreEqual(15.5, t_3.Value)
				Assert.AreEqual(100.111, t_3.Farenheit)
				Assert.AreEqual("15.5C", t_3.ToString())

				Assert.IsTrue(Caerus.Temperature.TryParse(v_4, t_4))
				Assert.AreEqual(30, t_4.Value)
				Assert.AreEqual(86, t_4.Farenheit)
				Assert.AreEqual("30C", t_4.ToString())

				Assert.IsTrue(Caerus.Temperature.TryParse(v_5, t_5))
				Assert.AreEqual(30, t_5.Value)
				Assert.AreEqual(86, t_5.Farenheit)
				Assert.AreEqual("30C", t_5.ToString())

			End Sub

		#End Region

	End Class

End Namespace

#End If
