namespace OOP
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var stringObject = new StringClass();
            var number = new Number();
            var whitespace = new Many(new Any("\n\r\t "));
            var value = new Choice(
                        stringObject,
                        number,
                        new Text("true"),
                        new Text("false"),
                        new Text("null"));
            var element = new Sequence(whitespace, value, whitespace);
            var elements = new List(element, new Character(','));
            var array = new Sequence(new Character('['), whitespace, elements, whitespace, new Character(']'));
            value.Add(array);
            var member = new Sequence(whitespace, stringObject, whitespace, new Character(':'), element);
            var members = new List(member, new Character(','));
            var obj = new Sequence(new Character('{'), whitespace, members, whitespace, new Character('}'));
            value.Add(obj);
            pattern = value;
        }

        public IMatch Match(StringView text)
        {
            return pattern.Match(text);
        }
    }
}
