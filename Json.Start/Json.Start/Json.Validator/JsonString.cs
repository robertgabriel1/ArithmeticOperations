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
                if (input[i] == '\\' && !AfterBackslash(input[i + 1], input))
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

        static bool AfterBackslash(char nextChar, string input)
        {
            switch (nextChar)
            {
                case '"':
                case '/':
                case 'b':
                    return true;
                default:
                    return false;
            }
        }

        static bool IsControlCharacter(char c)
        {
        const int lastControlCharacter = 32;
        return c < lastControlCharacter;
        }
    }
}
