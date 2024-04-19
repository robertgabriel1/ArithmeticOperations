namespace RangeValidator
{
    public class Range
    {
        private readonly char Start;
        private readonly char End;
        public Range(char start, char end)
        {
            Start = start;
            End = end;
        }
        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text) || text[0] < Start || text[0] > End)
            {
                return false;
            }

            return true;
        }
    }
}