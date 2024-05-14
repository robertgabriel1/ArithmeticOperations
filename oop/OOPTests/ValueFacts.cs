using OOP;

namespace OOPTests
{
    public class ValueFacts
    {
        [Fact]
        public void Array_WithOneNumberElement()
        {
            var array = new Value();
            Assert.True(array.Match("[45]").Success());
            Assert.Equal("", array.Match("[45]").RemainingText());
        }

        [Fact]
        public void Array_WithOneStringElement()
        {
            var array = new Value();
            Assert.True(array.Match("[\"anything\"]").Success());
            Assert.Equal("", array.Match("[\"anything\"]").RemainingText());
        }

        [Fact]
        public void Array_Empty()
        {
            var array = new Value();
            Assert.True(array.Match("[]").Success());
            Assert.Equal("", array.Match("[]").RemainingText());
        }

        [Fact]
        public void Array_MultipleNumberElements()
        {
            var array = new Value();
            Assert.True(array.Match("[45,46,47]").Success());
            Assert.Equal("", array.Match("[45,46,47]").RemainingText());
        }

        [Fact]
        public void Array_MultipleStringElements()
        {
            var array = new Value();
            Assert.True(array.Match("[\"one\",\"two\",\"three\"]").Success());
            Assert.Equal("", array.Match("[\"one\",\"two\",\"three\"]").RemainingText());
        }
    }
}
