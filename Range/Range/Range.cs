using System;

namespace RangeTask
{
    public class Range
    {
        private readonly int start;
        private readonly int end;
        public Range(int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException("Start must be less than or equal to end.");
            }
            this.start = start;
            this.end = end;
        }

        public bool IsCoveredBy(Range range)
        {
            return start <= range.start && end >= range.end;
        }

        public bool IsSameRange(Range range)
        {
            return start == range.start && end == range.end;
        }
    }
}