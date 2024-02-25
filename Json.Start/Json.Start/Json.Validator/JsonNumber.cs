using System;

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
            int countDots = 0;
            int countExponent = 0;
            foreach (char c in input)
            {
                if ((c == '.' || IsExponent(c)) && IsValidDotOrExponent(input, c, index))
                {
                    if (c == '.')
                    {
                        countDots++;
                    }
                    else
                    {
                        countExponent++;
                    }
                }
                else if (IsPlusOrMinus(c) && IsExponent(input[index - 1]))
                {
                    return true;
                }
                else if (!IsDigit(c) && !IsExponent(c))
                {
                    return false;
                }

                index++;
            }

            return countDots <= 1 && countExponent <= 1;
        }

        static bool IsPlusOrMinus(char c)
        {
            return c == '+' || c == '-';
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

        static bool IsValidDotOrExponent(string input, char c, int index)
        {
            return (c == '.' || IsExponent(c)) && IsNotFirstOrLastIndex(input, index);
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
