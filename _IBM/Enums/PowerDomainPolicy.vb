Namespace IBM

	''' <summary>Enum Representing IBM Power Domain Policy</summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 18:20:29</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_IBM\Enums\PowerDomainPolicy.tt</generator-source>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_IBM\Enums\PowerDomainPolicy.tt", "1")> _
	Public Enum PowerDomainPolicy As System.Int32

		''' <summary>Policy is Redundant Without Performance Impact</summary>
		RedundantWithoutPerformanceImpact = 0

		''' <summary>Policy is Redundant With Performance Impact</summary>
		RedundantWithPerformanceImpact = 1

		''' <summary>Policy is Non Redundant</summary>
		NonRedundant = 2

		''' <summary>Policy is Non Applicable</summary>
		NotApplicable = 255

	End Enum

End Namespace