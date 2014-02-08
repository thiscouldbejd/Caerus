Namespace Cisco

	Partial Public Class FrequencyBand

		#Region " Public Properties "

			Public ReadOnly Property EndFrequency As System.Int32
				Get
					Return ((EndChannel - StartChannel) * FrequencySpacing) + StartFrequency
				End Get
			End Property

		#End Region

	End Class

End Namespace
