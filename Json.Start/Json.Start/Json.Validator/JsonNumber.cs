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
            bool isNegative = input[0] == '-';
            string number = isNegative ? input.Substring(1) : input;
            return CanContainOneOrMultipleDigits(number) && FirstDigitIsNotZero(number);
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
            return input.Length <= 1 || input[0] != '0';
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
