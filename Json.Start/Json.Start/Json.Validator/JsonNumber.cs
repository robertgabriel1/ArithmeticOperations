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

            if (input.Length == 1 && input[0] >= '0' && input[0] <= '9')
            {
                result = true;
            }

            return result;
        }
    }
}
