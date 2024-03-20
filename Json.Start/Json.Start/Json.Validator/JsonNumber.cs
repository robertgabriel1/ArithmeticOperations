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
          if (!char.IsDigit(number[0]) || !char.IsDigit(number[^1]))
            {
                return false;
            }

          string integerPart = ExtractIntegerPart(number);
          string fractionalPart = ExtractFractionalPart(number);
          string exponentPart = ExtractExponentPart(number);

          return IsValidIntegerPart(integerPart) &&
                 IsValidFractionalPart(fractionalPart) &&
                 IsValidExponentPart(exponentPart);
       }

       static string ExtractIntegerPart(string input)
        {
            int dotIndex = input.IndexOf('.');
            int exponentIndex = input.IndexOfAny(new[] { 'e', 'E' });
            if (dotIndex == -1 && exponentIndex == -1)
            {
                return input;
            }

            return dotIndex != -1 ? input.Substring(0, dotIndex) : input.Substring(0, exponentIndex);
        }

       static string ExtractFractionalPart(string input)
       {
          int dotIndex = input.IndexOf('.');
          return dotIndex != -1 ? input.Substring(dotIndex) : string.Empty;
       }

       static string ExtractExponentPart(string input)
       {
          int exponentIndex = input.IndexOfAny(new[] { 'e', 'E' });
          int exponentSignIndex = input.IndexOfAny(new[] { '+', '-' });
          if (exponentIndex != -1 && exponentSignIndex == -1)
            {
                return input.Substring(exponentIndex);
            }
          else if (exponentIndex != -1 && exponentSignIndex != -1)
            {
                return input.Substring(exponentSignIndex);
            }

          return string.Empty;
       }

       static bool IsValidIntegerPart(string input)
       {
            if (input.Length > 1 && input[0] == '0' && input[1] != '.')
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

            if (input[1] == 'e' || input[1] == 'E')
            {
                return false;
            }

            int exponentIndex = input.IndexOfAny(new[] { 'e', 'E' });
            int exponentSignIndex = input.IndexOfAny(new[] { '-', '+' });
            if (exponentIndex != -1)
            {
                string nonExponentialPart = input.Substring(0, exponentIndex);
                nonExponentialPart += exponentSignIndex != -1 ? input.Substring(exponentSignIndex + 1) : input.Substring(exponentIndex + 1);
                return IsValidDigits(nonExponentialPart.Substring(1));
            }

            return IsValidDigits(input.Substring(1));
        }

       static bool IsValidExponentPart(string input)
       {
          return string.IsNullOrEmpty(input) || IsValidDigits(input.Substring(1));
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

          return true;
       }

       static bool IsNegativeNumber(string input)
       {
           return input.Length > 1 && input[0] == '-';
       }
    }
}