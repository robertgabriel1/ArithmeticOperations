using OOP;

namespace OOPTests
{
    public class TextFacts
    {
        [Fact]
        public void Match_Should_ReturnTrue_WhenTextStartsWithPrefix()
        {
            var test1 = new Text("true");
            Assert.True(test1.Match(new StringView("true", 0)).Success());
            Assert.True(test1.Match(new StringView("trueX", 0)).Success());
            Assert.True(test1.Match(new StringView("trueX", 0)).RemainingText().StartsWith("X"));
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextDoesNotStartsWithPrefix()
        {
            var test1 = new Text("true");
            Assert.False(test1.Match(new StringView("false", 0)).Success());
            Assert.False(test1.Match(new StringView("trur", 0)).Success());
            Assert.True(test1.Match(new StringView("false", 0)).RemainingText().StartsWith("false"));
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextContainsButNotStartsWithPrefix()
        {
            var test1 = new Text("true");
            Assert.False(test1.Match(new StringView("xtrue", 0)).Success());
            Assert.True(test1.Match(new StringView("xtrue", 0)).RemainingText().StartsWith("xtrue"));
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextIsNullOrEmpty()
        {
            var test1 = new Text("true");
            Assert.False(test1.Match(new StringView("", 0)).Success());
            Assert.False(test1.Match(new StringView(null, 0)).Success());
            Assert.True(test1.Match(new StringView("", 0)).RemainingText().StartsWith(""));
            Assert.True(test1.Match(new StringView(null, 0)).RemainingText().StartsWith(null));
        }

        [Fact]
        public void Match_Should_ReturnTrue_WhenPrefixMatchesAnythingButNull()
        {
            var empty = new Text("");
            Assert.True(empty.Match(new StringView("true", 0)).Success());
            Assert.True(empty.Match(new StringView("false", 0)).Success());
            Assert.False(empty.Match(new StringView(null, 0)).Success());
            Assert.True(empty.Match(new StringView("true", 0)).RemainingText().StartsWith("true"));
            Assert.True(empty.Match(new StringView("false", 0)).RemainingText().StartsWith("false"));
            Assert.True(empty.Match(new StringView(null, 0)).RemainingText().StartsWith(null));
        }
    }
}
