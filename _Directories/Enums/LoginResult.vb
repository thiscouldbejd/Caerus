Namespace Directories

	''' <summary></summary>
	''' <autogenerated>Generated from a T4 template. Modifications will be lost, if applicable use a partial class instead.</autogenerated>
	''' <generator-date>08/02/2014 18:09:25</generator-date>
	''' <generator-functions>1</generator-functions>
	''' <generator-source>Caerus\_Directories\Enums\LoginResult.tt</generator-source>
	''' <generator-version>1</generator-version>
	<System.CodeDom.Compiler.GeneratedCode("Caerus\_Directories\Enums\LoginResult.tt", "1")> _
	<System.Serializable()> _
	Public Enum LoginResult As System.Int32

		''' <summary>Login was processed correctly</summary>
		OK = 0

		''' <summary>Login Account does not exist</summary>
		ACCOUNT_DOES_NOT_EXIST = 1

		''' <summary>Login Account is Inactive</summary>
		ACCOUNT_INACTIVE = 2

		''' <summary>Login Password is Wrong</summary>
		WRONG_PASSWORD = 3

	End Enum

End Namespace