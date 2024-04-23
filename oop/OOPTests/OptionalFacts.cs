using OOP;

namespace OOPTests
{
    public class OptionalFacts
    {
        [Fact]
        public void Match_Should_RemoveSimilarPattern_WhenTextStartsWithPattern()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("abc").Success());
            Assert.True(a.Match("asdfg").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void Match_Should_RemoveSimilarPattern_WhenAreSeveralMatches()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("aabc").Success());
            Assert.Equal("abc", a.Match("aabc").RemainingText());
        }

        [Fact]
        public void Match_Should_RemainTheSame_WhenThereIsNoMatch()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnTrue_WhenIsEmptyOrNull()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("").Success()); 
            Assert.True(a.Match(null).Success());
        }

        [Fact]
        public void Match_Should_RemoveSimilarPattern_OtherThanLetters()
        {
            var sign = new Optional(new Character('-'));
            Assert.True(sign.Match("123").Success());
            Assert.True(sign.Match("-123").Success());
        }

        [Fact]
        public void Match_Should_RemoveSimilarPattern_UsingARange()
        {
            var sign = new Optional(new OOP.Range('a', 'c'));
            Assert.True(sign.Match("bcd").Success());
            Assert.Equal("cd", sign.Match("bcd").RemainingText());
            Assert.True(sign.Match("-123").Success());
            Assert.Equal("-123", sign.Match("-123").RemainingText());
        }
    }
}
