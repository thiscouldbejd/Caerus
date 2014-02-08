Namespace Snmp

	Public Interface ISnmpManageable

		''' <summary>
		''' The Target.
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		ReadOnly Property Target() As IPAddress()

		''' <summary>
		''' The Snmp Community (e.g. SNMP).
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		ReadOnly Property Community() As String

	End Interface

End Namespace
