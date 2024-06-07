using OOP;

namespace OOPTests
{
    public class OptionalFacts
    {
        [Fact]
        public void Match_Should_RemoveSimilarPattern_WhenTextStartsWithPattern()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match(new StringView("abc", 0)).Success());
            Assert.True(a.Match(new StringView("asdfg", 0)).Success());
            Assert.Equal(new StringView("bc", 0), a.Match(new StringView("abc", 0)).RemainingText());
        }

        [Fact]
        public void Match_Should_RemoveSimilarPattern_WhenAreSeveralMatches()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match(new StringView("aabc", 0)).Success());
            Assert.Equal(new StringView("abc", 0), a.Match(new StringView("aabc", 0)).RemainingText());
        }

        [Fact]
        public void Match_Should_RemainTheSame_WhenThereIsNoMatch()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match(new StringView("bc", 0)).Success());
            Assert.Equal(new StringView("bc", 0), a.Match(new StringView("bc", 0)).RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnTrue_WhenIsEmptyOrNull()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match(new StringView("", 0)).Success()); 
            Assert.True(a.Match(new StringView(null, 0)).Success());
        }

        [Fact]
        public void Match_Should_RemoveSimilarPattern_OtherThanLetters()
        {
            var sign = new Optional(new Character('-'));
            Assert.True(sign.Match(new StringView("123", 0)).Success());
            Assert.True(sign.Match(new StringView("-123", 0)).Success());
        }

        [Fact]
        public void Match_Should_RemoveSimilarPattern_UsingARange()
        {
            var sign = new Optional(new OOP.Range('a', 'c'));
            Assert.True(sign.Match(new StringView("bcd", 0)).Success());
            Assert.Equal(new StringView("cd", 0), sign.Match(new StringView("bcd", 0)).RemainingText());
            Assert.True(sign.Match(new StringView("-123", 0)).Success());
            Assert.Equal(new StringView("-123", 0), sign.Match(new StringView("-123", 0)).RemainingText());
        }
    }
}
