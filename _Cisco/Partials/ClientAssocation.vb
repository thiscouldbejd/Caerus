Imports Caerus.Snmp.SnmpConnection

Namespace Cisco

	Partial Public Class ClientAssociation
		Implements IMonitorable

		#Region " Public Properties "

			Public ReadOnly Property ClientOid As String
				Get
					Return PhysicalAddressToOid(ClientAddress)
				End Get
			End Property

			Public ReadOnly Property ActualSignalStrength As Int32
				Get
					Return SignalStrength - 256
				End Get
			End Property

			Public ReadOnly Property MSDU_Tx_Failed_Ratio As System.Single
				Get
					If OutPackets.ValueDeltaInSec = 0 OrElse MSDU_Tx_Failed.ValueDeltaInSec = 0 Then
						Return 0
					Else
						Return MSDU_Tx_Failed.ValueDeltaInSec / OutPackets.ValueDeltaInSec
					End If
				End Get
			End Property

			Public ReadOnly Property MSDU_Tx_Retries_Ratio As System.Single
				Get
					If OutPackets.ValueDeltaInSec = 0 OrElse MSDU_Tx_Retries.ValueDeltaInSec = 0 Then
						Return 0
					Else
						Return MSDU_Tx_Retries.ValueDeltaInSec / OutPackets.ValueDeltaInSec
					End If
				End Get
			End Property

			Public ReadOnly Property MicErrors_Ratio As System.Single
				Get
					If InPackets.ValueDeltaInSec = 0 OrElse MicErrors.ValueDeltaInSec = 0 Then
						Return 0
					Else
						Return MicErrors.ValueDeltaInSec / InPackets.ValueDeltaInSec
					End If
				End Get
			End Property

			Public ReadOnly Property MicMissing_Ratio As System.Single
				Get
					If InPackets.ValueDeltaInSec = 0 OrElse MicMissing.ValueDeltaInSec = 0 Then
						Return 0
					Else
						Return MicMissing.ValueDeltaInSec / InPackets.ValueDeltaInSec
					End If
				End Get
			End Property

		#End Region

		#Region " IMonitorable Implementation "

			Public Overridable ReadOnly Property IsClientAssocationHealthy() As Health Implements IMonitorable.IsHealthy
				Get

					If OutPackets.ValueDeltaInSec > ValidPacketLevel AndAlso MSDU_Tx_Failed_Ratio >= DegradedLevel Then _
						Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_CISCO_CLIENTASSOCIATIONTRANSMITFAILSTOOHIGH, _
							New PercentageValue(MSDU_Tx_Failed_Ratio), New PercentageValue(DegradedLevel)))

					If OutPackets.ValueDeltaInSec > ValidPacketLevel AndAlso MSDU_Tx_Retries_Ratio >= DegradedLevel Then _
						Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_CISCO_CLIENTASSOCIATIONTRANSMITRETRIESTOOHIGH, _
							New PercentageValue(MSDU_Tx_Failed_Ratio), New PercentageValue(DegradedLevel)))

					If InPackets.ValueDeltaInSec > ValidPacketLevel AndAlso MicErrors_Ratio >= DegradedLevel Then _
						Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_CISCO_CLIENTASSOCIATIONMICERRORSTOOHIGH, _
							New PercentageValue(MicErrors_Ratio), New PercentageValue(DegradedLevel)))

					If InPackets.ValueDeltaInSec > ValidPacketLevel AndAlso MicMissing_Ratio >= DegradedLevel Then _
						Return New Health(HealthStatus.Degraded, String.Format(Resources.HEALTH_CISCO_CLIENTASSOCIATIONMICMISSINGTOOHIGH, _
							New PercentageValue(MicMissing_Ratio), New PercentageValue(DegradedLevel)))

					Return New Health(HealthStatus.Healthy)

				End Get
			End Property

		#End Region

	End Class

End Namespace
