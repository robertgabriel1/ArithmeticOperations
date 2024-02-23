using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !string.IsNullOrEmpty(input) && ContainsValidDigits(input);
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
            int index = 0;
            foreach (char c in input)
            {
                if (c == '.' && index != 0)
                {
                    result = true;
                    break;
                }
                else if (!(c >= '0' && c <= '9'))
                {
                    result = false;
                    break;
                }

                index++;
            }

            return result;
        }

        static bool FirstDigitIsNotZero(string input)
        {
            return input.Length <= 1 || input[0] != '0' || input[1] == '.';
        }
    }
}
