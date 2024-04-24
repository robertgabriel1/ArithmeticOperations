using OOP;

namespace OOPTests
{
    public class OneOrMoreFacts
    {
        [Fact]
        public void Match_Should_RemoveSimilarPattern_WhenTextStartsWithPattern()
        {
            var a = new OneOrMore(new OOP.Range('0', '9'));
            Assert.True(a.Match("123").Success());
            Assert.Equal("", a.Match("123").RemainingText());
            Assert.True(a.Match("1a").Success());
            Assert.Equal("a", a.Match("1a").RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextDoesNotStartsWithPattern()
        {
            var a = new OneOrMore(new OOP.Range('0', '9'));
            Assert.False(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }


        [Fact]
        public void Match_Should_ReturnFalse_EmptyOrNull()
        {
            var a = new OneOrMore(new OOP.Range('0', '9'));
            Assert.False(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
            Assert.False(a.Match(null).Success());
            Assert.Equal(null, a.Match(null).RemainingText());
        }
    }
}
