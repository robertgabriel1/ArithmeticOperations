using System;
using System.Reflection;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !string.IsNullOrEmpty(input) && CanBeNegative(input);
        }

        static bool CanBeNegative(string input)
        {
            bool isNegative = input[0] == '-';
            string number = isNegative ? input.Substring(1) : input;
            return ContainsValidCharacters(number) && FirstDigitIsNotZero(number);
        }

        static bool ContainsValidCharacters(string input)
        {
            int index = 0;
            int countDots = CountDotsOrExponents(input, '.');
            int countExponent = CountDotsOrExponents(input, 'e') + CountDotsOrExponents(input, 'E');
            foreach (char c in input)
            {
                if (IsValidDotOrExponent(input, c, index))
                {
                    return false;
                }
                else if (IsPositiveOrNegativeExponent(input, c, index))
                {
                    return true;
                }
                else if (!IsDigit(c) && !IsExponent(c) && c != '.')
                {
                    return false;
                }

                index++;
            }

            return countDots <= 1 && countExponent <= 1;
        }

        static int CountDotsOrExponents(string input, char targetCharacter)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c == targetCharacter)
                {
                    count++;
                }
            }

            return count;
        }

        static bool IsPositiveOrNegativeExponent(string input, char c, int index)
        {
            return IsPlusOrMinus(c, input, index) && IsExponent(input[index - 1]) && IsNotFirstOrLastIndex(input, index);
        }

        static bool IsValidDotOrExponent(string input, char c, int index)
        {
            return (c == '.' || IsExponent(c)) && !IsNotFirstOrLastIndex(input, index);
        }

        static bool IsPlusOrMinus(char c, string input, int index)
        {
            return c == '+' || c == '-' && IsNotFirstOrLastIndex(input, index);
        }

        static bool IsExponent(char c)
        {
            return c == 'e' || c == 'E';
        }

        static bool IsNotFirstOrLastIndex(string input, int index)
        {
            return index != 0 && index != input.Length - 1;
        }

        static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        static bool FirstDigitIsNotZero(string input)
        {
            if (input.Length <= 1)
            {
                return true;
            }

            char lastChar = input[input.Length - 1];
            return input[0] != '0' || input[1] == '.';
        }
    }
}
