using OOP;

namespace OOPTests
{
    public class StringFacts
    {
        [Fact]
        public void IsWrappedInDoubleQuotes()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted("abc")).Success());
        }

        [Fact]
        public void AlwaysStartsWithQuotes()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match("abc\"").Success());
        }

        [Fact]
        public void AlwaysEndsWithQuotes()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match("\"abc").Success());
        }

        [Fact]
        public void IsNotNull()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(null).Success());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(string.Empty).Success());
        }

        [Fact]
        public void IsAnEmptyDoubleQuotedString()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted(string.Empty)).Success());
        }

        [Fact]
        public void DoesNotContainControlCharacters()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(Quoted("a\nb\rc")).Success());
        }

        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted("⛅⚾")).Success());
        }

        [Fact]
        public void CanContainEscapedQuotationMark()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted(@"\""a\"" b")).Success());
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted(@"a \\ b")).Success());
        }

        [Fact]
        public void CanContainEscapedSolidus()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted(@"a \/ b")).Success());
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted(@"a \b b")).Success());
        }

        [Fact]
        public void CanContainEscapedFormFeed()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted(@"a \f b")).Success());
        }

        [Fact]
        public void CanContainEscapedLineFeed()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted(@"a \n b")).Success());
        }

        [Fact]
        public void CanContainEscapedCarrigeReturn()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted(@"a \r b")).Success());
        }

        [Fact]
        public void CanContainEscapedHorizontalTab()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted(@"a \t b")).Success());
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted(@"a \u26Be b")).Success());
        }

        [Fact]
        public void CanContainAnyMultipleEscapeSequences()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted(@"\\\u1212\n\t\r\\\b")).Success());
            Assert.True(text.Match(Quoted(@"\u1212\\\n\t\r\\\b")).Success());
            Assert.True(text.Match(Quoted(@"\\u1212\\\n\t\r\\\b")).Success());
        }

        [Fact]
        public void DoesNotContainUnrecognizedExcapceCharacters()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(Quoted(@"a\x")).Success());
        }

        [Fact]
        public void DoesNotEndWithReverseSolidus()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(Quoted(@"a\")).Success());
        }

        [Fact]
        public void DoesNotEndWithAnUnfinishedHexNumber()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(Quoted(@"a\u")).Success());
            Assert.False(text.Match(Quoted(@"a\u123")).Success());
        }

        [Fact]
        public void DoesNotContainHexadecimalControlCharacters()
        {
            StringClass text = new StringClass();
            Assert.False(text.Match(Quoted("\u000A")).Success());
            Assert.False(text.Match(Quoted("\u000D")).Success());
            Assert.False(text.Match(Quoted("\u0009")).Success());
            Assert.False(text.Match(Quoted("\u0008")).Success());
            Assert.False(text.Match(Quoted("\u000C")).Success());
            Assert.False(text.Match(Quoted("\u005C")).Success());
        }

        [Fact]
        public void CanContainOnlyUnderscore()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted("_")).Success());
        }

        [Fact]
        public void CanContainLeadingAndTrailingWhitespaces()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted(" abc ")).Success());
        }

        [Fact]
        public void CanContainSpecialCharacters()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted("!@#$%^&*()")).Success());
        }

        [Fact]
        public void CanContainEscapedBackslashes()
        {
            StringClass text = new StringClass();
            Assert.True(text.Match(Quoted(@"\\abc")).Success());
            Assert.False(text.Match(Quoted(@"\\a\xbc")).Success());
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
