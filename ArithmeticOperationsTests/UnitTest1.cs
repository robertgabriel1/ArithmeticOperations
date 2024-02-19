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
            int expectedSum = 8;
            int result = Program.AddNumbers(firstNumber, secondNumber);
            Assert.Equal(expectedSum, result);
        }
    }
}