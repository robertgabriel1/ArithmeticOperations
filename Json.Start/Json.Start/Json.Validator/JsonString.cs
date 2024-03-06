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
                if (input[i] == '\\' && !AfterBackslash(input[i + 1], input, ref i))
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
            return (input[0] == '"') && (input[input.Length - 1] == '"');
        }

        static bool AfterBackslash(char nextChar, string input, ref int index)
        {
            switch (nextChar)
            {
                case 'u':
                    return CheckUnicodeValidity(input, index);
                case '"':
                    return index + 1 != input.Length - 1;
                case '\\':
                case '/':
                case 'b':
                case 'f':
                case 'n':
                case 'r':
                case 't':
                    index++;
                    return true;
                default:
                    return false;
            }
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
            return (hexChar >= '0' && hexChar <= '9') || IsLetter(hexChar);
        }

        static bool IsLetter(char hexChar)
        {
            return (hexChar >= 'A' && hexChar <= 'Z') || (hexChar >= 'a' && hexChar <= 'z');
        }

        static bool IsControlCharacter(char c)
        {
            const int lastControlCharacter = 32;
            return c < lastControlCharacter;
        }
    }
}
