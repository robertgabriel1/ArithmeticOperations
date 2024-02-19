using System;
namespace arithmetic
{
   public class Program
    {
      public static void Main()
       {
        int firstNumberToAdd = int.Parse(Console.ReadLine());
        int secondNumberToAdd = int.Parse(Console.ReadLine());
        Console.WriteLine(AddNumbers(firstNumberToAdd, secondNumberToAdd));
        Console.WriteLine(MultiplyNumbers(firstNumberToAdd, secondNumberToAdd));
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

