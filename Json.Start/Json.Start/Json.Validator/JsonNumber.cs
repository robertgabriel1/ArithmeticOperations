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
            bool isNegative = false;
            if (input.Length > 1)
            {
                isNegative = IsSign(input[0]);
            }

            string number = isNegative ? input.Substring(1) : input;
            return ContainsValidCharacters(number) && ValidZeroFirstDigit(input);
        }

        static bool ContainsValidCharacters(string input)
        {
            int countDots = CountElements(input, '.');
            int countExponents = CountElements(input, 'e') + CountElements(input, 'E');
            int countSigns = CountElements(input, '+') + CountElements(input, '-');
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (IsDotOrExponentAtEdge(input, currentChar, i))
                {
                    return false;
                }
                else if (!IsValidExponentSign(input, currentChar, i))
                {
                    return false;
                }
                else if (IsSpecialCharacter(currentChar) && !IsEnclosedInSquareBrackets(input))
                {
                    return false;
                }
                else if (!ExponentIsBeforeDot(input))
                {
                    return false;
                }
            }

            return IsValidArray(input, countDots, countExponents, countSigns);
        }

        static bool ExponentIsBeforeDot(string input)
        {
            bool result = true;
            int indexDot = -1;
            int indexExponent = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '.')
                {
                    indexDot = i;
                }

                if (input[i] == 'e')
                {
                    indexExponent = i;
                }

                if (indexDot != -1 && indexExponent != -1)
                {
                    if (indexDot > indexExponent)
                    {
                        result = false;
                    }

                    indexDot = -1;
                    indexExponent = -1;
                }
            }

            return result;
        }

        static bool IsSpecialCharacter(char c)
        {
            return !char.IsDigit(c) && !IsExponent(c) && c != '.' && !IsSign(c);
        }

        static bool IsEnclosedInSquareBrackets(string input)
        {
            return input[0] == '[' && input[input.Length - 1] == ']';
        }

        static bool IsValidArray(string input, int countDots, int countExponents, int countSigns)
        {
            int countCommas = 0;
            foreach (char c in input)
            {
                if (c == ',')
                {
                    countCommas++;
                }
            }

            bool isValid = IsEnclosedInSquareBrackets(input);
            int maxAllowed = countCommas + 1;
            bool isValidLimit = countDots <= maxAllowed && countExponents <= maxAllowed && countSigns <= maxAllowed;
            bool isValidSingle = countDots <= 1 && countExponents <= 1 && countSigns <= 1;
            return isValid ? isValidLimit : isValidSingle;
        }

        static int CountElements(string input, char targetCharacter)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (NegativeArrayElement(input, i, currentChar))
                {
                    count += 0;
                }
                else if (currentChar == targetCharacter)
                {
                    count++;
                }
            }

            return count;
        }

        static bool IsValidExponentSign(string input, char currentChar, int index)
        {
            if (!IsSign(currentChar))
            {
                return true;
            }

            if (IsSign(currentChar) && NegativeArrayElement(input, index, currentChar))
            {
                return true;
            }

            return input.Length > 1 && IsExponent(input[index - 1]) && !IsFirstOrLastIndex(input, index);
        }

        static bool NegativeArrayElement(string input, int index, char currentChar)
        {
            return IsFirstElementNegative(input, index, currentChar) || IsNegativeElementAfterComma(input, index, currentChar);
        }

        static bool IsFirstElementNegative(string input, int index, char currentChar)
        {
            return index >= 1 && currentChar == '-' && input[index - 1] == '[';
        }

        static bool IsNegativeElementAfterComma(string input, int index, char currentChar)
        {
            const int twoCharsBefore = 2;
            return index > 1 && currentChar == '-' && input[index - twoCharsBefore] == ',';
        }

        static bool IsDotOrExponentAtEdge(string input, char c, int index)
        {
            return (c == '.' || IsExponent(c)) && IsFirstOrLastIndex(input, index);
        }

        static bool IsSign(char c)
        {
            return c == '+' || c == '-';
        }

        static bool IsExponent(char c)
        {
            return c == 'e' || c == 'E';
        }

        static bool IsFirstOrLastIndex(string input, int index)
        {
            return index == 0 || index == input.Length - 1;
        }

        static bool ValidZeroFirstDigit(string input)
        {
            bool result = true;
            if (input.Length > 1 && input[0] == '0' && input[1] != '.')
            {
                result = false;
            }

            return result;
        }
    }
}
