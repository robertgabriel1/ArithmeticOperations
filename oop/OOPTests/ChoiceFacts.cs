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

            Assert.True(digit.Match(new StringView("012", 0)).Success());
            Assert.True(digit.Match(new StringView("12", 0)).Success());
            Assert.True(digit.Match(new StringView("92", 0)).Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenDigitDoesNotMatchCharacterOrRange()
        {
            var digit = new Choice(
            new Character('0'),
            new OOP.Range('1', '9')
            );
            Assert.False(digit.Match(new StringView("a9", 0)).Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenDigitIsNullOrEmpty()
        {
            var digit = new Choice(
            new Character('0'),
            new OOP.Range('1', '9')
            );
            Assert.False(digit.Match(new StringView("", 0)).Success());
            Assert.False(digit.Match(new StringView(null, 0)).Success());
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

            Assert.True(hex.Match(new StringView("012", 0)).Success());
            Assert.True(hex.Match(new StringView("12", 0)).Success());
            Assert.True(hex.Match(new StringView("92", 0)).Success());
            Assert.True(hex.Match(new StringView("a9", 0)).Success());
            Assert.True(hex.Match(new StringView("f8", 0)).Success());
            Assert.True(hex.Match(new StringView("A9", 0)).Success());
            Assert.True(hex.Match(new StringView("F8", 0)).Success());
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
            Assert.False(hex.Match(new StringView("g8", 0)).Success());
            Assert.False(hex.Match(new StringView("G8", 0)).Success());
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
            Assert.False(hex.Match(new StringView("", 0)).Success());
            Assert.False(hex.Match(new StringView(null, 0)).Success());
        }

        [Fact]
        public void Add_ShouldAddNewPattern()
        {
            var value = new Choice(new OOP.Range('1','2'));
            Assert.False(value.Match(new StringView("3", 0)).Success());
            value.Add(new OOP.Range('3', '4'));
            Assert.True(value.Match(new StringView("3", 0)).Success());
        }
    }
}