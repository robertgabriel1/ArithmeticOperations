using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            bool result;
            result = (input[0] == '"') && (input[input.Length - 1] == '"');

            return result;
        }
    }
}
