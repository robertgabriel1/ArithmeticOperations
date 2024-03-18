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

            for (int i = 0; i < input.Length - 1; i++)
            {
                char currentChar = input[i];
                char nextChar = input[i + 1];
                if (currentChar == '\\' && !HandleAllEscapeSequences(nextChar, input, i))
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

        static bool HandleAllEscapeSequences(char charToCheck, string input, int index)
        {
            int nextCharIndex = index + 1;
            return charToCheck switch
            {
                'u' => CheckUnicodeValidity(input, nextCharIndex),
                '"' => !IsLastCharacter(input, nextCharIndex),
                _ => IsEscapeSequence(input, index, charToCheck)
            };
        }

        static bool IsEscapeSequence(string input, int index, char c)
        {
            if (c == 'f' || c == 'n' || c == 'r')
            {
                return true;
            }
            else if (c == '/' || c == 'b' || c == 't' || IsValidBackslash(input, index, c))
            {
                return true;
            }

            return false;
        }

        static bool IsValidBackslash(string input, int index, char c)
        {
            if (c == '\\')
            {
                return true;
            }
            else if (input[index - 1] == '\\')
            {
                return true;
            }

            return false;
        }

        static bool IsLastCharacter(string input, int nextCharIndex)
        {
            return nextCharIndex == input.Length - 1;
        }

        static bool CheckUnicodeValidity(string input, int nextCharIndex)
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
