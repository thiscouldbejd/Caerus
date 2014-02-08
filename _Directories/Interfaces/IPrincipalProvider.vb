Namespace Directories
	
	''' <summary>
	''' This Interface defines the Common Methods that should be implemented by a Principal Provider.
	''' </summary>
	''' <remarks>A Principal Provider is a class which can process IIdentities into CorePrincipals.
	''' An Update method is also provided to allow updates without re-authentications.</remarks>
	Public Interface IPrincipalProvider
	
	    ''' <summary>
	    ''' Creates a CorePrincipal Object for the given IIdentity.
	    ''' </summary>
	    ''' <param name="identity"></param>
	    ''' <returns></returns>
	    ''' <remarks></remarks>
	    Function CreateIPrincipal( _
	        ByVal identity As System.Security.Principal.IIdentity _
	    ) As CorePrincipal
	
	    ''' <summary>
	    ''' Creates a CorePrincipal Object for the given IIdentity and Password
	    ''' (should perform an Authentication to ensure password is correct).
	    ''' </summary>
	    ''' <param name="identity"></param>
	    ''' <param name="password"></param>
	    ''' <returns></returns>
	    ''' <remarks></remarks>
	    Function CreateIPrincipal( _
	        ByVal identity As System.Security.Principal.IIdentity, _
	        ByVal password As String _
	    ) As CorePrincipal
	
	    ''' <summary>
	    ''' Updates a CorePrincipal from the Provider.
	    ''' </summary>
	    ''' <param name="principle">The CorePrincipal to Update.</param>
	    ''' <returns></returns>
	    ''' <remarks></remarks>
	    Function UpdateIPrincipal( _
	        ByVal principle As CorePrincipal _
	    ) As CorePrincipal
	
	    ''' <summary>
	    ''' Creates CorePrincipal Objects for the given Role.
	    ''' </summary>
	    ''' <param name="role"></param>
	    ''' <returns></returns>
	    ''' <remarks></remarks>
	    Function CreateIPrincipals( _
	        ByVal role As String _
	    ) As CorePrincipal()
	
	End Interface

End Namespace