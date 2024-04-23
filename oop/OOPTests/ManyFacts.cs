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
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenPatternCharIsAtAnotherPositionThanTheFirstOne()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("bac").Success());
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenTextDoesNotStartsWithPattern()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("bc").Success());
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenTextIsEmptyOrNull()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("").Success());
            Assert.True(a.Match(null).Success());
        }

        [Fact]
        public void Match_Should_RemoveSimilarCharactersFromBeginning_WhenFirstCharactersAreInRange()
        {
            var digits = new Many(new OOP.Range('0', '9'));
            Assert.True(digits.Match("12345ab123").Success());
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenFirstCharactersAreNotInRange()
        {
            var digits = new Many(new OOP.Range('0', '9'));
            Assert.True(digits.Match("ab").Success());
        }
    }
}
