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

            if (!StartsAndEndsWithDoubleQuote(input))
            {
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\' && !HandleAllEscapeSequences(input[i + 1], input, ref i))
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
            int countQuote = 0;
            foreach (char c in input)
            {
                if (c == '"')
                {
                    countQuote++;
                }
            }

            const int isPair = 2;
            return (input[0] == '"') && (input[^1] == '"') && countQuote % isPair == 0;
        }

        static bool HandleAllEscapeSequences(char nextChar, string input, ref int index)
        {
            return nextChar switch
            {
                'u' => CheckUnicodeValidity(input, index),
                '"' => !IsLastCharacter(input, index),
                _ => HandleBasicEscapeSequence(nextChar, ref index)
            };
        }

        static bool HandleBasicEscapeSequence(char nextChar, ref int index)
        {
            return nextChar switch
            {
                '\\' or '/' or 'b' => MoveForwardAndConfirm(ref index),
                'f' or 'n' or 'r' or 't' => MoveForwardAndConfirm(ref index),
                _ => false
            };
        }

        static bool MoveForwardAndConfirm(ref int index)
        {
            index++;
            return true;
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
            return (hexChar >= 'A' && hexChar <= 'F') || (hexChar >= 'a' && hexChar <= 'f');
        }

        static bool IsControlCharacter(char c)
        {
            const char lastControlCharacter = (char)31;
            return c < lastControlCharacter;
        }
    }
}
