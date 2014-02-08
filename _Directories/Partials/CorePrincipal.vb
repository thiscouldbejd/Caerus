Imports System.Security.Principal
Imports System.Security.Permissions

Namespace Directories
	
	Public Class CorePrincipal
	    Implements System.Security.Principal.IPrincipal
	
	#Region " Friend Methods "
	
	    ''' <summary>
	    ''' This method will populate the roles for this IPrincipal Object.
	    ''' </summary>
	    ''' <param name="roles">The custom roles to all to the <seealso cref="roles" /> Property.</param>
	    ''' <remarks></remarks>
	    Friend Sub AddRoles( _
	        ByVal roles As String() _
	    )
	
	        For i As Integer = 0 To roles.Length - 1
	            If Not m_Roles.Contains(roles(i).Trim(" ").ToLower) Then
	                m_Roles.Add(roles(i).Trim(" ").ToLower)
	            End If
	        Next
	        m_Roles.Sort()
	
	    End Sub
	
	#End Region
	
	#Region " IPrincipal Implementation "
	
	    ''' <summary>
	    ''' Public Method which checks whether this IPrincipal is in a particular role (case insensitive).
	    ''' </summary>
	    ''' <param name="role">The role to check.</param>
	    ''' <returns></returns>
	    ''' <remarks></remarks>
	    Public Function IsInRole( _
	        ByVal role As String _
	    ) As Boolean _
	    Implements System.Security.Principal.IPrincipal.IsInRole
	
	        Return m_Roles.Contains(role.Trim(" ").ToLower)
	
	    End Function
	
	#End Region
	
	#Region " Public Methods "
	
	    ''' <summary>
	    ''' Public Method which checks whether this IPrincipal is in all the particular roles (case insensitive).
	    ''' </summary>
	    ''' <param name="roles">The roles to check.</param>
	    ''' <returns></returns>
	    ''' <remarks></remarks>
	    Public Function IsInAllRoles( _
	        ByVal roles As String() _
	    ) As Boolean
	
	        For Each role As String In roles

	            If Not IsInRole(role) Then Return False

	        Next

					Return True
	
	    End Function
	
	    ''' <summary>
	    ''' Public Method which checks whether this IPrincipal is in any the particular roles (case insensitive).
	    ''' </summary>
	    ''' <param name="roles">The roles to check.</param>
	    ''' <returns></returns>
	    ''' <remarks></remarks>
	    Public Function IsInAnyRoles( _
	        ByVal roles As String() _
	    ) As Boolean
	
	        For Each role As String In roles

	            If IsInRole(role) Then Return True

	        Next
	
					Return False

	    End Function
	
	    ''' <summary>
	    ''' This method overrides the Default ToString Method to provide a String Representation of the Object.
	    ''' </summary>
	    ''' <returns></returns>
	    ''' <remarks>The Representation will consist of the Display name (if present) or the Identity.Name (if not present).</remarks>
	    Public Overrides Function ToString() As String
	        If Me.DisplayName = Nothing Then
	            If Me.Identity Is Nothing Then
	                Return MyBase.ToString
	            Else
	                Return Me.Identity.Name
	            End If
	        Else
	            Return Me.DisplayName
	        End If
	    End Function
	
	#End Region
	
	#Region " Public Properties "
	
	    ''' <summary>
	    ''' Provides access to the Roles to which this IPrincipal belongs.
	    ''' </summary>
	    ''' <value></value>
	    ''' <returns></returns>
	    ''' <remarks></remarks>
	    Public ReadOnly Property Roles() As String()
	        Get
	            Return Me.m_Roles.ToArray(GetType(String))
	        End Get
	    End Property
	
	#End Region
	
	End Class
	
End Namespace
