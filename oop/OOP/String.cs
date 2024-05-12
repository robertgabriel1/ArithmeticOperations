namespace OOP
{
    public class StringClass : IPattern
    {
        private readonly IPattern pattern;

        public StringClass()
        {
            var quote = new Character('"');
            var hexAllowedCharacter = new Choice(new Range('0', '9'), new Range('A', 'F'), new Range('a', 'f'));
            var hexPart = new Sequence(new Character('u'), hexAllowedCharacter, hexAllowedCharacter, hexAllowedCharacter, hexAllowedCharacter);
            var escapeCharacters = new Any("fnr/bt\\\"");
            var acceptedCharacters = new Choice(new Range((char)32, (char)33), new Range((char)35, (char)91), new Range((char)93,(char)127));
            var characters = new Choice(acceptedCharacters, new Sequence(new Character('\\'), new Choice(hexPart, escapeCharacters)));
            pattern = new Sequence(quote, new Many(characters), quote);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
