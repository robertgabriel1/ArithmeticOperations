using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !string.IsNullOrEmpty(input) && ContainsValidDigits(input) && ContainsLetters(input);
        }

        static bool ContainsValidDigits(string input)
        {
            return CanContainOneOrMultipleDigits(input) && FirstDigitIsNotZero(input);
        }

        static bool CanContainOneOrMultipleDigits(string input)
        {
            bool result = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (!(input[i] >= '0' && input[i] <= '9'))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        static bool FirstDigitIsNotZero(string input)
        {
            if (input.Length < 1)
            {
                return true;
            }
            else if (input.Length > 1 && input[0] == '0')
            {
                return false;
            }

            return true;
        }

        static bool ContainsLetters(string input)
        {
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
