using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            bool isNegative = input[0] == '-';
            string number = isNegative ? input.Substring(1) : input;
            return ContainsValidCharacters(number) && FirstDigitIsNotZero(number);
        }

        static bool ContainsValidCharacters(string input)
        {
            int currentIndex = 0;
            int indexDot = 0;
            int indexExponent = 0;
            int countDots = CountDotsOrExponents(input, '.');
            int countExponents = CountDotsOrExponents(input, 'e') + CountDotsOrExponents(input, 'E');
            foreach (char c in input)
            {
                if (IsNotValidDotOrExponent(input, c, currentIndex))
                {
                    return false;
                }
                else if (IsPositiveOrNegativeExponent(input, c, currentIndex))
                {
                    return true;
                }
                else if (!IsDigit(c) && !IsExponent(c) && c != '.')
                {
                    return false;
                }

                UpdateIndicesForDotAndExponent(c, ref indexDot, ref indexExponent, currentIndex);
                currentIndex++;
            }

            if (IsFractionBeforeExponent(countDots, countExponents, indexDot, indexExponent))
            {
                return false;
            }

            return countDots <= 1 && countExponents <= 1;
        }

        static void UpdateIndicesForDotAndExponent(char c, ref int indexDot, ref int indexExponent, int currentIndex)
        {
            if (c == '.')
            {
                indexDot = currentIndex;
            }
            else if (IsExponent(c))
            {
                indexExponent = currentIndex;
            }
        }

        static bool IsFractionBeforeExponent(int countDots, int countExponents, int indexDot, int indexExponent)
        {
           return countDots == 1 && countExponents == 1 && indexDot > indexExponent;
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

        static bool IsNotValidDotOrExponent(string input, char c, int index)
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

            return input[0] != '0' || input[1] == '.';
        }
    }
}
