namespace OOP
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var stringObject = new StringClass();
            var number = new Number();
            var whitespaces = new Many(new Any("\n\r\t "));
            var separator = new Character(',');
            var value = new Choice(stringObject, number, new Text("true"),
            new Text("false"), new Text("null"));
            var valueFormat = new Sequence(whitespaces, value, whitespaces);
            var openSquareBracket = new Character('[');
            var closeSquareBracket = new Character(']');
            var listOfElements = new List(valueFormat, separator);
            var array = new Sequence(openSquareBracket, listOfElements, closeSquareBracket);
            value.Add(array);
            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
