namespace RangeTask
{
    public class MultiRange
    {
        private Range[] ranges;
        public MultiRange()
        {
            ranges = new Range[0];
        }

        public void AddRange(Range range)
        {
            Array.Resize(ref ranges, ranges.Length + 1);
            ranges[^1] = range;
        }
        
        public void RemoveRange(Range range)
        {
            int index = Array.IndexOf(ranges, range);
            if (index != -1)
            {
                for (int j = index + 1; j < ranges.Length; j++)
                {
                    ranges[j - 1] = ranges[j];
                }
            }

            Array.Resize(ref ranges, ranges.Length - 1);
        }

        public bool Query(Range range)
        {
            foreach (Range r in ranges)
            {
                if (r.Covers(range))
                {
                    return true;
                }
            }

            return false;
        }

        public int GetLength()
        {
            return ranges.Length;
        }
    }
}
