using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    // 21/3/2023 

    /*
     * Davis has a number of staircases in his house and he likes to climb each staircase , , or  steps at a time. Being a very precocious child, he wonders how many ways there are to reach the top of the staircase.

Given the respective heights for each of the  staircases in his house, find and print the number of ways he can climb each staircase, module  on a new line.

Example


The staircase has  steps. Davis can step on the following sequences of steps:

1 1 1 1 1
1 1 1 2
1 1 2 1 
1 2 1 1
2 1 1 1
1 2 2
2 2 1
2 1 2
1 1 3
1 3 1
3 1 1
2 3
3 2
There are  possible ways he can take these  steps and 

Function Description

Complete the stepPerms function using recursion in the editor below.

stepPerms has the following parameter(s):

int n: the number of stairs in the staircase
Returns

int: the number of ways Davis can climb the staircase, modulo 10000000007
Input Format

The first line contains a single integer, , the number of staircases in his house.
Each of the following  lines contains a single integer, , the height of staircase .

Constraints

Subtasks

 for  of the maximum score.
Sample Input

STDIN   Function
-----   --------
3       s = 3 (number of staircases)
1       first staircase n = 1
3       second n = 3
7       third n = 7
Sample Output

1
4
44
Explanation

Let's calculate the number of ways of climbing the first two of the Davis'  staircases:

The first staircase only has  step, so there is only one way for him to climb it (i.e., by jumping  step). Thus, we print  on a new line.
The second staircase has  steps and he can climb it in any of the four following ways:
Thus, we print  on a new line.
     */
    [TestClass]
    public class DavisStaircase
    {
        [TestMethod]
        public void Test()
        {
            var a = stepPerms(36);
            //var l = new List<int>();            
            //for (var i = 1; i <=20; i++)
            //{
            //    var w = stepPerms(i);
            //    l.Add(w);
            //    //var m = GetWaysM(i);
            //}
            var j = 1;
        }

        // τα βήματα:
        // πρώτα ξεκίνησα να βρίσκω διατάξεις. Σκέφτηκα ότι θα μπορούσα να αθροίσω τα νούμερα και να βλέπω αν μία διάταξη μου κάνει
        // όμως είδα ότι αυτό δεν είναι αποδοτική λύση
        public static IEnumerable<IEnumerable<T>> GetPerms<T>(IEnumerable<T> items, int? length = null)
        {
            if (!length.HasValue) length = items.Count();
            return length == 1 ? items.Select(i => new T[] { i }) : GetPerms(items, length - 1).SelectMany(l => items.Except(l), (l, i) => l.Concat(new T[] { i }));
        }

        // μετά παρατήρησα ότι για το βήμα Ν οι λύσεις είναι 1 + λύσεις (Ν - 1) + 2 + λύσεις (Ν - 2) + 3 + λύσεις (Ν - 3)
        // και έφτιαξα αυτό
        public static IEnumerable<IEnumerable<int>> GetSum(int sum)
        {
            if (sum == 3) return new List<List<int>>() { new List<int>() { 1, 1, 1 }, new List<int>() { 1, 2 }, new List<int>() { 2, 1 }, new List<int>() { 3 }, };
            if (sum == 2) return new List<List<int>>() { new List<int>() { 1, 1 }, new List<int>() { 2 } };
            if (sum == 1) return new List<List<int>>() { new List<int>() { 1 } };

            var lists = new List<List<int>>();
            foreach (int i in new int[] { 1, 2, 3 })
            {
                var l = new List<int>() { i };
                var rest = GetSum(sum - i);
                foreach (var o in rest)
                {
                    var d = l.Concat(o).ToList();
                    lists.Add(d);
                }
            }
            return lists;
        }

        // μετά είδα ότι το πρόβλημα δεν ενδιαφέρεται για τις διατάξεις αυτές καθ' αυτές αλλά μόνο για το πλήθος τους και έφτιαξα αυτό:
        public static int stepPerms(int n)
        {
            if (n < 3) return n;
            else if (n == 3) return 4;
            else
            {
                if (cache.ContainsKey(n)) return cache[n];
                var result = new int[] { 1, 2, 3 }.Sum(i => stepPerms(n - i));
                cache[n] = result;
                return result;
            }
        }

        // αλλά αργούσε πολύ
        // μετά διάβασα σε μία άλλη λύση την πολύ απλή ιδέα του cache (την οποία όμως δεν την είχα σκεφθεί)
        private static Dictionary<int, int> cache = new Dictionary<int, int>();
    }
}