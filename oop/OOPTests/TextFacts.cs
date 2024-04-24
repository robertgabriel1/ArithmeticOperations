using OOP;

namespace OOPTests
{
    public class TextFacts
    {
        [Fact]
        public void Match_Should_ReturnTrue_WhenTextStartsWithPrefix()
        {
            var test1 = new Text("true");
            Assert.True(test1.Match("true").Success());
            Assert.True(test1.Match("trueX").Success());
            Assert.Equal("X", test1.Match("trueX").RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextDoesNotStartsWithPrefix()
        {
            var test1 = new Text("true");
            Assert.False(test1.Match("false").Success());
            Assert.False(test1.Match("trur").Success());
            Assert.Equal("false", test1.Match("false").RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextContainsButNotStartsWithPrefix()
        {
            var test1 = new Text("true");
            Assert.False(test1.Match("xtrue").Success());
            Assert.Equal("xtrue", test1.Match("xtrue").RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextIsNullOrEmpty()
        {
            var test1 = new Text("true");
            Assert.False(test1.Match("").Success());
            Assert.False(test1.Match(null).Success());
            Assert.Equal("", test1.Match("").RemainingText());
            Assert.Equal(null, test1.Match(null).RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnTrue_WhenPrefixMatchesAnythingButNull()
        {
            var empty = new Text("");
            Assert.True(empty.Match("true").Success());
            Assert.True(empty.Match("false").Success());
            Assert.False(empty.Match(null).Success());
            Assert.Equal("true", empty.Match("true").RemainingText());
            Assert.Equal("false", empty.Match("false").RemainingText());
            Assert.Equal(null, empty.Match(null).RemainingText());
        }
    }
}
