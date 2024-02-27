using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            bool result;
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            foreach (char c in input)
            {
                if (IsControlCharacter(c))
                {
                    return false;
                }
            }

            result = (input[0] == '"') && (input[input.Length - 1] == '"');

            return result;
        }

        static bool IsControlCharacter(char c)
        {
            return c == '\n' || c == '\r';
        }
    }
}
