Imports R = Leviathan.Resources

Partial Public Class NetworkInterface
	Implements IMonitorable

	#Region " Private Shared Variables "

		Private Shared INTERFACE_EXEMPTIONS As String() = New String() _
			{"StackPort", "StackSub", "WAN Miniport", "Microsoft ISATAP", "Teredo Tunneling", "Microsoft Teredo Tunneling", "isatap", "Virtual-", "Microsoft Hyper-V Network Switch"}

	#End Region

	#Region " IMonitorable Implementation "

		''' <summary>
		''' Returns the Health of the Interface.
		''' </summary>
		''' <returns></returns>
		''' <remarks></remarks>
		Public ReadOnly Property IsNetworkInterfaceHealthy() As Health Implements IMonitorable.IsHealthy
			Get

				' -- Check Interface Description to see if it starts and ends with an ASTERISK (e.g. Exempt)
				If Not String.IsNullOrEmpty(Description) AndAlso Description.StartsWith(R.ASTERISK) AndAlso Description.EndsWith(R.ASTERISK) Then _
					Return New Health(HealthStatus.Healthy)

				' -- Check for Exemption Names (common on Windows Servers)
				For i As Integer = 0 To INTERFACE_EXEMPTIONS.Length - 1

					If Name Is Nothing OrElse Name.Name.StartsWith(INTERFACE_EXEMPTIONS(i), StringComparison.Ordinal) Then _
						Return New Health(HealthStatus.Healthy)

				Next

				If (AdminStatus = InterfaceStatus.UP AndAlso _
					Not (Status = InterfaceStatus.UP OrElse Status = InterfaceStatus.DORMANT _
					OrElse Status = InterfaceStatus.TESTING)) Then

					Return New Health(HealthStatus.Down, String.Format(Resources.HEALTH_GENERAL_NETWORKINTERFACEDOWN, Name.ShortName))

				Else

					Return New Health(HealthStatus.Healthy)

				End If

			End Get
		End Property

	#End Region

End Class
