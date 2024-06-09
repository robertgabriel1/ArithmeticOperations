using OOP;

namespace OOPTests
{
    public class ManyFacts
    {
        [Fact]
        public void Match_Should_RemoveSimilarCharactersFromBeginning_WhenTextStartsWithPattern()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match(new StringView("abc", 0)).Success());
            Assert.True(a.Match(new StringView("aaaabc", 0)).Success());
            Assert.True(new StringView("abc", 3).CheckRemainingString(a.Match(new StringView("abc", 0)).RemainingText()));
            Assert.True(new StringView("aaaabc", 6).CheckRemainingString(a.Match(new StringView("aaaabc", 0)).RemainingText()));
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenPatternCharIsAtAnotherPositionThanTheFirstOne()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match(new StringView("bac", 0)).Success());
            Assert.True(new StringView("bac", 3).CheckRemainingString(a.Match(new StringView("bac", 0)).RemainingText()));
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenTextDoesNotStartsWithPattern()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match(new StringView("bc", 0)).Success());
            Assert.True(new StringView("bc", 2).CheckRemainingString(a.Match(new StringView("bc", 0)).RemainingText()));
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenTextIsEmptyOrNull()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match(new StringView("", 0)).Success());
            Assert.True(a.Match(new StringView(null, 0)).Success());
            Assert.True(new StringView("", 0).CheckRemainingString(a.Match(new StringView("", 0)).RemainingText()));
            Assert.True(new StringView(null, 0).CheckRemainingString(a.Match(new StringView(null, 0)).RemainingText()));
        }

        [Fact]
        public void Match_Should_RemoveSimilarCharactersFromBeginning_WhenFirstCharactersAreInRange()
        {
            var digits = new Many(new OOP.Range('0', '9'));
            Assert.True(digits.Match(new StringView("12345ab123", 0)).Success());
            Assert.True(new StringView("12345ab123", 10).CheckRemainingString(digits.Match(new StringView("12345ab123", 0)).RemainingText()));
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenFirstCharactersAreNotInRange()
        {
            var digits = new Many(new OOP.Range('0', '9'));
            Assert.True(digits.Match(new StringView("ab", 0)).Success());
            Assert.True(new StringView("ab", 2).CheckRemainingString(digits.Match(new StringView("ab", 0)).RemainingText()));
        }
    }
}
