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
            return IsValidIntegerPart(ExtractIntegerPart(input)) &&
                   IsValidFractionalPart(ExtractFractionalPart(input)) &&
                   IsValidExponentPart(ExtractExponentPart(input));
        }

        static string ExtractIntegerPart(string input)
        {
            int dotIndex = input.IndexOf('.');
            int exponentIndex = input.IndexOfAny(new[] { 'e', 'E' });
            if (dotIndex == -1 && exponentIndex == -1)
            {
                return input;
            }

            return dotIndex != -1 ? input[..dotIndex] : input[..exponentIndex];
        }

        static string ExtractFractionalPart(string input)
        {
            int dotIndex = input.IndexOf('.');
            int exponentIndex = input.IndexOfAny(new[] { 'e', 'E' });

            if (dotIndex != -1)
            {
                return exponentIndex != -1 && exponentIndex > dotIndex ? input[dotIndex..exponentIndex] : input[dotIndex..];
            }

            return string.Empty;
        }

        static string ExtractExponentPart(string input)
        {
            int exponentIndex = input.IndexOfAny(new[] { 'e', 'E' });
            if (exponentIndex != -1)
            {
                return input[exponentIndex..];
            }

            return string.Empty;
        }

        static bool IsValidIntegerPart(string input)
        {
            input = input.StartsWith('-') ? input[1..] : input;
            if (input.Length > 1 && input[0] == '0')
            {
                return false;
            }

            return IsValidDigits(input);
        }

        static bool IsValidFractionalPart(string input)
        {
            return string.IsNullOrEmpty(input) || IsValidDigits(input[1..]);
        }

        static bool IsValidExponentPart(string input)
        {
          if (string.IsNullOrEmpty(input))
            {
                return true;
            }

          input = input[1..];
          if (input.StartsWith('-') || input.StartsWith('+'))
            {
                input = input[1..];
            }

          return IsValidDigits(input);
        }

        static bool IsValidDigits(string input)
        {
           foreach (char c in input)
           {
              if (!char.IsDigit(c))
              {
                return false;
              }
           }

           return input.Length > 0;
        }
    }
}