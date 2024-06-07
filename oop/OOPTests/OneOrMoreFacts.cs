using OOP;

namespace OOPTests
{
    public class OneOrMoreFacts
    {
        [Fact]
        public void Match_Should_RemoveSimilarPattern_WhenTextStartsWithPattern()
        {
            var a = new OneOrMore(new OOP.Range('0', '9'));
            Assert.True(a.Match(new StringView("123" ,0)).Success());
            Assert.Equal(new StringView("", 0), a.Match(new StringView("123", 0)).RemainingText());
            Assert.True(a.Match(new StringView("1a", 0)).Success());
            Assert.Equal(new StringView("a", 0), a.Match(new StringView("1a", 0)).RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextDoesNotStartsWithPattern()
        {
            var a = new OneOrMore(new OOP.Range('0', '9'));
            Assert.False(a.Match(new StringView("bc", 0)).Success());
            Assert.Equal(new StringView("bc", 0), a.Match(new StringView("bc", 0)).RemainingText());
        }


        [Fact]
        public void Match_Should_ReturnFalse_EmptyOrNull()
        {
            var a = new OneOrMore(new OOP.Range('0', '9'));
            Assert.False(a.Match(new StringView("", 0)).Success());
            Assert.Equal(new StringView("", 0), a.Match(new StringView("", 0)).RemainingText());
            Assert.False(a.Match(new StringView(null, 0)).Success());
            Assert.Equal(new StringView(null, 0), a.Match(new StringView(null, 0)).RemainingText());
        }
    }
}
