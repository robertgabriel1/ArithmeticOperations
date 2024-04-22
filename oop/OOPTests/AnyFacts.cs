using OOP;

namespace OOPTests
{
    public class AnyFacts
    {
        [Fact]
        public void Match_Should_ReturnTrue_WhenStartingCharacterIsValid()
        {
            var e = new Any("eE");
            Assert.True(e.Match("ea").Success());
            Assert.True(e.Match("Ea").Success());
        }
        [Fact]
        public void Match_Should_ReturnFalse_WhenStartingCharacterIsNotValid()
        {
            var e = new Any("eE");
            Assert.False(e.Match("a").Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenValueIsEmptyOrNull()
        {
            var e = new Any("eE");
            Assert.False(e.Match("").Success());
            Assert.False(e.Match(null).Success());
        }
    }
}