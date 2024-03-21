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
          string number = input.StartsWith('-') ? input[1..] : input;
          return IsValidIntegerPart(ExtractIntegerPart(number)) &&
                 IsValidFractionalPart(ExtractFractionalPart(number)) &&
                 IsValidExponentPart(ExtractExponentPart(number));
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
          return dotIndex != -1 ? input[dotIndex..] : string.Empty;
       }

       static string ExtractExponentPart(string input)
       {
          int exponentIndex = input.IndexOfAny(new[] { 'e', 'E' });
          int exponentSignIndex = input.IndexOfAny(new[] { '+', '-' });
          if (exponentIndex != -1 && exponentSignIndex == -1)
            {
                return input[exponentIndex..];
            }
          else if (exponentIndex != -1 && exponentSignIndex != -1)
            {
                return input[exponentSignIndex..];
            }

          return string.Empty;
       }

       static bool IsValidIntegerPart(string input)
       {
            if (input.Length > 1 && input[0] == '0')
            {
                return false;
            }

            return IsValidDigits(input);
       }

       static bool IsValidFractionalPart(string input)
       {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            if (input.Length > 1 && (input[1] == 'e' || input[1] == 'E'))
            {
                return false;
            }

            int exponentIndex = input.IndexOfAny(new[] { 'e', 'E' });
            int exponentSignIndex = input.IndexOfAny(new[] { '-', '+' });
            if (exponentIndex != -1)
            {
                string nonExponentialPart = input[..exponentIndex];
                nonExponentialPart += exponentSignIndex != -1 ? input[(exponentSignIndex + 1) ..] : input[(exponentIndex + 1) ..];
                return IsValidDigits(nonExponentialPart[1..]);
            }

            return IsValidDigits(input[1..]);
        }

       static bool IsValidExponentPart(string input)
       {
          if (input.Length > 2)
            {
                return false;
            }

          return string.IsNullOrEmpty(input) || IsValidDigits(input[1..]);
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