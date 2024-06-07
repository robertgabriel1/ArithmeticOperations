namespace OOP
{
    public class Any : IPattern
    {
        private readonly string accepted;
        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(StringView text)
        {
            return text.IsEmpty() || !accepted.Contains(text.Peek())
            ? new Match(false, text)
            : new Match(true, text.Advance());
        }
    }
}
