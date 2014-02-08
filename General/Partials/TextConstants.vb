Public Class TextConstants

	#Region " Punctuation / Symbols "

		Public Const AMPERSAND As Char = "&"

		Public Const ANGLE_BRACKET_END As Char = ">"

		Public Const ANGLE_BRACKET_START As Char = "<"

		Public Const ASTERISK As Char = "*"

		Public Const AT_SIGN As Char = "@"

		Public Const BACK_SLASH As Char = "\"

		Public Const BRACE_END As Char = "}"

		Public Const BRACE_START As Char = "{"

		Public Const BRACKET_END As Char = ")"

		Public Const BRACKET_START As Char = "("

		Public Const COLON As Char = ":"

		Public Const COMMA As Char = ","

		Public Const DOLLAR As Char = "$"

		Public Const EXCLAMATION_MARK As Char = "!"

		Public Const EQUALS_SIGN As Char = "="

		Public Const FORWARD_SLASH As Char = "/"

		Public Const FULL_STOP As Char = "."

		Public Const HASH As Char = "#"

		Public Const HYPHEN As Char = "-"

		Public Const PERCENTAGE_MARK As Char = "%"

		Public Const PIPE As Char = "|"

		Public Const PLUS As Char = "+"

		Public Const QUESTION_MARK As Char = "?"

		Public Const QUOTE_SINGLE As Char = "'"

		Public Const QUOTE_DOUBLE As Char = """"

		Public Const SEMI_COLON As Char = ";"

		Public Const SPACE As Char = " "

		Public Const SQUARE_BRACKET_END As Char = "]"

		Public Const SQUARE_BRACKET_START As Char = "["

		Public Const TILDA As Char = "~"

		Public Const [TAB] As Char = Microsoft.VisualBasic.ChrW(&H9)

		Public Const UNDER_SCORE As Char = "_"

	#End Region

	#Region " Digits "

		Public Const DIGIT_ZERO As Char = "0"

		Public Const DIGIT_ONE As Char = "1"

		Public Const DIGIT_TWO As Char = "2"

		Public Const DIGIT_THREE As Char = "3"

		Public Const DIGIT_FOUR As Char = "4"

		Public Const DIGIT_FIVE As Char = "5"

		Public Const DIGIT_SIX As Char = "6"

		Public Const DIGIT_SEVEN As Char = "7"

		Public Const DIGIT_EIGHT As Char = "8"

		Public Const DIGIT_NINE As Char = "9"

		Public Shared DIGITS As Char() = _
			New Char() _
				{ _
					DIGIT_ZERO, _
					DIGIT_ONE, _
					DIGIT_TWO, _
					DIGIT_THREE, _
					DIGIT_FOUR, _
					DIGIT_FIVE, _
					DIGIT_SIX, _
					DIGIT_SEVEN, _
					DIGIT_EIGHT, _
					DIGIT_NINE _
				}

	#End Region

	#Region " Letters "

		Public Const LETTER_A As Char = "A"

		Public Const LETTER_B As Char = "B"

		Public Const LETTER_C As Char = "C"

		Public Const LETTER_D As Char = "D"

		Public Const LETTER_E As Char = "E"

		Public Const LETTER_F As Char = "F"

		Public Const LETTER_G As Char = "G"

		Public Const LETTER_H As Char = "H"

		Public Const LETTER_I As Char = "I"

		Public Const LETTER_J As Char = "J"

		Public Const LETTER_K As Char = "K"

		Public Const LETTER_L As Char = "L"

		Public Const LETTER_M As Char = "M"

		Public Const LETTER_N As Char = "N"

		Public Const LETTER_O As Char = "O"

		Public Const LETTER_P As Char = "P"

		Public Const LETTER_Q As Char = "Q"

		Public Const LETTER_R As Char = "R"

		Public Const LETTER_S As Char = "S"

		Public Const LETTER_T As Char = "T"

		Public Const LETTER_U As Char = "U"

		Public Const LETTER_V As Char = "V"

		Public Const LETTER_W As Char = "W"

		Public Const LETTER_X As Char = "X"

		Public Const LETTER_Y As Char = "Y"

		Public Const LETTER_Z As Char = "Z"

		Public Shared UPPERCASE_LETTERS As Char() = _
			New Char() _
				{ _
					LETTER_A, LETTER_B, LETTER_C, LETTER_D, LETTER_E, LETTER_F, LETTER_G, _
					LETTER_H, LETTER_I, LETTER_J, LETTER_K, LETTER_L, LETTER_M, LETTER_N, _
					LETTER_O, LETTER_P, LETTER_Q, LETTER_R, LETTER_S, LETTER_T, LETTER_U, _
					LETTER_V, LETTER_W, LETTER_X, LETTER_Y, LETTER_Z _
				}

		Public Shared LOWERCASE_LETTERS As Char() = _
			New Char() _
				{ _
					Char.ToLower(LETTER_A), Char.ToLower(LETTER_B), Char.ToLower(LETTER_C), _
					Char.ToLower(LETTER_D), Char.ToLower(LETTER_E), Char.ToLower(LETTER_F), _
					Char.ToLower(LETTER_G), Char.ToLower(LETTER_H), Char.ToLower(LETTER_I), _
					Char.ToLower(LETTER_J), Char.ToLower(LETTER_K), Char.ToLower(LETTER_L), _
					Char.ToLower(LETTER_M), Char.ToLower(LETTER_N), Char.ToLower(LETTER_O), _
					Char.ToLower(LETTER_P), Char.ToLower(LETTER_Q), Char.ToLower(LETTER_R), _
					Char.ToLower(LETTER_S), Char.ToLower(LETTER_T), Char.ToLower(LETTER_U), _
					Char.ToLower(LETTER_V), Char.ToLower(LETTER_W), Char.ToLower(LETTER_X), _
					Char.ToLower(LETTER_Y), Char.ToLower(LETTER_Z) _
				}

	#End Region

	#Region " Phonetic Digits "

		Public Const PHONETIC_ZERO As String = "Zero"

		Public Const PHONETIC_ONE As String = "One"

		Public Const PHONETIC_TWO As String = "Two"

		Public Const PHONETIC_THREE As String = "Three"

		Public Const PHONETIC_FOUR As String = "Four"

		Public Const PHONETIC_FIVE As String = "Five"

		Public Const PHONETIC_SIX As String = "Six"

		Public Const PHONETIC_SEVEN As String = "Seven"

		Public Const PHONETIC_EIGHT As String = "Eight"

		Public Const PHONETIC_NINE As String = "Nine"

		Public Shared PHONETIC_DIGITS As String() = _
			New String() _
				{ _
					PHONETIC_ZERO, PHONETIC_ONE, PHONETIC_TWO, _
					PHONETIC_THREE, PHONETIC_FOUR, PHONETIC_FIVE, _
					PHONETIC_SIX, PHONETIC_SEVEN, PHONETIC_EIGHT, PHONETIC_NINE _
				}

	#End Region

	#Region " Phonetic Letters "

		Public Const PHONETIC_LOWERCASE_A As String = "Alpha"

		Public Const PHONETIC_LOWERCASE_B As String = "Bravo"

		Public Const PHONETIC_LOWERCASE_C As String = "Charlie"

		Public Const PHONETIC_LOWERCASE_D As String = "Delta"

		Public Const PHONETIC_LOWERCASE_E As String = "Echo"

		Public Const PHONETIC_LOWERCASE_F As String = "Foxtrot"

		Public Const PHONETIC_LOWERCASE_G As String = "Golf"

		Public Const PHONETIC_LOWERCASE_H As String = "Hotel"

		Public Const PHONETIC_LOWERCASE_I As String = "India"

		Public Const PHONETIC_LOWERCASE_J As String = "Juliet"

		Public Const PHONETIC_LOWERCASE_K As String = "Kilo"

		Public Const PHONETIC_LOWERCASE_L As String = "Lima"

		Public Const PHONETIC_LOWERCASE_M As String = "Mike"

		Public Const PHONETIC_LOWERCASE_N As String = "November"

		Public Const PHONETIC_LOWERCASE_O As String = "Oscar"

		Public Const PHONETIC_LOWERCASE_P As String = "Papa"

		Public Const PHONETIC_LOWERCASE_Q As String = "Quebec"

		Public Const PHONETIC_LOWERCASE_R As String = "Romeo"

		Public Const PHONETIC_LOWERCASE_S As String = "Sierra"

		Public Const PHONETIC_LOWERCASE_T As String = "Tango"

		Public Const PHONETIC_LOWERCASE_U As String = "Uniform"

		Public Const PHONETIC_LOWERCASE_V As String = "Victor"

		Public Const PHONETIC_LOWERCASE_W As String = "Whiskey"

		Public Const PHONETIC_LOWERCASE_X As String = "X-Ray"

		Public Const PHONETIC_LOWERCASE_Y As String = "Yankee"

		Public Const PHONETIC_LOWERCASE_Z As String = "Zulu"

		Public Shared PHONETIC_LOWERCASE_LETTERS As String() = _
			New String() _
				{ _
					PHONETIC_LOWERCASE_A, PHONETIC_LOWERCASE_B, PHONETIC_LOWERCASE_C, _
					PHONETIC_LOWERCASE_D, PHONETIC_LOWERCASE_E, PHONETIC_LOWERCASE_F, _
					PHONETIC_LOWERCASE_G, PHONETIC_LOWERCASE_H, PHONETIC_LOWERCASE_I, _
					PHONETIC_LOWERCASE_J, PHONETIC_LOWERCASE_K, PHONETIC_LOWERCASE_L, _
					PHONETIC_LOWERCASE_M, PHONETIC_LOWERCASE_N, PHONETIC_LOWERCASE_O, _
					PHONETIC_LOWERCASE_P, PHONETIC_LOWERCASE_Q, PHONETIC_LOWERCASE_R, _
					PHONETIC_LOWERCASE_S, PHONETIC_LOWERCASE_T, PHONETIC_LOWERCASE_U, _
					PHONETIC_LOWERCASE_V, PHONETIC_LOWERCASE_W, PHONETIC_LOWERCASE_X, _
					PHONETIC_LOWERCASE_Y, PHONETIC_LOWERCASE_Z _
				}

		Public Shared PHONETIC_UPPERCASE_A As String = PHONETIC_LOWERCASE_A.ToUpper

		Public Shared PHONETIC_UPPERCASE_B As String = PHONETIC_LOWERCASE_B.ToUpper

		Public Shared PHONETIC_UPPERCASE_C As String = PHONETIC_LOWERCASE_C.ToUpper

		Public Shared PHONETIC_UPPERCASE_D As String = PHONETIC_LOWERCASE_D.ToUpper

		Public Shared PHONETIC_UPPERCASE_E As String = PHONETIC_LOWERCASE_E.ToUpper

		Public Shared PHONETIC_UPPERCASE_F As String = PHONETIC_LOWERCASE_F.ToUpper

		Public Shared PHONETIC_UPPERCASE_G As String = PHONETIC_LOWERCASE_G.ToUpper

		Public Shared PHONETIC_UPPERCASE_H As String = PHONETIC_LOWERCASE_H.ToUpper

		Public Shared PHONETIC_UPPERCASE_I As String = PHONETIC_LOWERCASE_I.ToUpper

		Public Shared PHONETIC_UPPERCASE_J As String = PHONETIC_LOWERCASE_J.ToUpper

		Public Shared PHONETIC_UPPERCASE_K As String = PHONETIC_LOWERCASE_K.ToUpper

		Public Shared PHONETIC_UPPERCASE_L As String = PHONETIC_LOWERCASE_L.ToUpper

		Public Shared PHONETIC_UPPERCASE_M As String = PHONETIC_LOWERCASE_M.ToUpper

		Public Shared PHONETIC_UPPERCASE_N As String = PHONETIC_LOWERCASE_N.ToUpper

		Public Shared PHONETIC_UPPERCASE_O As String = PHONETIC_LOWERCASE_O.ToUpper

		Public Shared PHONETIC_UPPERCASE_P As String = PHONETIC_LOWERCASE_P.ToUpper

		Public Shared PHONETIC_UPPERCASE_Q As String = PHONETIC_LOWERCASE_Q.ToUpper

		Public Shared PHONETIC_UPPERCASE_R As String = PHONETIC_LOWERCASE_R.ToUpper

		Public Shared PHONETIC_UPPERCASE_S As String = PHONETIC_LOWERCASE_S.ToUpper

		Public Shared PHONETIC_UPPERCASE_T As String = PHONETIC_LOWERCASE_T.ToUpper

		Public Shared PHONETIC_UPPERCASE_U As String = PHONETIC_LOWERCASE_U.ToUpper

		Public Shared PHONETIC_UPPERCASE_V As String = PHONETIC_LOWERCASE_V.ToUpper

		Public Shared PHONETIC_UPPERCASE_W As String = PHONETIC_LOWERCASE_W.ToUpper

		Public Shared PHONETIC_UPPERCASE_X As String = PHONETIC_LOWERCASE_X.ToUpper

		Public Shared PHONETIC_UPPERCASE_Y As String = PHONETIC_LOWERCASE_Y.ToUpper

		Public Shared PHONETIC_UPPERCASE_Z As String = PHONETIC_LOWERCASE_Z.ToUpper

		Public Shared PHONETIC_UPPERCASE_LETTERS As String() = _
			New String() _
				{ _
					PHONETIC_UPPERCASE_A, PHONETIC_UPPERCASE_B, PHONETIC_UPPERCASE_C, _
					PHONETIC_UPPERCASE_D, PHONETIC_UPPERCASE_E, PHONETIC_UPPERCASE_F, _
					PHONETIC_UPPERCASE_G, PHONETIC_UPPERCASE_H, PHONETIC_UPPERCASE_I, _
					PHONETIC_UPPERCASE_J, PHONETIC_UPPERCASE_K, PHONETIC_UPPERCASE_L, _
					PHONETIC_UPPERCASE_M, PHONETIC_UPPERCASE_N, PHONETIC_UPPERCASE_O, _
					PHONETIC_UPPERCASE_P, PHONETIC_UPPERCASE_Q, PHONETIC_UPPERCASE_R, _
					PHONETIC_UPPERCASE_S, PHONETIC_UPPERCASE_T, PHONETIC_UPPERCASE_U, _
					PHONETIC_UPPERCASE_V, PHONETIC_UPPERCASE_W, PHONETIC_UPPERCASE_X, _
					PHONETIC_UPPERCASE_Y, PHONETIC_UPPERCASE_Z _
				}

	#End Region

End Class