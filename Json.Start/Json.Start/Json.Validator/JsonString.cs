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

            result = (input[0] == '"') && (input[input.Length - 1] == '"');

            return result;
        }
    }
}
