using OOP;

namespace OOPTests
{
    public class ValueFacts
    {
        [Fact]
        public void Array_WithOneNumberElement()
        {
            var array = new Value();
            var stringView= new StringView("[45]", 0);
            var stringViewRemaining = new StringView("", 0);
            Assert.True(array.Match(stringView).Success());
            Assert.Equal(stringViewRemaining, array.Match(stringView).RemainingText());
        }

        [Fact]
        public void Array_WithOneStringElement()
        {
            var array = new Value();
            var stringView = new StringView("[\"anything\"]", 0);
            var stringViewRemaining = new StringView("", 0);
            Assert.True(array.Match(stringView).Success());
            Assert.Equal(stringViewRemaining, array.Match(stringView).RemainingText());
        }

        [Fact]
        public void Array_Empty()
        {
            var array = new Value();
            var stringView = new StringView("[]", 0);
            var stringViewRemaining = new StringView("", 0);
            Assert.True(array.Match(stringView).Success());
            Assert.Equal(stringViewRemaining, array.Match(stringView).RemainingText());
        }

        [Fact]
        public void Array_MultipleNumberElements()
        {
            var array = new Value();
            var stringView = new StringView("[45,46,47]", 0);
            var stringViewRemaining = new StringView("", 0);
            Assert.True(array.Match(stringView).Success());
            Assert.Equal(stringViewRemaining, array.Match(stringView).RemainingText());
        }

        [Fact]
        public void Array_MultipleStringElements()
        {
            var array = new Value();
            var stringView = new StringView("[\"one\",\"two\",\"three\"]", 0);
            var stringViewRemaining = new StringView("", 0);
            Assert.True(array.Match(stringView).Success());
            Assert.Equal(stringViewRemaining, array.Match(stringView).RemainingText());
        }

        [Fact]
        public void Object_OnlyOneValue()
        {
            var value = new Value();
            var stringView = new StringView("{\"age\": 45}", 0);
            var stringView2 = new StringView("{\"name\": \"Dragos\"}", 0);
            var stringViewRemaining = new StringView("", 0);
            Assert.True(value.Match(stringView).Success());
            Assert.Equal(stringViewRemaining, value.Match(stringView).RemainingText());
            Assert.True(value.Match(stringView2).Success());
            Assert.Equal(stringViewRemaining, value.Match(stringView2).RemainingText());
        }

        [Fact]
        public void Object_MultipleValues()
        {
            var value = new Value();
            var stringView = new StringView("{\"age\": [45,55,34]}", 0);
            var stringView2 = new StringView("{\"name\": [\"Dragos\", \"Matei\", \"Ana\"]}", 0);
            var stringViewRemaining = new StringView("", 0);
            Assert.True(value.Match(stringView).Success());
            Assert.Equal(stringViewRemaining, value.Match(stringView).RemainingText());
            Assert.True(value.Match(stringView2).Success());
            Assert.Equal(stringViewRemaining, value.Match(stringView2).RemainingText());
        }

        [Fact]
        public void Object_MultipleObjects()
        {
            var value = new Value();
            var stringView = new StringView("[{ \"age\": [45, 55, 34]}, { \"weight\":[76, 83, 78]}]", 0);
            var stringView2 = new StringView("[{ \"firstName\": [\"Dragos\", \"Matei\", \"Ana\"]}, { \"lastName\": [\"Popescu\", \"Radu\", \"Marin\"]}]", 0);
            var stringViewRemaining = new StringView("", 0);
            Assert.True(value.Match(stringView).Success());
            Assert.Equal(stringViewRemaining, value.Match(stringView).RemainingText());
            Assert.True(value.Match(stringView2).Success());
            Assert.Equal(stringViewRemaining, value.Match(stringView2).RemainingText());
        } 
    }
}
