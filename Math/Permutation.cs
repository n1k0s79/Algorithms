using System;
using System.Linq;
using System.Collections.Generic;

namespace Math
{
    public class Permutation
    {
        public static int GetNumberOfAllPossible(int n) => Factorial.GetPrecalculated(n);

        /// <summary> Επιστρέφει όλες τις πιθανές διατάξεις όταν για κάθε θέση μπορώ να επιλέξω από μία συγκεκριμένη λίστα </summary>
        public static IEnumerable<IEnumerable<T>> GetAll<T>(IEnumerable<T> list, int? groupCount = null)
        {
            if (!groupCount.HasValue) groupCount = list.Count();
            return groupCount == 1 ? list.Select(t => new T[] { t }) : GetAll(list, groupCount - 1).SelectMany(t => list.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        /// <summary> Επιστρέφει όλες τις πιθανές διατάξεις όταν για κάθε θέση μπορώ να επιλέξω από μία συγκεκριμένη λίστα </summary>
        public static IEnumerable<IEnumerable<T>> GetAll_E<T>(IEnumerable<T> list, int? groupCount = null)
        {
            if (!groupCount.HasValue) groupCount = list.Count();
            return groupCount == 1 ? list.Select(t => new T[] { t }) : GetAll_E(list, groupCount - 1).SelectMany(m => list.Where(e => !m.Contains(e)), (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        /// <summary> Επιστρέφει όλες τις πιθανές διατάξεις όταν για κάθε θέση μπορώ να επιλέξω από μία συγκεκριμένη λίστα </summary>
        public static IEnumerable<IEnumerable<T>> GetAll_Ex<T>(IEnumerable<T> list, int? groupCount = null)
        {
            if (!groupCount.HasValue) groupCount = list.Count();
            if (groupCount == 1)
            {
                var items = list.Select(t => new T[] { t }).ToList();
                return items;
            }
            var inner = GetAll_Ex(list, groupCount - 1).ToList();
            Func<IEnumerable<T>, IEnumerable<T>> collectionSelector = (IEnumerable<T> m) =>
            {
                var ret = list.Where(e => !m.Contains(e)).ToList();
                return ret;
            };

            Func<IEnumerable<T>, T, IEnumerable<T>> resultSelector = (t1, t2) => {
                var concatenated = t1.Concat(new T[] { t2 }).ToList();
                return concatenated;
            };

            var many = inner.SelectMany(collectionSelector, resultSelector).ToList();
            return many;
        }


        /// <summary> Επιστρέφει όλες τις πιθανές διατάξεις όταν για κάθε θέση μπορώ να επιλέξω από μία συγκεκριμένη λίστα </summary>
        public static IEnumerable<IEnumerable<T>> GetAllPositional<T>(IEnumerable<IEnumerable<T>> listOfLists) => 
            listOfLists.Skip(1).Aggregate(
                    listOfLists.First().Select(c => new List<T>() { c }),
                    (previous, next) => previous.SelectMany(p => next.Select(d => new List<T>(p) { d })));

        /// <summary> Επιστρέφει όλες τις πιθανές διατάξεις όταν για κάθε θέση μπορώ να επιλέξω από μία συγκεκριμένη λίστα </summary>
        /// για μη ομοειδή αντικείμενα
        public static IEnumerable<IEnumerable<object>> GetAllPositional(IEnumerable<IEnumerable<object>> listOfLists) =>
            listOfLists.Skip(1).Aggregate(
                    listOfLists.First().Select(c => new List<object>() { c }),
                    (previous, next) => previous.SelectMany(p => next.Select(d => new List<object>(p) { d })));
    }

    public class Permutation<T> : Permutation
    {
        private long[] indexes = null;

        public T[] InitialOrderItems { get; private set; }

        /// <summary> Initializes the first permutation of the items </summary>
        public Permutation(params T[] items)
        {
            InitialOrderItems = items;
            indexes = GetInitialIndexes(items.Length);
        }

        /// <summary> Initializes the kth lexicographical item of a permutation </summary>
        public Permutation(T[] items, int m)
        {
            this.InitialOrderItems = items;
            this.indexes = new long[items.Length];

            int[] factoradic = new int[items.Length];
            for (int j = 1; j <= items.Length; ++j)
            {
                factoradic[items.Length - j] = m % j;
                m /= j;
            }

            int[] temp = new int[items.Length];
            for (int i = 0; i < items.Length; ++i) temp[i] = ++factoradic[i];

            this.indexes[items.Length - 1] = 1;
            for (int i = items.Length - 2; i >= 0; --i)
            {
                this.indexes[i] = temp[i];
                for (int j = i + 1; j < items.Length; ++j)
                {
                    if (this.indexes[j] >= this.indexes[i]) ++this.indexes[j];
                }
            }
            for (int i = 0; i < items.Length; ++i) --this.indexes[i];
        }

        private long[] GetInitialIndexes(int length)
        {
            var ret = new long[length];
            for (long i = 0; i < length; ++i) ret[i] = i;
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
                foreach (var index in indexes)
                {
                    ret.Add(this.InitialOrderItems[index]);
                }
                return ret;
            }
        }

        public int GetNumberOfAllPossible()
        {
            return GetNumberOfAllPossible(this.InitialOrderItems.Length);
        }

        public Permutation<T> Copy()
        {
            var ret = new Permutation<T>(this.InitialOrderItems);
            this.indexes.CopyTo(ret.indexes, 0);
            return ret;
        }

        public int Order
        {
            get
            {
                return this.InitialOrderItems.Length;
            }
        }

        /// <summary> Gets all possible permutations </summary>
        /// <remarks> That may be a LOT of permutations!</remarks>
        public static List<Permutation<T>> GetAllPossible(params T[] items)
        {
            var ret = new List<Permutation<T>>();
            var perm = new Permutation<T>(items);

            while (perm != null)
            {
                ret.Add(perm);
                perm = perm.GetSuccessor();
            }

            return ret;
        }

        /// <summary> Gets the next permutation </summary>
        public Permutation<T> GetSuccessor()
        {
            var ret = this.Copy();
            int left, right;
            left = ret.Order - 2;
            while ((ret.indexes[left] > ret.indexes[left + 1]) && (left >= 1)) --left;

            if ((left == 0) && (this.indexes[left] > this.indexes[left + 1])) return null;
            right = ret.Order - 1;

            while (ret.indexes[left] > ret.indexes[right]) --right;

            long temp = ret.indexes[left];
            ret.indexes[left] = ret.indexes[right];
            ret.indexes[right] = temp;
            int i = left + 1;
            int j = ret.Order - 1;

            while (i < j)
            {
                temp = ret.indexes[i];
                ret.indexes[i++] = ret.indexes[j];
                ret.indexes[j--] = temp;
            }

            return ret;
        }
    }
}