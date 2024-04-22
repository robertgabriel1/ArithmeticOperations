namespace OOP
{
    public class Any : IPattern
    {
        public Any(string accepted)
        {
        }

        public IMatch Match(string text)
        {
            return new Match(false, text);
        }
    }
}
