using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            if (!StartsAndEndsWithDoubleQuote(key))
            {
                return false;
            }

            for (int i = 0; i < key.Length; i++)
            {
                if (key[i] == '\\' && !AfterBackslash(key[i + 1], key, ref i))
                {
                    return false;
                }
                else if (IsControlCharacter(key[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static bool StartsAndEndsWithDoubleQuote(string key)
        {
            return (key[0] == '"') && (key[key.Length - 1] == '"');
        }

        static bool AfterBackslash(char nextChar, string key, ref int index)
        {
            switch (nextChar)
            {
                case 'u':
                    return CheckUnicodeValidity(key, index);
                case '"':
                    return index + 1 != key.Length - 1;
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

        static bool CheckUnicodeValidity(string key, int i)
        {
            const int numbersOfHexChars = 4;
            for (int j = 0; j < numbersOfHexChars; j++)
            {
                char hexChar = key[i + j + 2];
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
            return (hexChar >= 'A' && hexChar <= 'F') || (hexChar >= 'a' && hexChar <= 'f');
        }

        static bool IsControlCharacter(char c)
        {
            const int lastControlCharacter = 32;
            return c < lastControlCharacter;
        }
    }
}
