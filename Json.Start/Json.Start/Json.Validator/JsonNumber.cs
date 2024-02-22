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

            for (int i = 0; i < input.Length; i++)
            {
            if (input[i] >= '0' && input[i] <= '9')
            {
                result = true;
            }
            }

            return result;
        }
    }
}
