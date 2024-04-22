using OOP;

namespace OOPTests
{
    public class SequenceFacts
    {
        [Fact]
        public void Match_TestAllSituations()
        {
            var ab = new Sequence(
            new Character('a'),
            new Character('b')
            );

            Assert.True(ab.Match("abcd").Success());
            Assert.False(ab.Match("ax").Success());
            Assert.False(ab.Match("def").Success());
            Assert.False(ab.Match("").Success());
            Assert.False(ab.Match(null).Success());

            var abc = new Sequence(
            ab,
            new Character('c')
            );
            Assert.True(abc.Match("abcd").Success());
            Assert.False(abc.Match("def").Success());
            Assert.False(abc.Match("abx").Success());
            Assert.False(abc.Match("").Success());
            Assert.False(abc.Match(null).Success());

            var hex = new Choice(
            new OOP.Range('0', '9'),
            new OOP.Range('a', 'f'),
            new OOP.Range('A', 'F')
            );

            var hexSeq = new Sequence(
            new Character('u'),
            new Sequence(
            hex,
            hex,
            hex,
            hex
            )
            );

            Assert.True(hexSeq.Match("u1234").Success());
            Assert.True(hexSeq.Match("uabcdef").Success());
            Assert.True(hexSeq.Match("uB005 ab").Success());
            Assert.False(hexSeq.Match("abc").Success());
            Assert.False(hexSeq.Match(null).Success());
        }
    }
}