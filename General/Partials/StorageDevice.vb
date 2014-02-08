Partial Public Class StorageDevice
	Implements IMonitorable

	#Region " Public Properties "

		''' <summary>
		''' The Storage Usage
		''' </summary>
		Public ReadOnly Property Usage As PercentageValue
			Get
				If UsedUnits <= 0 AndAlso SizeUnits > 0 Then

					Return New PercentageValue(0)

				ElseIf UsedUnits <=0 AndAlso SizeUnits <= 0 Then

					Return New PercentageValue(0)

				Else

					Return New PercentageValue(UsedUnits / SizeUnits)

				End If
			End Get
		End Property

		Public ReadOnly Property Size() As StorageSize
			Get
				Return New StorageSize(SizeUnits * AllocationUnits.Value)
			End Get
		End Property

		Public ReadOnly Property Used() As StorageSize
			Get
				Return New StorageSize(UsedUnits * AllocationUnits.Value)
			End Get
		End Property

	#End Region

	#Region " IMonitorable Implementation "

		Public ReadOnly Property IsStorageDeviceHealthy() As Health Implements IMonitorable.IsHealthy
			Get

			If Usage.Value >= WarningLevel Then

				Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_GENERAL_STORAGEDEVICEUSAGE, Name, Usage))

			Else

				Return New Health(HealthStatus.Healthy)

			End If

			End Get
		End Property

	#End Region

End Class
