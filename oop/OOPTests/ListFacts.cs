using OOP;

namespace OOPTests
{
    public class ListFacts
    {

        [Fact]
        public void Match_Should_ReturnEmptyString_WhenEveryThingMatch()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match(new StringView("1,2,3", 0)).Success());
            Assert.True(new StringView("1,2,3", 5).CheckRemainingString(a.Match(new StringView("1,2,3", 0)).RemainingText()));
        }

        [Fact]
        public void Match_Should_RemoveWhatMatches_WhenAlmostEverythingMatch()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match(new StringView("1,2,3,", 0)).Success());
            Assert.True(new StringView("1,2,3,", 5).CheckRemainingString(a.Match(new StringView("1,2,3,", 0)).RemainingText()));

            Assert.True(a.Match(new StringView("1a", 0)).Success());
            Assert.True(new StringView("1a", 1).CheckRemainingString(a.Match(new StringView("1a", 0)).RemainingText()));

            Assert.True(a.Match(new StringView("1,2,3!", 0)).Success());
            Assert.True(new StringView("1,2,3!", 5).CheckRemainingString(a.Match(new StringView("1,2,3!", 0)).RemainingText()));
        }


        [Fact]
        public void Match_Should_ReturnSameString_WhenNothingMatches()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match(new StringView("abc", 0)).Success());
            Assert.True(new StringView("abc", 3).CheckRemainingString(a.Match(new StringView("abc", 0)).RemainingText()));
        }

        [Fact]
        public void Match_Should_ReturnSameString_WhenStartsWithSeparator()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match(new StringView(",1,2,3", 0)).Success());
            Assert.True(new StringView(",1,2,3", 5).CheckRemainingString(a.Match(new StringView(",1,2,3", 0)).RemainingText()));
        }

        [Fact]
        public void Match_Should_ReturnSameString_EmptyOrNull()
        {
            var a = new List(new OOP.Range('0', '9'), new Character(','));
            Assert.True(a.Match(new StringView("", 0)).Success());
            Assert.True(new StringView("", 0).CheckRemainingString(a.Match(new StringView("", 0)).RemainingText()));

            Assert.True(a.Match(new StringView(null, 0)).Success());
            Assert.True(new StringView(null, 0).CheckRemainingString(a.Match(new StringView(null, 0)).RemainingText()));
        }


        [Fact]
        public void Match_Should_ReturnExpected_WhenCombiningSeveralClasses()
        {
            var digits = new OneOrMore(new OOP.Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            string firstTest = "1; 22  ;\n 333 \t; 22";
            string secondTest = "1 \n;";
            string thirdTest = "abc";

            Assert.True(list.Match(new StringView(firstTest, 0)).Success());
            Assert.True(new StringView(firstTest, firstTest.Length).CheckRemainingString(list.Match(new StringView(firstTest, 0)).RemainingText()));

            Assert.True(list.Match(new StringView("", 0)).Success());
            Assert.True(new StringView(secondTest, secondTest.Length).CheckRemainingString(list.Match(new StringView(secondTest, 0)).RemainingText()));

            Assert.True(list.Match(new StringView("abc", 0)).Success());
            Assert.True(new StringView(thirdTest, thirdTest.Length).CheckRemainingString(list.Match(new StringView(thirdTest, 0)).RemainingText()));
        }
    }
}
