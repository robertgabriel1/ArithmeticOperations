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
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextDoesNotStartsWithPrefix()
        {
            var test1 = new Text("true");
            Assert.False(test1.Match("false").Success());
            Assert.False(test1.Match("trur").Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextContainsButNotStartsWithPrefix()
        {
            var test1 = new Text("true");
            Assert.False(test1.Match("xtrue").Success());
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextIsNullOrEmpty()
        {
            var test1 = new Text("true");
            Assert.False(test1.Match("").Success());
            Assert.False(test1.Match(null).Success());
        }

        [Fact]
        public void Match_Should_ReturnTrue_WhenPrefixMatchesAnythingButNull()
        {
            var empty = new Text("");
            Assert.True(empty.Match("true").Success());
            Assert.True(empty.Match("false").Success());
            Assert.False(empty.Match(null).Success());
        }
    }
}
