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
            Assert.True(a.Match(new StringView("abc", 0)).RemainingText().StartsWith("bc"));
            Assert.True(a.Match(new StringView("aaaabc", 0)).RemainingText().StartsWith("bc"));
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenPatternCharIsAtAnotherPositionThanTheFirstOne()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match(new StringView("bac", 0)).Success());
            Assert.True(a.Match(new StringView("bac", 0)).RemainingText().StartsWith("bac"));
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenTextDoesNotStartsWithPattern()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match(new StringView("bc", 0)).Success());
            Assert.True(a.Match(new StringView("bc", 0)).RemainingText().StartsWith("bc"));
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenTextIsEmptyOrNull()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match(new StringView("", 0)).Success());
            Assert.True(a.Match(new StringView(null, 0)).Success());
            Assert.True(a.Match(new StringView("", 0)).RemainingText().StartsWith(""));
            Assert.True(a.Match(new StringView(null, 0)).RemainingText().StartsWith(null));
        }

        [Fact]
        public void Match_Should_RemoveSimilarCharactersFromBeginning_WhenFirstCharactersAreInRange()
        {
            var digits = new Many(new OOP.Range('0', '9'));
            Assert.True(digits.Match(new StringView("12345ab123", 0)).Success());
            Assert.True(digits.Match(new StringView("12345ab123", 0)).RemainingText().StartsWith("ab123"));
        }

        [Fact]
        public void Match_Should_ReturnSameText_WhenFirstCharactersAreNotInRange()
        {
            var digits = new Many(new OOP.Range('0', '9'));
            Assert.True(digits.Match(new StringView("ab", 0)).Success());
            Assert.True(digits.Match(new StringView("ab", 0)).RemainingText().StartsWith("ab"));
        }
    }
}
