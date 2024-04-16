namespace RangeTask
{
        public struct MergeResult
        {
            public bool Result;
            public Range Merged;

            public MergeResult(bool result, Range merged)
            {
                Result = result;
                Merged = merged;
            }
        }

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

        public MergeResult MergeInto(Range range)
        {
            if (!IsOverlapping(range))
            {
                return new MergeResult(false, new Range(-1, -1));
            }

            int newStart = start < range.start ? start : range.start;
            int newEnd = end > range.end ? end : range.end;

            Range mergedRange = new Range(newStart, newEnd);
            return new MergeResult(true, mergedRange);
        }

        public (bool result, Range[] rangesLeft) Split(Range range)
        {
            if (!IsOverlapping(range))
            {
                return (false, new Range[0]);
            }

            Range[] result = new Range[2];
            result[0] = start == range.start ? null : new Range(start, range.start - 1);
            result[1] = end == range.end ? null : new Range(range.end + 1, end);
            return (true, result);
        }
    }
}