Imports System.Resources
Imports System.Reflection

Public Class Resources

	''' <summary>
	''' Public Constant Reference to the Name of the Resources Property.
	''' </summary>
	''' <remarks></remarks>
	Public Const PROPERTY_RESOURCES As String = "Resources"

	''' <summary>
	''' Public Constant Reference to the Name of the Single Resource Property.
	''' </summary>
	''' <remarks></remarks>
	Public Const PROPERTY_SINGLERESOURCE As String = "SingleResource"

	#Region " Resource Manager Names "

		''' <summary>
		''' Public Const Reference to the Name of the Resource Manager for Health Detail Messages.
		''' </summary>
		''' <remarks></remarks>
		Public Const RESOURCEMANAGER_NAME_HEALTH As String = "HealthDetails"

		''' <summary>
		''' Public Const Reference to the Name of the Resource Manager for Exception Messages.
		''' </summary>
		''' <remarks></remarks>
		Public Const RESOURCEMANAGER_NAME_EXCEPTION As String = "ExceptionMessages"

		''' <summary>
		''' Public Const Reference to the Name of the Resource Manager for Log Messages.
		''' </summary>
		''' <remarks></remarks>
		Public Const RESOURCEMANAGER_NAME_LOG As String = "LogMessages"
		
	#End Region

	#Region " Private Shared Variables "

		Private Shared ResType As Type = GetType(Caerus.Resources)

	#End Region

	#Region " Public Shared Health Variables "

		''' <summary>
		''' Provides Access to an Health Message for Device Down.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_GENERAL_NETWORKDEVICEDOWN As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthGeneralNetworkDeviceDown")

		''' <summary>
		''' Provides Access to an Health Message for the Storage Device Usage.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_GENERAL_STORAGEDEVICEUSAGE As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthGeneralStorageDeviceUsage")

		''' <summary>
		''' Provides Access to an Health Message for Temperature (too low).
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_GENERAL_TEMPERATURELOW As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthGeneralTemperatureTooLow")

		''' <summary>
		''' Provides Access to an Health Message for Temperature (too high).
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_GENERAL_TEMPERATUREHIGH As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthGeneralTemperatureTooHigh")

		''' <summary>
		''' Provides Access to an Health Message for a Down Network Interface.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_GENERAL_NETWORKINTERFACEDOWN As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthGeneralNetworkInterfaceDown")

		''' <summary>
		''' Provides Access to an Health Message for a Cisco Client Association Transmit Fails.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_CISCO_CLIENTASSOCIATIONTRANSMITFAILSTOOHIGH As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthCiscoClientAssociationTransmitFailsTooHigh")

		''' <summary>
		''' Provides Access to an Health Message for a Cisco Client Association Transmit Retries.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_CISCO_CLIENTASSOCIATIONTRANSMITRETRIESTOOHIGH As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthCiscoClientAssociationTransmitRetriesTooHigh")

		''' <summary>
		''' Provides Access to an Health Message for a Cisco Client Association MIC Errors.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_CISCO_CLIENTASSOCIATIONMICERRORSTOOHIGH As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthCiscoClientAssociationMICErrorsTooHigh")

		''' <summary>
		''' Provides Access to an Health Message for a Cisco Client Association MIC Missing.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_CISCO_CLIENTASSOCIATIONMICMISSINGTOOHIGH As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthCiscoClientAssociationMICMissingTooHigh")

		''' <summary>
		''' Provides Access to an Health Message for a Cisco Entity Sensor Non-Operational.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_CISCO_ENTITYSENSORNONOPERATIONAL As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthCiscoEntitySensorNonOperational")

		''' <summary>
		''' Provides Access to an Health Message for a Cisco Monitor Status.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_CISCO_MONITORSTATUS As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthCiscoMonitorStatus")

		''' <summary>
		''' Provides Access to an Health Message for a Cisco Sensor Status.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_CISCO_SENSORSTATUS As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthCiscoSensorStatus")

		''' <summary>
		''' Provides Access to an Health Message for a Cisco Vlan Suspended.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_CISCO_VLANSUSPENDED As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthCiscoVlanSuspended")

		''' <summary>
		''' Provides Access to an Health Message for a IBM Blade Server State.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_IBM_BLADESERVERSTATUS As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthIBMBladeServerStatus")

		''' <summary>
		''' Provides Access to an Health Message for a IBM Blade Centre Blower State.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_IBM_BLOWERSTATUS As String = _
		SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthIBMBladeBlowerStatus")

		''' <summary>
		''' Provides Access to an Health Message for a IBM Blade Centre Power Domain State.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_IBM_POWERDOMAINSTATUS As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthIBMBladePowerDomainStatus")

		''' <summary>
		''' Provides Access to an Health Message for a IBM Blade Centre Power Supply State.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_IBM_POWERSUPPLYSTATUS As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthIBMBladePowerSupplyStatus")

		''' <summary>
		''' Provides Access to an Health Message for a IBM Blade Centre Switch State.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_IBM_SWITCHSTATUS As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthIBMBladeSwitchStatus")

		''' <summary>
		''' Provides Access to an Health Message for a IBM Blade Centre Temperature Sensor Offline.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_IBM_TEMPERATURESENSOROFFLINE As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthIBMBladeTemperatureSensorOffline")

		''' <summary>
		''' Provides Access to an Health Message for a QNAP Hard Drive Not Ready.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_QNAP_HARDDRIVENOTREADY As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthQNAPHardDriveNotReady")

		''' <summary>
		''' Provides Access to an Health Message for a QNAP Hard Drive Bad SMART Status.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_QNAP_HARDDRIVEBADSMART As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthQNAPHardDriveBadSMART")

		''' <summary>
		''' Provides Access to an Health Message for a QNAP Volumne Not Ready.
		''' </summary>
		''' <remarks></remarks>
		Public Shared HEALTH_QNAP_VOLUMENOTREADY As String = _
			SingleResource(ResType, RESOURCEMANAGER_NAME_HEALTH, "healthQNAPHardDriveVolumeNotReady")

	#End Region

	#Region " Public Shared Read-Only Properties "

		''' <summary>
		''' Provides Access to a ResourceManager for a particular Resource contained within a 
		''' Particular Assembly.
		''' </summary>
		''' <param name="containingAssembly">The Assembly containing the Resources.</param>
		''' <param name="resourcesName">The Name of the Resources.</param>
		''' <value></value>
		''' <returns>A Resource Manager.</returns>
		''' <remarks></remarks>
		Public Shared ReadOnly Property Resources( _
			ByVal containingAssembly As Assembly, _
			ByVal resourcesName As String _
		) As ResourceManager

			Get

				Dim cache As Leviathan.Caching.Simple = Leviathan.Caching.Simple.GetInstance(GetType(Resources).GetHashCode)

				Dim manager As ResourceManager = Nothing

				If Not cache.TryGet(manager, PROPERTY_RESOURCES.GetHashCode, containingAssembly.GetHashCode, resourcesName.GetHashCode) Then

					Dim allResources As String() = containingAssembly.GetManifestResourceNames()

					If Not allResources Is Nothing AndAlso allResources.Length > 0 Then

						For i As Integer = 0 To allResources.Length - 1

							If allResources(i).Contains(FULL_STOP & resourcesName & FULL_STOP) Then

								manager = New ResourceManager( _
									allResources(i).Substring(0, allResources(i). _
									IndexOf(FULL_STOP & resourcesName & FULL_STOP)) & _
									FULL_STOP & resourcesName, containingAssembly)

								Exit For

							End If

						Next

					End If

					cache.Set(manager, PROPERTY_RESOURCES.GetHashCode, containingAssembly.GetHashCode, resourcesName.GetHashCode)

				End If

				Return manager

			End Get

		End Property

		''' <summary>
		''' Provides Access to a ResourceManager for a particular Resource contained within a
		''' Particular Type.
		''' </summary>
		''' <param name="containingType">The Type containing the Resources.</param>
		''' <param name="resourcesName">The Name of the Resources.</param>
		''' <value></value>
		''' <returns>A Resource Manager.</returns>
		''' <remarks></remarks>
		Public Shared ReadOnly Property Resources( _
			ByVal containingType As System.Type, _
			ByVal resourcesName As String _
		) As ResourceManager

			Get

				Return Resources(containingType.Assembly, resourcesName)

			End Get

		End Property

		''' <summary>
		''' Provides Access to a Single Resource String for a Particular Assembly, Resource Name and Key.
		''' </summary>
		''' <param name="containingAssembly">The Assembly containing the Resources.</param>
		''' <param name="resourcesName">The Name of the Resources.</param>
		''' <param name="resourceKey">The Key of the Resource String.</param>
		''' <value></value>
		''' <returns>A String.</returns>
		''' <remarks></remarks>
		Public Shared ReadOnly Property SingleResource( _
			ByVal containingAssembly As System.Reflection.Assembly, _
			ByVal resourcesName As String, _
			ByVal resourceKey As String _
		) As String

			Get

				Return Resources(containingAssembly, resourcesName).GetString(resourceKey, System.Globalization.CultureInfo.CurrentUICulture)

			End Get

		End Property

		''' <summary>
		''' Provides Access to a Single Resource String for a Particular Assembly, Resource Name and Key.
		''' </summary>
		''' <param name="containingType">The Type containing the Resources.</param>
		''' <param name="resourcesName">The Name of the Resources.</param>
		''' <param name="resourceKey">The Key of the Resource String.</param>
		''' <value></value>
		''' <returns>A String.</returns>
		''' <remarks></remarks>
		Public Shared ReadOnly Property SingleResource( _
			ByVal containingType As System.Type, _
			ByVal resourcesName As String, _
			ByVal resourceKey As String _
		) As String

			Get

				Return SingleResource(containingType.Assembly, resourcesName, resourceKey)

			End Get

		End Property

	#End Region

End Class