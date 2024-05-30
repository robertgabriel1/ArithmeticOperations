using OOP;

namespace OOPTests
{
    public class StringViewFacts
    {
        [Fact]
        public void Peek_ShouldReturnFirstCharacter_WhenStringIsNotEmpty()
        {
            var stringView = new StringView("hello", 0);
            Assert.Equal('h', stringView.Peek());
        }

        [Fact]
        public void Peek_ShouldReturnZero_WhenStringIsEmpty()
        {
            var stringView = new StringView("", 0);
            Assert.Equal('0', stringView.Peek());
        }

        [Fact]
        public void IsEmpty_ShouldReturnTrue_WhenStringIsEmpty()
        {
            var stringView = new StringView("", 0);
            Assert.True(stringView.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ShouldReturnFalse_WhenStringIsNotEmpty()
        {
            var stringView = new StringView("hello", 0);
            Assert.False(stringView.IsEmpty());
        }

        [Fact]
        public void Advance_ShouldIncreasesIndexByOne_Default()
        {
            var stringView = new StringView("hello", 0);
            var advancedView = stringView.Advance();
            Assert.Equal('e', advancedView.Peek());
        }

        [Fact]
        public void Advance_ShouldIncreasesIndexBySpecifiedCount()
        {
            var stringView = new StringView("hello", 0);
            var advancedView = stringView.Advance(2);
            Assert.Equal('l', advancedView.Peek());
        }

        [Fact]
        public void StartsWith_ShouldReturnsTrue_WhenPrefixMatches()
        {
            var stringView = new StringView("hello", 0);
            Assert.True(stringView.StartsWith("he"));
        }

        [Fact]
        public void StartsWith_ShouldReturnsFalse_WhenPrefixDoesNotMatch()
        {
            var stringView = new StringView("hello", 0);
            Assert.False(stringView.StartsWith("ha"));
        }

        [Fact]
        public void StartsWith_ShouldReturnsFalse_WhenPrefixIsLongerThanText()
        {
            var stringView = new StringView("hello", 0);
            Assert.False(stringView.StartsWith("hellow"));
        }
    }
}