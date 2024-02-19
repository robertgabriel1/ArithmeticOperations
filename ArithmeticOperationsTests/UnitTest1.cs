using arithmetic;

namespace ArithmeticOperationsTests
{
    public class UnitTest1
    {
        [Fact]
        public void AddNumbers_ReturnsCorrectSum()
        {
            int firstNumber = 3;
            int secondNumber = 4;
            int expectedSum = 7;
            int result = Program.AddNumbers(firstNumber, secondNumber);
            Assert.Equal(expectedSum, result);
        }

        [Fact]
        public void MultiplyNumbers_ReturnCorrectResult()
        {
            int firstNumber = 3;
            int secondNumber = 4;
            int expected = 12;
            int result = Program.MultiplyNumbers(firstNumber, secondNumber);
            Assert.Equal(expected, result);
        }
    }
}