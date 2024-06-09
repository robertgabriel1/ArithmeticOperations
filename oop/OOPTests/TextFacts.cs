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
            Assert.True(new StringView("trueX", 5).CheckRemainingString(test1.Match(new StringView("trueX", 0)).RemainingText()));
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextDoesNotStartsWithPrefix()
        {
            var test1 = new Text("true");
            Assert.False(test1.Match(new StringView("false", 0)).Success());
            Assert.False(test1.Match(new StringView("trur", 0)).Success());
            Assert.False(new StringView("true", 5).CheckRemainingString(test1.Match(new StringView("false", 0)).RemainingText()));
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextContainsButNotStartsWithPrefix()
        {
            var test1 = new Text("true");
            Assert.False(test1.Match(new StringView("xtrue", 0)).Success());
            Assert.True(new StringView("xtrue", 5).CheckRemainingString(test1.Match(new StringView("xtrue", 0)).RemainingText()));
        }

        [Fact]
        public void Match_Should_ReturnFalse_WhenTextIsNullOrEmpty()
        {
            var test1 = new Text("true");
            Assert.False(test1.Match(new StringView("", 0)).Success());
            Assert.False(test1.Match(new StringView(null, 0)).Success());
            Assert.True(new StringView("", 0).CheckRemainingString(test1.Match(new StringView("", 0)).RemainingText()));
            Assert.True(new StringView(null, 0).CheckRemainingString(test1.Match(new StringView(null, 0)).RemainingText()));
        }

        [Fact]
        public void Match_Should_ReturnTrue_WhenPrefixMatchesAnythingButNull()
        {
            var empty = new Text("");
            Assert.True(empty.Match(new StringView("true", 0)).Success());
            Assert.True(empty.Match(new StringView("false", 0)).Success());
            Assert.False(empty.Match(new StringView(null, 0)).Success());
            Assert.True(new StringView("true", 4).CheckRemainingString(empty.Match(new StringView("true", 0)).RemainingText()));
            Assert.True(new StringView("false", 5).CheckRemainingString(empty.Match(new StringView("false", 0)).RemainingText()));
            Assert.True(new StringView(null, 0).CheckRemainingString(empty.Match(new StringView(null, 0)).RemainingText()));
        }
    }
}
