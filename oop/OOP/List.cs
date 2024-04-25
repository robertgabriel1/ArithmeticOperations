namespace OOP
{
    public class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern range, IPattern character)
        {
            this.pattern = new Many(new Sequence(range, new Many(new Sequence(character, range))));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
