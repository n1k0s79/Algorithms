using System;
using System.Collections.Generic;

namespace Math
{
    public class Combination
    {
        /// <summary> Returns the total number of possible combination of totalCount items per subsetCount </summary>
        public static long GetNumberOfAllPossible(long totalCount, long subsetCount)
        {
            if (totalCount < 0 || subsetCount < 0) throw new Exception("Negative argument in Choose");
            if (totalCount < subsetCount) return 0;
            if (totalCount == subsetCount) return 1;
            long delta, iMax;
            if (subsetCount < totalCount - subsetCount)
            {
                delta = totalCount - subsetCount;
                iMax = subsetCount;
            }
            else
            {
                delta = subsetCount;
                iMax = totalCount - subsetCount;
            }

            long ret = delta + 1;
            for (long i = 2; i <= iMax; ++i)
            {
                checked { ret = (ret * (delta + i)) / i; }
            }
            return ret;
        }

        // return largest value v where v < a and  Choose(v,b) <= x
        protected static long LargestV(long a, long b, long x)
        {
            long v = a - 1;
            while (GetNumberOfAllPossible(v, b) > x) --v;
            return v;
        }
    }

    public class Combination<T> : Combination
    {
        private long SubsetCount { get; set; }

        private long[] indexes = null;

        private T[] allItems { get; set; }

        /// <summary> A combination n of the items </summary>
        public Combination(T[] allItems, long subsetCount)
        {
            this.allItems = allItems;
            if (subsetCount > allItems.Length) throw new Exception("Bad subsetCount");
            this.SubsetCount = subsetCount;
            this.indexes = GetInitialIndexes(this.SubsetCount);
        }

        private long[] GetInitialIndexes(long length)
        {
            var ret = new long[length];
            for (long i = 0; i < length; ++i) ret[i] = i;
            return ret;
        }

        private Combination<T> Copy()
        {
            var ret = new Combination<T>(this.allItems, this.SubsetCount);
            ret.indexes = new long[this.indexes.Length];
            this.indexes.CopyTo(ret.indexes, 0);
            return ret;
        }

        public override string ToString()
        {
            string s = string.Empty;
            foreach (var item in this.Items) s += item.ToString() + " ";
            return s;
        }

        public List<T> Items
        {
            get
            {
                var ret = new List<T>();
                for (long i = 0; i < this.SubsetCount; ++i) ret.Add(this.allItems[this.indexes[i]]);
                return ret;
            }
        }

        public int TotalCount
        {
            get
            {
                return this.allItems.Length;
            }
        }

        public long GetNumberOfAllPossible()
        {
            return GetNumberOfAllPossible(this.TotalCount, this.SubsetCount);
        }

        public Combination<T> GetSuccessor()
        {
            if (this.indexes[0] == this.TotalCount - this.SubsetCount) return null;

            var ret = this.Copy();

            long x;
            for (x = this.SubsetCount - 1; x > 0 && ret.indexes[x] == this.TotalCount - this.SubsetCount + x; --x) ;

            ++ret.indexes[x];

            for (long j = x; j < this.SubsetCount - 1; ++j) ret.indexes[j + 1] = ret.indexes[j] + 1;
            return ret;
        }

        public Combination<T> GetPredecessor()
        {
            if (this.indexes[this.SubsetCount - 1] == this.SubsetCount - 1) return null;

            var ret = this.Copy();

            long x;
            for (x = this.SubsetCount - 1; x > 0 && ret.indexes[x] == ret.indexes[x - 1] + 1; --x) ;

            --ret.indexes[x];

            for (long j = x + 1; j < this.SubsetCount; ++j) ret.indexes[j] = this.TotalCount - this.SubsetCount + j;

            return ret;
        }

        public static List<Combination<T>> GetAllPossible(T[] items, int subsetCount)
        {
            var ret = new List<Combination<T>>();
            var comb = new Combination<T>(items, subsetCount);

            while (comb != null)
            {
                ret.Add(comb);
                comb = comb.GetSuccessor();
            }

            return ret;
        }

        /// <summary> Get the mth item </summary>
        public Combination<T> GetMth(long mth)
        {
            var ret = new Combination<T>(this.allItems, this.SubsetCount);

            long a = this.TotalCount;
            long b = this.SubsetCount;
            long x = (GetNumberOfAllPossible(this.TotalCount, this.SubsetCount) - 1) - mth;

            for (long i = 0; i < this.SubsetCount; ++i) // store combinadic
            {
                ret.indexes[i] = LargestV(a, b, x);
                x = x - GetNumberOfAllPossible(ret.indexes[i], b);
                a = ret.indexes[i];
                b = b - 1;
            }

            for (long i = 0; i < this.SubsetCount; ++i)
            {
                ret.indexes[i] = (this.TotalCount - 1) - ret.indexes[i];
            }

            return ret;
        }
    }
}