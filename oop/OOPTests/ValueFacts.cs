using Newtonsoft.Json.Linq;
using OOP;
using System;

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

        [Fact]
        public void Object_OnlyOneValue()
        {
            var value = new Value();
            Assert.True(value.Match("{\"age\": 45}").Success());
            Assert.Equal("", value.Match("{\"age\": 45}").RemainingText());
            Assert.True(value.Match("{\"name\": \"Dragos\"}").Success());
            Assert.Equal("", value.Match("{\"name\": \"Dragos\"}").RemainingText());
        }

        [Fact]
        public void Object_MultipleValues()
        {
            var value = new Value();
            Assert.True(value.Match("{\"age\": [45,55,34]}").Success());
            Assert.Equal("", value.Match("{\"age\": [45,55,34]}").RemainingText());
            Assert.True(value.Match("{\"name\": [\"Dragos\", \"Matei\", \"Ana\"]}").Success());
            Assert.Equal("", value.Match("{\"name\": [\"Dragos\", \"Matei\", \"Ana\"]}").RemainingText());
        }

        [Fact]
        public void Object_MultipleObjects()
        {
            var value = new Value();
            Assert.True(value.Match("[{ \"age\": [45, 55, 34]}, { \"weight\":[76, 83, 78]}]").Success());
            Assert.Equal("", value.Match("[{ \"age\": [45, 55, 34]}, { \"weight\": [76, 83, 78]}]").RemainingText());
            Assert.True(value.Match("[{ \"firstName\": [\"Dragos\", \"Matei\", \"Ana\"]}, { \"lastName\": [\"Popescu\", \"Radu\", \"Marin\"]}]").Success());
            Assert.Equal("", value.Match("[{ \"firstName\": [\"Dragos\", \"Matei\", \"Ana\" ]}, { \"lastName\": [\"Popescu\", \"Radu\", \"Marin\"]}]").RemainingText());
        } 
    }
}
