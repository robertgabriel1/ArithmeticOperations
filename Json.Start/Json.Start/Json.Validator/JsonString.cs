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

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\' && input[i + 1] == '\\')
                {
                    return true;
                }
                else if (input[i] == '\\' && !HandleAllEscapeSequences(input[i + 1], input, i))
                {
                    return false;
                }
                else if (IsControlCharacter(input[i]))
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

        static bool HandleAllEscapeSequences(char nextChar, string input, int index)
        {
            return nextChar switch
            {
                'u' => CheckUnicodeValidity(input, index),
                '"' => !IsLastCharacter(input, index),
                '/' or 'b' => true,
                'f' or 'n' or 'r' or 't' => true,
                _ => false
            };
        }

        static bool IsLastCharacter(string input, int index)
        {
            return index + 1 == input.Length - 1;
        }

        static bool CheckUnicodeValidity(string input, int i)
        {
            const int numbersOfHexChars = 4;
            for (int j = 0; j < numbersOfHexChars; j++)
            {
                char hexChar = input[i + j + 2];
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
