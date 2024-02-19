using System;
namespace arithmetic
{
   public class Program
    {
      public static void Main()
       {
        int first = int.Parse(Console.ReadLine());
        int secondNumberToAdd = int.Parse(Console.ReadLine());
        Console.WriteLine(AddNumbers(first, secondNumberToAdd));
        Console.WriteLine(MultiplyNumbers(first, secondNumberToAdd));
        }

      public static int AddNumbers(int firstNumber, int secondNumber)
       { 
        return firstNumber + secondNumber;
       }

       public static int MultiplyNumbers(int firstNumber, int secondNumber)
       {
        return firstNumber * secondNumber;
       }
    }
}

