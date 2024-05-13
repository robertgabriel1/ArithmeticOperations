using OOP;
namespace OOPTests
{
    public class ChoiceFacts
    {
        [Fact]
        public void Match_Should_WithSomePatterns_WhenDigitFitsCharacterOrRangePattern()
        {
            var digit = new Choice(
            new Character('0'),
            new OOP.Range('1', '9')
            );

            Assert.True(digit.Match("012").Success());
            Assert.True(digit.Match("12").Success());
            Assert.True(digit.Match("92").Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenDigitDoesNotMatchCharacterOrRange()
        {
            var digit = new Choice(
            new Character('0'),
            new OOP.Range('1', '9')
            );
            Assert.False(digit.Match("a9").Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenDigitIsNullOrEmpty()
        {
            var digit = new Choice(
            new Character('0'),
            new OOP.Range('1', '9')
            );
            Assert.False(digit.Match("").Success());
            Assert.False(digit.Match(null).Success());
        }

        [Fact]
        public void Match_Should_ReturnTrue_WhenHexFitsCharacterOrRangePattern()
        {
            var digit = new Choice(
                  new Character('0'),
                  new OOP.Range('1', '9')
                  );

            var hex = new Choice(
                digit,
                new Choice(
                    new OOP.Range('a', 'f'),
                    new OOP.Range('A', 'F')
                )
            );

            Assert.True(hex.Match("012").Success());
            Assert.True(hex.Match("12").Success());
            Assert.True(hex.Match("92").Success());
            Assert.True(hex.Match("a9").Success());
            Assert.True(hex.Match("f8").Success());
            Assert.True(hex.Match("A9").Success());
            Assert.True(hex.Match("F8").Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenHexDoesNotMatchCharacterOrRange()
        {
            var digit = new Choice(
              new Character('0'),
              new OOP.Range('1', '9')
              );

            var hex = new Choice(
                digit,
                new Choice(
                    new OOP.Range('a', 'f'),
                    new OOP.Range('A', 'F')
                )
            );
            Assert.False(hex.Match("g8").Success());
            Assert.False(hex.Match("G8").Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenHexIsNullOrEmpty()
        {
            var digit = new Choice(
              new Character('0'),
              new OOP.Range('1', '9')
              );

            var hex = new Choice(
                digit,
                new Choice(
                    new OOP.Range('a', 'f'),
                    new OOP.Range('A', 'F')
                )
            );
            Assert.False(hex.Match("").Success());
            Assert.False(hex.Match(null).Success());
        }

        [Fact]
        public void Add_ShouldAddNewPattern()
        {
            var value = new Choice(new OOP.Range('1','2'));
            Assert.False(value.Match("3").Success());
            value.Add(new OOP.Range('3', '4'));
            Assert.True(value.Match("3").Success());
        }
    }
}