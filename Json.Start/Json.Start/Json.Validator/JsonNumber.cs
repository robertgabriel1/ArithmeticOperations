using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            bool result = false;
            if (input == "0")
            {
                result = true;
            }

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
