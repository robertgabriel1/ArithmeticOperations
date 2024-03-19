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

            input = input.Trim();
            string number = IsNegativeNumber(input) ? input.Substring(1) : input;
            return ContainsValidCharacters(number);
        }

        static bool ContainsValidCharacters(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                switch (currentChar)
                {
                    case char c when char.IsDigit(c):
                        if (HasLeadingZeroWithoutDecimal(input, i, currentChar))
                        {
                            return false;
                        }

                        break;
                    case char c when IsDot(c):
                        if (!IsValidFraction(input, i))
                        {
                            return false;
                        }

                        break;
                    case char c when IsExponentOrSign(c):
                        if (!IsValidExponent(input, i, currentChar))
                        {
                            return false;
                        }

                        break;
                    default:
                        return false;
                }
            }

            return true;
        }

        static bool IsExponentOrSign(char currentChar)
        {
            return IsExponent(currentChar) || IsSign(currentChar);
        }

        static bool IsValidFraction(string input, int index)
        {
            int numberOfDots = CountElements(input, '.');
            return !IsFirstOrLastIndex(input, index) && numberOfDots <= 1;
        }

        static bool IsValidExponent(string input, int index, char currentChar)
        {
            int numberOfSigns = CountElements(input, '+') + CountElements(input, '-');
            int numberOfExponents = CountElements(input, 'e') + CountElements(input, 'E');
            if (IsFirstOrLastIndex(input, index) || numberOfExponents > 1 || numberOfSigns > 1)
            {
                return false;
            }
            else if (IsSign(currentChar) && !IsExponent(input[index - 1]))
            {
                return false;
            }
            else if (IsExponent(currentChar) && !IsDotBeforeExponent(input))
            {
                return false;
            }

            return true;
        }

        static bool HasLeadingZeroWithoutDecimal(string input, int index, char currentChar)
        {
            return currentChar == '0' && input.Length > 1 && index == 0 && !IsDot(input[1]);
        }

        static bool IsDotBeforeExponent(string input)
        {
            bool result = true;
            int indexDot = -1;
            int indexExponent = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if (IsDot(input[i]))
                {
                    indexDot = i;
                }

                if (IsExponent(input[i]))
                {
                    indexExponent = i;
                }

                if (indexDot != -1 && indexExponent != -1 && indexDot > indexExponent)
                {
                        result = false;
                }
            }

            return result;
        }

        static int CountElements(string input, char targetCharacter)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar == targetCharacter)
                {
                    count++;
                }
            }

            return count;
        }

        static bool IsSign(char c)
        {
            return c == '+' || c == '-';
        }

        static bool IsExponent(char c)
        {
            return c == 'e' || c == 'E';
        }

        static bool IsDot(char c)
        {
            return c == '.';
        }

        static bool IsFirstOrLastIndex(string input, int index)
        {
            return index == 0 || index == input.Length - 1;
        }

        static bool IsNegativeNumber(string input)
        {
            bool isNegative = false;
            if (input.Length > 1)
            {
                isNegative = input[0] == '-';
            }

            return isNegative;
        }
    }
}
