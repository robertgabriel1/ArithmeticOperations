using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (!StartsAndEndsWithDoubleQuote(input) && !IsQuotedPairCountEven(input))
            {
                return false;
            }

            int step = 1;
            for (int i = 0; i < input.Length - 1; i += step)
            {
                step = 1;
                char currentChar = input[i];
                char nextChar = input[i + 1];
                if (currentChar == '\\' && !HandleAllEscapeSequences(nextChar, input, i, ref step))
                {
                    return false;
                }
                else if (IsControlCharacter(currentChar))
                {
                    return false;
                }
            }

            return true;
        }

        static bool StartsAndEndsWithDoubleQuote(string input)
        {
            return (input[0] == '"') && (input[^1] == '"');
        }

        static bool IsQuotedPairCountEven(string input)
        {
            int countQuote = 0;
            foreach (char c in input)
            {
                if (c == '"')
                {
                    countQuote++;
                }
            }

            const int isPair = 2;
            return countQuote % isPair == 0;
        }

        static bool HandleAllEscapeSequences(char charToCheck, string input, int index, ref int step)
        {
            int nextCharIndex = index + 1;
            const int charsToSkipIfIsUnicode = 4;
            if (charToCheck == 'u' && IsValidUnicodeSequence(input, nextCharIndex))
            {
                step += charsToSkipIfIsUnicode;
                return true;
            }
            else if (charToCheck == '"' && !IsLastCharacter(input, nextCharIndex))
            {
                step++;
                return true;
            }
            else
            {
                if (IsCharacterEscape(charToCheck))
                {
                    step++;
                    return true;
                }
            }

            return false;
        }

        static bool IsCharacterEscape(char c)
        {
            return c switch
            {
                'f' or 'n' or 'r' or '/' => true,
                'b' or 't' or '\\' => true,
                _ => false
            };
        }

        static bool IsLastCharacter(string input, int nextCharIndex)
        {
            return nextCharIndex == input.Length - 1;
        }

        static bool IsValidUnicodeSequence(string input, int nextCharIndex)
        {
            const int unicodeCharactersToCheck = 5;
            for (int j = 1; j < unicodeCharactersToCheck; j++)
            {
                char hexChar = input[nextCharIndex + j];
                if (!IsValidHex(hexChar))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsValidHex(char hexChar)
        {
            return char.IsDigit(hexChar) || IsHexLetter(hexChar);
        }

        static bool IsHexLetter(char hexChar)
        {
            return char.ToUpper(hexChar) >= 'A' && char.ToUpper(hexChar) <= 'F';
        }

        static bool IsControlCharacter(char c)
        {
            return c < ' ';
        }
    }
}
