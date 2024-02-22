using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (input == null)
            {
                return false;
            }

            if (input == "")
            {
                return false;
            }

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

                result = true;
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
