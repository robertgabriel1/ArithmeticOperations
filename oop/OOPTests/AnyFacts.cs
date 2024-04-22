using OOP;

namespace OOPTests
{
    public class AnyFacts
    {
        [Fact]
        public void Match_Should_ReturnTrue_WhenTheFirstCharacterIsInString ()
        {
            var e = new Any("eE");
            Assert.True(e.Match("ea").Success());
            Assert.True(e.Match("Ea").Success());
        }


        [Fact]
        public void Match_Should_ReturnFalse_WhenTheFirstCharacterIsNotInString()
        {
            var e = new Any("eE");
            Assert.False(e.Match("a").Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenACharacterOtherThanTheFirstIsInString ()
        {
            var e = new Any("eE");
            Assert.False(e.Match("ae").Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenValueIsEmptyOrNull()
        {
            var e = new Any("eE");
            Assert.False(e.Match("").Success());
            Assert.False(e.Match(null).Success());
        }

        [Fact]
        public void Match_Should_ReturnTrue_WhenTheFirstCharacterMatchesTheString ()
        {
            var sign = new Any("-+");
            Assert.True(sign.Match("+3").Success());
            Assert.True(sign.Match("-2").Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTheFirstCharacterDoesNotMatchesTheString()
        {
            var sign = new Any("-+");
            Assert.False(sign.Match("2").Success());
        }
    }
}