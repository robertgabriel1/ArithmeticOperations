using OOP;

namespace OOPTests
{
    public class ManyFacts
    {
        [Fact]
        public void Match_Should_RemoveSimilarCharactersFromBeginning_WhenTextStartsWithPattern()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("abc").Success());
            Assert.True(a.Match("aaaabc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
            Assert.Equal("bc", a.Match("aaaabc").RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenPatternCharIsAtAnotherPositionThanTheFirstOne()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("bac").Success());
            Assert.Equal("bac", a.Match("bac").RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenTextDoesNotStartsWithPattern()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenTextIsEmptyOrNull()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("").Success());
            Assert.True(a.Match(null).Success());
            Assert.Equal("", a.Match("").RemainingText());
            Assert.Equal(null, a.Match(null).RemainingText()) ;
        }

        [Fact]
        public void Match_Should_RemoveSimilarCharactersFromBeginning_WhenFirstCharactersAreInRange()
        {
            var digits = new Many(new OOP.Range('0', '9'));
            Assert.True(digits.Match("12345ab123").Success());
            Assert.Equal("ab123", digits.Match("12345ab123").RemainingText());
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenFirstCharactersAreNotInRange()
        {
            var digits = new Many(new OOP.Range('0', '9'));
            Assert.True(digits.Match("ab").Success());
            Assert.Equal("ab", digits.Match("ab").RemainingText());
        }
    }
}
