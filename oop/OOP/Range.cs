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
        public IMatch Match(string text)
        {
            return (string.IsNullOrEmpty(text) || text[0] < Start || text[0] > End) 
            ? new Match(false, text)
            : new Match(true, text[1..]);
        }
    }
}