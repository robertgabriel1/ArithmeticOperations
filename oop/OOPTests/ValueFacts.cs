using OOP;

namespace OOPTests
{
    public class ValueFacts
    {
        [Fact]
        public void Array_WithOneNumberElement()
        {
            var array = new Value();
            Assert.True(array.Match(new StringView("[45]", 0)).Success());
            Assert.True(array.Match(new StringView("[45]", 0)).RemainingText().StartsWith(""));
        }

        [Fact]
        public void Array_WithOneStringElement()
        {
            var array = new Value();
            string text = "[\"anything\"]";
            Assert.True(array.Match(new StringView(text, 0)).Success());
            Assert.True(array.Match(new StringView(text, 0)).RemainingText().StartsWith(""));
        }

        [Fact]
        public void Array_Empty()
        {
            var array = new Value();
            Assert.True(array.Match(new StringView("[]", 0)).Success());
            Assert.True(array.Match(new StringView("[]", 0)).RemainingText().StartsWith(""));
        }

        [Fact]
        public void Array_MultipleNumberElements()
        {
            var array = new Value();
            string text = "[45,46,47]";
            Assert.True(array.Match(new StringView(text, 0)).Success());
            Assert.True(array.Match(new StringView(text, 0)).RemainingText().StartsWith(""));
        }

        [Fact]
        public void Array_MultipleStringElements()
        {
            var array = new Value();
            string text = "[\"one\",\"two\",\"three\"]";
            Assert.True(array.Match(new StringView(text, 0)).Success());
            Assert.True(array.Match(new StringView(text, 0)).RemainingText().StartsWith(""));
        }

        [Fact]
        public void Object_OnlyOneValue()
        {
            var value = new Value();
            string firstString = "{\"age\": 45}";
            string secondString = "{\"name\": \"Dragos\"}";
            Assert.True(value.Match(new StringView(firstString, 0)).Success());
            Assert.True(value.Match(new StringView(firstString, 0)).RemainingText().StartsWith(""));
            Assert.True(value.Match(new StringView(secondString, 0)).Success());
            Assert.True(value.Match(new StringView(secondString, 0)).RemainingText().StartsWith(""));
        }

        [Fact]
        public void Object_MultipleValues()
        {
            var value = new Value();
            string firstString = "{\"age\": [45,55,34]}";
            string secondString = "{\"name\": [\"Dragos\", \"Matei\", \"Ana\"]}";
            Assert.True(value.Match(new StringView(firstString, 0)).Success());
            Assert.True(value.Match(new StringView(firstString, 0)).RemainingText().StartsWith(""));
            Assert.True(value.Match(new StringView(secondString, 0)).Success());
            Assert.True(value.Match(new StringView(secondString, 0)).RemainingText().StartsWith(""));
        }

        [Fact]
        public void Object_MultipleObjects()
        {
            var value = new Value();
            string firstString = "[{ \"age\": [45, 55, 34]}, { \"weight\":[76, 83, 78]}]";
            string secondString = "[{ \"firstName\": [\"Dragos\", \"Matei\", \"Ana\"]}, { \"lastName\": [\"Popescu\", \"Radu\", \"Marin\"]}]";
            Assert.True(value.Match(new StringView(firstString, 0)).Success());
            Assert.True(value.Match(new StringView(firstString, 0)).RemainingText().StartsWith(""));
            Assert.True(value.Match(new StringView(secondString, 0)).Success());
            Assert.True(value.Match(new StringView(secondString, 0)).RemainingText().StartsWith(""));
        } 
    }
}
