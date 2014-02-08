Namespace Directories

    Partial Public Class Parameter

#Region " Public Methods "

        ''' <summary>
        ''' Overrides the Default ToString Representation of the Object to output the Parameter
        ''' in a string format ready for querying the Directory Service.
        ''' </summary>
        ''' <returns>A String Representation of the Parameter.</returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
        	
        	Dim s_builder As New System.Text.StringBuilder

            With s_builder
            	
            	If Not Relation Is Nothing Then
            		.Append(BRACKET_START)

	                Select Case [Operator]
	                	
	                	Case ParameterOperator.AndOperator
	                		
	                        s_builder.Append(AMPERSAND)
	                        
	                	Case ParameterOperator.NotEquality
	                		
	                        s_builder.Append(EXCLAMATION_MARK)
	                        
	                	Case ParameterOperator.OrEquality
	                		
	                        s_builder.Append(PIPE)
	                        
	                End Select
                
            	End If
                
                .Append(BRACKET_START)
                
                .Append(Name.ToString)
                
                Select Case Comparative
                	
                	Case ParameterComparator.ApproximatelyEqualTo
                		
                		.Append(TILDA).Append(EQUALS_SIGN)
                        
                	Case ParameterComparator.EqualTo
                		
                        .Append(EQUALS_SIGN)
                        
                	Case ParameterComparator.GreaterThanOrEqualTo
                		
                        .Append(ANGLE_BRACKET_END).Append(EQUALS_SIGN)
                        
                	Case ParameterComparator.LessThanOrEqualTo
                		
                        .Append(ANGLE_BRACKET_START).Append(EQUALS_SIGN)
                        
                End Select
                
                .Append(StringCommands.ObjectToSingleString([Object], SEMI_COLON))
                
                .Append(BRACKET_END)
                
                If Not Relation Is Nothing Then .Append(Relation.ToString).Append(BRACKET_END)

            End With

            Return s_builder.ToString
            
        End Function

#End Region

    End Class

End Namespace