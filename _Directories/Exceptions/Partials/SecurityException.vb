Namespace Directories
	
	Partial Public Class SecurityException

		#Region " Public Constructors "
			
			Public Sub New( _
				ByVal message As String _
			)
			
				MyBase.New(message)
				
			End Sub
			
			Public Sub New( _
				ByVal message As String, _
				ByVal innerException As Exception _
			)
				
				MyBase.New(message, innerException)
				
			End Sub
			
		#End Region
		
	End Class

End Namespace