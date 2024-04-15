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
                throw new ArgumentException("Start must be less or equal with end.");
            }
            this.start = start;
            this.end = end;
        }

        public bool IsCovering(Range range)
        {
            return range.start >= start && range.end <= end;
        }

        public bool IsIdenticalRange(Range range)
        {
            return start == range.start && end == range.end;
        }

        public Range? Merge(Range range)
        {
            if (!(end >= range.start && start <= range.end))
            {
                return null;
            }

            int maxStart = start > range.start ? range.start : start;
            int maxEnd = end > range.end ? end : range.end;
            return new Range(maxStart, maxEnd);
        }

        public Range[]? Split(Range range)
        {
            if (!(end >= range.start && start <= range.end))
            {
                return null;
            }

            Range[] result = new Range[2];
            result[0] = start == range.start ? null : new Range(start, range.start - 1);
            result[1] = end == range.end ? null : new Range(range.end + 1, end);
            return result;
        }
    }
}