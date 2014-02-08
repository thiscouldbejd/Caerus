Imports System.Net.Dns

Partial Public Class DeviceName

	#Region " Public Constants "

		''' <summary>
		''' HTTP Address Prefix
		''' </summary>
		Public Const PREFIX_HTTP As String = "http://"

		''' <summary>
		''' HTTPS Address Prefix
		''' </summary>
		Public Const PREFIX_HTTPS As String = "https://"

		''' <summary>
		''' Windows Management Instrumentation Ping Query
		''' </summary>
		Private Const WMI_PING As String = "SELECT * from Win32_PingStatus WHERE Address = '{0}' AND StatusCode = 0"

		''' <summary>
		''' WMI Ping Response Time
		''' </summary>
		Private Const PING_RESPONSETIME As String = "ResponseTime"

		''' <summary>
		''' Defininition (in ms) of a Slow Link
		''' </summary>
		Private Const SLOW_LINK As UInt32 = 5

	#End Region

	#Region " Public Properties "

		''' <summary>
		''' First IP Address for the Network Name
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		Public ReadOnly Property IpAddress() As System.Net.IPAddress
			Get
				If Not IpAddresses Is Nothing AndAlso IpAddresses.Length > 0 Then Return IpAddresses(0) Else Return Nothing
			End Get
		End Property

		Public ReadOnly Property ServerWebAddress( _
			Optional ByVal useSSL As Boolean = False _
		) As String
			Get

				If Not String.IsNullOrEmpty(Fqdn) Then

					If Not Fqdn.StartsWith(PREFIX_HTTP, StringComparison.OrdinalIgnoreCase) _
						AndAlso Not Fqdn.StartsWith(PREFIX_HTTPS, StringComparison.OrdinalIgnoreCase) Then

						If useSSL Then Return PREFIX_HTTPS & Fqdn Else Return PREFIX_HTTP & Fqdn

					End If

				End If

				Return Nothing

			End Get
		End Property

	#End Region

	#Region " Public Shared Methods "

		''' <summary>
		''' Method to Parse a Name from a String Value (could be an IP Address or FQDN).
		''' </summary>
		''' <param name="value">The Value to Parse.</param>
		''' <param name="parsedObject">The Returned Value if the Parse is Successfull.</param>
		''' <returns>A Boolean indicating Success or Failure</returns>
		''' <remarks></remarks>
		Public Shared Function TryParse( _
			ByVal value As String, _
			ByRef parsedObject As DeviceName _
		) As Boolean

			If String.IsNullOrEmpty(value) Then Return False Else value = value.Trim

			' -- IBM Specific Parsing (Server--IPADDRESS)
			If value.Contains(HYPHEN & HYPHEN) Then value = value.Substring(value.IndexOf(HYPHEN & HYPHEN) + 2)

			Dim l_IpHostEntry As IPHostEntry = Nothing
			Dim l_IpAddress As IPAddress = Nothing

			If IPAddress.TryParse(value, l_IpAddress) Then
				' -- Looks like this is an IP Address! --
				Try

					l_IpHostEntry = GetHostEntry(l_IpAddress)

				Catch ex As Exception
				End Try

				If l_IpHostEntry Is Nothing Then

					' -- IP Address parses, but no DNS Lookup --
					l_IpHostEntry = New IPHostEntry()
					l_IpHostEntry.AddressList = New IPAddress() {l_IpAddress}
					l_IpHostEntry.Hostname = l_IpAddress.ToString()

				End If

			Else

				Try

					l_IpHostEntry = GetHostEntry(value)
					If l_IpHostEntry Is Nothing Then Return False

				Catch ex As Exception

					Return False

				End Try

			End If

			Dim l_fullName As String = l_IpHostEntry.HostName
			Dim l_shortName As String = l_fullName

			If Not String.IsNullOrEmpty(l_shortName) _
				AndAlso l_shortName.IndexOf(FULL_STOP) >= 0 _
				AndAlso l_shortName.LastIndexOf(FULL_STOP) > l_shortName.IndexOf(FULL_STOP) _
				AndAlso l_shortName.IndexOf(SPACE) < 0 _
				AndAlso Not StringCommands.IsNumeric(l_shortName.Split(FULL_STOP)(0)) Then _
					l_shortName = l_fullName.Split(FULL_STOP)(0)

			Dim l_OrgName As String = Nothing
			Dim l_RoleName As String = Nothing
			Dim l_LayerName As String = Nothing
			Dim l_AreaName As String = Nothing
			Dim l_DeviceNumber As Int32

			If l_shortName.IndexOf(HYPHEN) > 0 Then

				Dim l_split As String() = l_shortName.Split( _
					New String() {HYPHEN}, StringSplitOptions.RemoveEmptyEntries)

				If l_split.Length > 0 Then l_OrgName = l_split(0).ToUpper

				If l_split.Length > 1 Then l_RoleName = l_split(1).ToUpper

				If l_split.Length > 2 Then l_LayerName = l_split(2).ToUpper

				If l_split.Length > 3 Then l_AreaName = l_split(3).ToUpper

				If l_split.Length > 4 AndAlso IsNumeric(l_split(4)) Then _
					l_DeviceNumber = Integer.Parse(l_split(4))

			End If

			parsedObject = New DeviceName(l_fullName, l_shortName, _
				l_IpHostEntry.AddressList, l_IpHostEntry.Aliases, l_OrgName, l_RoleName, _
				l_LayerName, l_AreaName, l_DeviceNumber)

			Return True

		End Function


		''' <summary>
		''' Public Method to Test Connectivity to the Device.
		''' </summary>
		''' <returns>A Boolean value indicating connectivity.</returns>
		''' <remarks></remarks>
		Public Shared Function IsAlive( _
			ByVal ipAddresses As IPAddress(), _
			Optional ByRef isSlow As Boolean = True _
		) As Boolean

			For i As Integer = 0 To ipAddresses.Length - 1

				If IsAlive(ipAddresses(i), isSlow) Then Return True

			Next

			Return False

		End Function

		''' <summary>
		''' Public Method to Test Connectivity to the Device.
		''' </summary>
		''' <returns>A Boolean value indicating connectivity.</returns>
		''' <remarks></remarks>
		Public Shared Function IsAlive( _
			ByVal ipAddress As IPAddress, _
			Optional ByRef isSlow As Boolean = True _
		) As Boolean

			Dim ret As Boolean = False

			If Not ipAddress Is Nothing Then

				Dim ping_Search As New ManagementObjectSearcher(New SelectQuery( _
					String.Format(WMI_PING, ipAddress.ToString)))

				For Each ping_Response As ManagementObject In ping_Search.Get()

					Dim ping_Time As System.UInt32 = ping_Response.GetPropertyValue(PING_RESPONSETIME)
					isSlow = (ping_Time >= SLOW_LINK)
					ret = True

				Next

			End If

			Return ret

		End Function

		''' <summary>
		''' Public Method to Test Connectivity to the Device.
		''' </summary>
		''' <returns>A Boolean value indicating connectivity.</returns>
		''' <remarks></remarks>
		Public Shared Function IsAlive( _
			ByVal ipAddress As String, _
			Optional ByRef isSlow As Boolean = False _
		) As Boolean

			Dim l_Name As DeviceName = Nothing

			If TryParse(ipAddress, l_Name) Then Return IsAlive(l_Name.IPAddress, isSlow)

			Return False

		End Function

	#End Region

End Class
