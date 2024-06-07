using OOP;

namespace OOPTests
{
    public class AnyFacts
    {
        [Fact]
        public void Match_Should_ReturnTrue_WhenTheFirstCharacterIsInString ()
        {
            var e = new Any("eE");
            Assert.True(e.Match(new StringView("ea", 0)).Success());
            Assert.True(e.Match(new StringView("Ea", 0)).Success());
        }


        [Fact]
        public void Match_Should_ReturnFalse_WhenTheFirstCharacterIsNotInString()
        {
            var e = new Any("eE");
            Assert.False(e.Match(new StringView("a", 0)).Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenACharacterOtherThanTheFirstIsInString ()
        {
            var e = new Any("eE");
            Assert.False(e.Match(new StringView("ae", 0)).Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenValueIsEmptyOrNull()
        {
            var e = new Any("eE");
            Assert.False(e.Match(new StringView("", 0)).Success());
            Assert.False(e.Match(new StringView(null, 0)).Success());
        }

        [Fact]
        public void Match_Should_ReturnTrue_WhenTheFirstCharacterMatchesTheString ()
        {
            var sign = new Any("-+");
            Assert.True(sign.Match(new StringView("+3", 0)).Success());
            Assert.True(sign.Match(new StringView("-2", 0)).Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTheFirstCharacterDoesNotMatchesTheString()
        {
            var sign = new Any("-+");
            Assert.False(sign.Match(new StringView("2", 0)).Success());
        }
    }
}