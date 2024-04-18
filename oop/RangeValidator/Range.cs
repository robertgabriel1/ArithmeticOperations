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
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            foreach (char c in text)
            {
                if (c < Start || c > End)
                {
                    return false;
                }
            }

            return true;
        }
    }
}