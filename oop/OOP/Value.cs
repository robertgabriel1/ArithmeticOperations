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
            var separator = new Sequence(whitespaces, new Character(','), whitespaces);
            var value = new Choice(
                        stringObject,
                        number,
                        new Text("true"),
                        new Text("false"),
                        new Text("null"));
            var valueFormat = new Sequence(whitespaces, value, whitespaces);
            var listOfElements = new List(valueFormat, separator);
            var array = new Sequence(new Character('['), listOfElements, new Character(']'));
            value.Add(array);
            var colon = new Character(':');
            var member = new Sequence(whitespaces, stringObject, whitespaces, colon, value);
            var listOfObjects = new List(member, separator);
            var obj = new Sequence(new Character('{'), whitespaces, listOfObjects, new Character('}'));
            value.Add(obj);
            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
