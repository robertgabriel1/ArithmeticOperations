using System;

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
            bool merged = false;
            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i].CanBeMerged(range))
                {
                    ranges[i] = ranges[i].Merge(range);
                    merged = true;
                    break;
                }
            }

            if (!merged && range.IsValidRange())
            {
            Array.Resize(ref ranges, ranges.Length + 1);
            ranges[^1] = range;
            }
        }

        public void RemoveRange(Range range)
        {
            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i].IsCovering(range))
                {
                    Range leftRange = ranges[i].SplitLeft(range);
                    Range rightRange = ranges[i].SplitRight(range);
                    for (int j = i + 1; j < ranges.Length; j++)
                    {
                        ranges[j - 1] = ranges[j];
                    }
                    Array.Resize(ref ranges, ranges.Length - 1);
                    AddRange(leftRange);
                    AddRange(rightRange);
                    break;
                }
            }
        }

        public bool Query(Range range)
        {
            foreach (Range r in ranges)
            {
                if (r.IsCovering(range))
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
