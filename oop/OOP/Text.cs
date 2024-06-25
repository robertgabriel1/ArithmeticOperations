namespace OOP
{
    public class Text : IPattern
    {
        private readonly string prefix;
        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(StringView text)
        {
            return !text.IsEmpty() && text.StartsWith(prefix)
            ? new Match(true, text.Advance(prefix.Length))
            : new Match(false, text);
        }
    }
}
