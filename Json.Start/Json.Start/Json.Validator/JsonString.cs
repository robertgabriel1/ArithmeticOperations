using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            const bool result = true;
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            foreach (char c in input)
            {
                if (IsControlCharacter(c) && !ContainsAtSymbol(input))
                {
                    return false;
                }
            }

            if (!StartsAndEndsWithDoubleQuote(input))
            {
                return false;
            }

            return result;
        }

        static bool StartsAndEndsWithDoubleQuote(string input)
        {
            return (input[0] == '"') && (input[input.Length - 1] == '"');
        }

        static bool ContainsAtSymbol(string input)
        {
            return input.StartsWith("@");
        }

        static bool IsControlCharacter(char c)
        {
        const int lastControlCharacter = 32;
        return c < lastControlCharacter;
        }
    }
}
