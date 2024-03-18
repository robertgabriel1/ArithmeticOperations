using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (!StartsAndEndsWithDoubleQuote(input))
            {
                return false;
            }

            int step = 1;
            for (int i = 0; i < input.Length - 1; i += step)
            {
                step = 1;
                char currentChar = input[i];
                char nextChar = input[i + 1];
                int lastCharacterIndex = input.Length - 2;
                if (currentChar == '\\' && (i == lastCharacterIndex || !CanHandleEscapeSequence(input, i, ref step)))
                {
                    return false;
                }

                if (IsControlCharacter(currentChar))
                {
                    return false;
                }
            }

            return true;
        }

        static bool StartsAndEndsWithDoubleQuote(string input)
        {
            return input.Length >= 2 && input[0] == '"' && input[^1] == '"';
        }

        static bool CanHandleEscapeSequence(string input, int index, ref int step)
        {
            int nextCharIndex = index + 1;
            char charToCheck = input[nextCharIndex];
            const int charsToSkipIfIsUnicode = 4;
            if (charToCheck == 'u' && IsValidUnicodeSequence(input, nextCharIndex))
            {
                step += charsToSkipIfIsUnicode;
                return true;
            }
            else if (IsCharacterEscape(charToCheck))
            {
                step++;
                return true;
            }

            return false;
        }

        static bool IsCharacterEscape(char c)
        {
            const string escapeCharacters = "fnr/bt\\\"";
            return escapeCharacters.Contains(c);
        }

        static bool IsValidUnicodeSequence(string input, int nextCharIndex)
        {
            const int unicodeCharactersToCheck = 5;
            for (int j = 1; j < unicodeCharactersToCheck; j++)
            {
                char hexChar = input[nextCharIndex + j];
                if (!IsValidHex(hexChar))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsValidHex(char hexChar)
        {
            return char.IsDigit(hexChar) || IsHexLetter(hexChar);
        }

        static bool IsHexLetter(char hexChar)
        {
            return char.ToUpper(hexChar) >= 'A' && char.ToUpper(hexChar) <= 'F';
        }

        static bool IsControlCharacter(char c)
        {
            return c < ' ';
        }
    }
}
