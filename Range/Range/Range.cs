using System;

namespace RangeTask
{
    public class Range
    {
        private readonly int start;
        private readonly int end;
        public Range(int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        public bool IsCovering(Range range)
        {
            return range.start >= start && range.end <= end;
        }

        public bool CanBeMerged(Range range)
        {
            return (range.start >= start && range.start <= end) || (range.end >= start && range.end <= end);
        }

        public Range Merge(Range range)
        {
            int maxStart = start > range.start ? range.start : start;
            int maxEnd = end > range.end ? end : range.end;
            return new Range(maxStart, maxEnd);
        }

        public Range SplitLeft(Range range)
        {
            return new Range(start, range.start - 1);
        }

        public Range SplitRight(Range range)
        {
            return new Range(range.end + 1, end);
        }

        public bool IsValidRange()
        {
            return start <= end;
        }
    }
}