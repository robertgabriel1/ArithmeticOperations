using System;

namespace RangeTask
{
    public class Range
    {
        private int start;
        private int end;
        public Range(int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException("Start must be less or equal with end.");
            }
            this.start = start;
            this.end = end;
        }

        public bool IsOverlapping(Range range)
        {
            return end >= range.start && start <= range.end;
        }

        public bool MergeInto(Range range)
        {
            if (!IsOverlapping(range))
            {
                return false;
            }

            range.start = start < range.start ? start : range.start;
            range.end = end < range.end ? range.end : end;
            return true;
        }

        public Range[]? Split(Range range)
        {
            if (!IsOverlapping(range))
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