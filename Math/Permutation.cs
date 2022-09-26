using System;
using System.Linq;
using System.Collections.Generic;

namespace Math
{
    public class Permutation
    {
        /// <summary> Η παρακάτω αναδρομική συνάρτηση των δύο γραμμών επιστρέφει όλες τις διατάξεις των Ν αντικειμένων ανά Χ </summary>
        public static IEnumerable<IEnumerable<T>> GetAll<T>(IEnumerable<T> items, int? length = null)
        {
            if (!length.HasValue) length = items.Count();
            return length == 1 ? items.Select(i => new T[] { i }) : GetAll(items, length - 1).SelectMany(l => items.Except(l), (l, i) => l.Concat(new T[] { i }));
        }
         
        private static List<T> GetAllExcept<T>(List<T> initial, List<T> exceptions) => initial.Except(exceptions).ToList();

        public static int GetNumberOfAllPossible(int n) => Factorial.GetPrecalculated(n);


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
}