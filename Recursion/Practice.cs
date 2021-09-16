using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Recursion
{
    [TestClass]
    public class Practice
    {
        [TestMethod]
        public void TestMethod1()
        {
            var j = Factorial(5);
            var jj = SumOfDigits(12345);
            string output = string.Empty;
            Reverse("Nikos", ref output);
        }

        // 1. Write a recursive implementation of the factorial function. Recall that n! = 1 × 2 × … × n, with the special case that 0! = 1.
        private static int Factorial(int n)
        {
            if (n == 0) return 1;
            if (n == 1) return 1;
            var inner = Factorial(n - 1);
            var product = n * inner;
            return product;
        }

        // 2. Write a recursive function that, given a number  n, returns the sum of the digits of the number n.
        private static int SumOfDigits(int n)
        {
            var s = n.ToString();
            if (s.Length == 1) return (int)System.Char.GetNumericValue(s[0]);
            var headValue = (int)System.Char.GetNumericValue(s[0]);
            var tailSum = SumOfDigits(int.Parse(s.Substring(1)));
            return headValue + tailSum;
        }

        // 3. Write a recursive function that, given a string s, prints the characters of s in reverse order.
        private static void Reverse(string s, ref string reversed)
        {
            if (string.IsNullOrWhiteSpace(s)) return;
            Reverse(s.Substring(1), ref reversed);
            reversed += s[0];
        }
    }
}


//Warm­Ups

//4. Write a recursive function that checks whether a string is a palindrome (a palindrome is
//a string that's the same when reads forwards and backwards.)
//5. Write a recursive function that, given a pointer to the root of a binary search tree, prints
//out the elements in that tree in sorted order.
//6. Write a recursive function that, given two strings, returns whether the first string is a
//subsequence of the second. For example, given hac and cathartic, you should return true,
//but given bat and table, you should return false.
