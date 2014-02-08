Namespace Directories

    ''' <summary>
    ''' Provides a Common Interface for Providing Access to Disparate Directory Services Providers.
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IConnection

        ''' <summary>
        ''' Property for Accessing the Username to be used for the Connection.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Username() As String

        ''' <summary>
        ''' Property for Accessing the Password to be used for the Connection.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Password() As String

        ''' <summary>
        ''' Property for Accessing the Authentication Type to be used for the Connection.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property AuthenticationType() As AuthenticationType

        ''' <summary>
        ''' Property for Accessing the Server (for explicit connections) to be used for the Connection.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Server() As String

        ''' <summary>
        ''' Property for Accessing the Base Entry Point/Level/Context to be used for the Connection.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Base() As String

        ''' <summary>
        ''' Property for Accessing the String Representation of the Connection.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Connection() As String

        ''' <summary>
        ''' Property for Accessing the Root/Base of the Connection as a DirectoryEntry.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Root() As DirectoryEntry

        ''' <summary>
        ''' Property for Accessing/Creating a Directory Entry based on a Specific Path.
        ''' </summary>
        ''' <param name="path">The Path to Use in the Creation/Accessing of the DirectoryEntry.</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property DirectoryEntry( _
        	ByVal path As String _
        ) As DirectoryEntry

        ''' <summary>
        ''' Property for Accessing/Creating a Directory Entry based on a Specific Identifier/Guid.
        ''' </summary>
        ''' <param name="guid">The Guid to Use in the Creation/Accessing of the DirectoryEntry.</param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property DirectoryEntry( _
        	ByVal guid As Guid _
        ) As DirectoryEntry

        ''' <summary>
        ''' Method for Creating a Particular Directory Entry from Scratch.
        ''' </summary>
        ''' <param name="parentPath">The Path (Parent) at which to Create the Directory Entry.</param>
        ''' <param name="name">The Name of the Entry to Create.</param>
        ''' <param name="schemaName">The Schema for the Entry to Create.</param>
        ''' <returns>Returns the newly created Directory Entry.</returns>
        ''' <remarks></remarks>
        Function CreateDirectoryEntry( _
        	ByVal parentPath As String, _
        	ByVal name As String, _
        	ByVal schemaName As String _
        ) As DirectoryEntry

        ''' <summary>
        ''' Method for Returning a Provider Specific Property Name.
        ''' </summary>
        ''' <param name="property">The Enumerated Property to Get.</param>
        ''' <returns>The Name of the Property.</returns>
        ''' <remarks></remarks>
        Function GetDirectoryPropertyName( _
        	ByVal [Property] As CommonProperties _
        ) As String

        ''' <summary>
        ''' Method for Returning a Provider Specific Schema Name.
        ''' </summary>
        ''' <param name="schema">The Enumerated Schema to Get.</param>
        ''' <returns>The Name of the Schema.</returns>
        ''' <remarks></remarks>
        Function GetDirectorySchemaName( _
        	ByVal schema As CommonSchemas _
        ) As String

        ''' <summary>
        ''' Method for Returning a Provider Specific Action Name.
        ''' </summary>
        ''' <param name="action">The Enumerated Action to Get.</param>
        ''' <returns>The Name of the Action.</returns>
        ''' <remarks></remarks>
        Function GetDirectoryActionName( _
        	ByVal action As CommonActions _
        ) As String

    End Interface

End Namespace

