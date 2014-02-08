Public Interface IMonitorable

	''' <summary>
	''' Whether the Device has is Healthy (e.g. has ICMP Connectivity/responds to pings).
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	ReadOnly Property IsHealthy() As Health

End Interface