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
                if (ranges[i].IsOverlapping(range))
                {
                    ranges[i] = ranges[i].Merge(range);
                    merged = true;
                    break;
                }
            }

            if (!merged)
            {
                Array.Resize(ref ranges, ranges.Length + 1);
                ranges[^1] = range;
            }
        }

        public void RemoveRange(Range range)
        {
            foreach (Range r in ranges)
            {
                if (r.IsOverlapping(range) && !r.IsIdenticalRange(range))
                {
                    Range[] leftRange = r.Split(range);
                    ShiftToReplace();
                    AddRange(leftRange[0]);
                    AddRange(leftRange[1]);
                    break;
                }
                else if (r.IsIdenticalRange(range))
                {
                    ShiftToReplace();
                    break;
                }
            }
        }

        public void ShiftToReplace()
        {
            for (int i = 0; i < ranges.Length; i++)
            {
                for (int j = i + 1; j < ranges.Length; j++)
                {
                    ranges[j - 1] = ranges[j];
                }
                Array.Resize(ref ranges, ranges.Length - 1);
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
