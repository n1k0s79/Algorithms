using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toptal
{
    [TestClass]
    public class Task3_Prefix_Suffix
    {
        [TestMethod]
        public void TestSolution()
        {
            var s = new Solution();
            //Assert.AreEqual(0, s.solution("abndf"));

            // my solution with prefix sums fails for test case "abba"

            // solution1 is correct but its complexity is not O(n)

            Assert.AreEqual(1, s.solution1("abba"));
        }
    }

    class Solution
    {
        public int solution(string S)
        {
            var prefSums = new int[S.Length];
            int sum = 0;
            for (int i = 0; i < S.Length; i++)
            {
                var c = S[i];
                sum += c;
                prefSums[i] = sum;
            }

            int maxLength = 0;
            int middle = (S.Length / 2) + 1;
            for (int length = 1; length <= middle; length++)
            {
                var a = GetPrefixSum(prefSums, length);
                var b = GetSuffixSum(prefSums, length);
                if (a == b)
                {
                    if (length > maxLength) maxLength = length;
                }
            }

            return maxLength;
        }

     
        public int solution1(string S)
        {
            int maxLength = 0;

            int middle = (S.Length / 2) + 1;
            for (int length = 1; length <= middle; length++)
            {
                var prefix = S.Substring(0, length);
                var suffix = S.Substring(S.Length - length);

                if (prefix == suffix)
                {
                    if (length > maxLength) maxLength = length;
                }
            }

            return maxLength;
        }

        public int solution2(string S)
        {
            var prefSums = new int[S.Length];
            int sum = 0;
            for (int i = 0; i < S.Length; i++)
            {                
                var c = S[i];
                sum += c;
                prefSums[i] = sum;
            }

            int maxLength = 0;
            int middle = (S.Length / 2) + 1;
            for (int length = 1; length <= middle; length++)
            {
                var a = GetPrefixSum(prefSums, length);
                var b = GetSuffixSum(prefSums, length);
                if (a == b)
                {
                    // one additional check to make sure that the two strings not only have the same sum but that the characters are also in the same positions
                    var prefix = S.Substring(0, length);
                    var suffix = S.Substring(S.Length - length);
                    if (prefix == suffix)
                    {
                        if (length > maxLength) maxLength = length;
                    }
                }
            }

            return maxLength;
        }

        private int GetPrefixSum(int[] prefSums, int prefixLength)
        {
            return prefSums[prefixLength - 1];
        }

        private int GetSuffixSum(int[] prefSums, int suffixLength)
        {
            int lastIndex = prefSums.Length - 1;
            int prevIndex = lastIndex - suffixLength;
            return prefSums[lastIndex] - prefSums[prevIndex];
        }
    }
}