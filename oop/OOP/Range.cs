namespace OOP
{
    public class Range : IPattern
    {
        private readonly char Start;
        private readonly char End;
        public Range(char start, char end)
        {
            Start = start;
            End = end;
        }
        public IMatch Match(StringView text)
        {
            return (text.IsEmpty() || text.Peek() < Start || text.Peek() > End) 
            ? new Match(false, text)
            : new Match(true, text.Advance());
        }
    }
}