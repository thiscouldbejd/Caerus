Imports System.Xml
Imports System.Xml.Serialization

Namespace Snmp

    Partial Public Class ObjectMapping

		#Region " Public Methods "

			Public Function Compile( _
				ByVal analyser As TypeAnalyser _
			) As ObjectMapping
			
				For i As Integer = 0 To TableMappings.Length - 1
						
					TableMappings(i).Compile(TypeAnalyser.GetInstance( _
						TableMappings(i).MappingType).ElementTypeAnalyser)
		
				Next

				For i As Integer = 0 To FieldMappings.Length - 1
		
					FieldMappings(i).Member = New MemberAnalyser()
		
					If Not FieldMappings(i).Member.Parse(FieldMappings(i).Name, Nothing, analyser, 0, MemberAccessibility.All) Then _
						Throw New MemberNotFoundException(FieldMappings(i).Name, analyser.Type)

				Next
				
				Array.Sort(FieldMappings)
				
				Return Me
				
		    End Function

			Public Overridable Sub Integrate( _
		        ByRef mappingToIntegrate As ObjectMapping _
		    )
		
				If mappingToIntegrate.GetType Is GetType(ObjectMapping) _
					OrElse mappingToIntegrate.GetType.IsSubclassOf(GetType(ObjectMapping)) Then
		
					Dim newMapping As ObjectMapping = mappingToIntegrate
		
					If Not newMapping.TableMappings Is Nothing Then
		
						For i As Integer = 0 To newMapping.TableMappings.Length - 1
		
							Dim mappingName As String = newMapping.TableMappings(i).Name
							Dim alreadyExists As Boolean = False
		
							If TableMappings Is Nothing Then TableMappings = New TableMapping() {}
		
							For j As Integer = 0 To TableMappings.Length - 1
		
								If String.Compare(mappingName, TableMappings(j).Name, True) = 0 Then
		
									alreadyExists = True
		
									Exit For
		
								End If
		
							Next
		
							If Not alreadyExists Then
		
								Array.Resize(TableMappings, TableMappings.Length + 1)
		
								TableMappings(TableMappings.Length - 1) = newMapping.TableMappings(i)
		
							End If
		
						Next
		
					End If
		
				End If
		            
		        If Not mappingToIntegrate.FieldMappings Is Nothing Then
		
		            For i As Integer = 0 To mappingToIntegrate.FieldMappings.Length - 1
		
		                Dim mappingName As String = _
		                    mappingToIntegrate.FieldMappings(i).Name
		                Dim alreadyExists As Boolean = False
		
		                If FieldMappings Is Nothing Then FieldMappings = New FieldMapping() {}
		
		                For j As Integer = 0 To FieldMappings.Length - 1
		
		                    If String.Compare(mappingName, _
		                       FieldMappings(j).Name, True) = 0 Then
		
		                        alreadyExists = True
		
		                        Exit For
		
		                    End If
		
		                Next
		
		                If Not alreadyExists Then
		
		                    Array.Resize(FieldMappings, FieldMappings.Length + 1)
		
		                    FieldMappings(FieldMappings.Length - 1) = mappingToIntegrate.FieldMappings(i)
		
		                End If
		
		            Next
		
		        End If
		
		    End Sub

		    Public Overridable Sub PopulateObjectFromMap( _
				ByRef target As Object, _
				ByVal values As Dictionary(Of MemberAnalyser, Object) _
			)
		
				For Each member As MemberAnalyser In values.Keys
					
					PopulateObjectFromMap(target, member,  values(member))
					
				Next
		
		    End Sub
		    
		    Public Overridable Sub PopulateObjectFromMap( _
				ByRef target As Object, _
				ByVal member As MemberAnalyser, _
				ByVal value As Object _
			)
		
				If Not value Is Nothing Then
						
					Dim populate As Boolean = True
			
					If value.GetType Is GetType(String) AndAlso Not member.ReturnType Is GetType(String) Then _
						value = New FromString().Parse(value, populate, member.ReturnType)
			
					If populate Then member.Write(target, TypeAnalyser.Wedge(value, member.ReturnType, populate))
						
				End If
		
		    End Sub
		    
		#End Region

    End Class

End Namespace