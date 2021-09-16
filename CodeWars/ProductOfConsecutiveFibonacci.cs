using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars
{
    [TestClass]
    public class ProductOfConsecutiveFibonacci
    {
        /*

        The Fibonacci numbers are the numbers in the following integer sequence (Fn):

        0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ...

        such as

        F(n) = F(n-1) + F(n-2) with F(0) = 0 and F(1) = 1.

        Given a number, say prod (for product), we search two Fibonacci numbers F(n) and F(n+1) verifying

        F(n) * F(n+1) = prod.

        Your function productFib takes an integer (prod) and returns an array:

        [F(n), F(n+1), true] or {F(n), F(n+1), 1} or (F(n), F(n+1), True)
        depending on the language if F(n) * F(n+1) = prod.

        If you don't find two consecutive F(n) verifying F(n) * F(n+1) = prodyou will return

        [F(n), F(n+1), false] or {F(n), F(n+1), 0} or (F(n), F(n+1), False)
        F(n) being the smallest one such as F(n) * F(n+1) > prod.

        Some Examples of Return:
        (depend on the language)

        productFib(714) # should return (21, 34, true), 
                        # since F(8) = 21, F(9) = 34 and 714 = 21 * 34

        productFib(800) # should return (34, 55, false), 
                        # since F(8) = 21, F(9) = 34, F(10) = 55 and 21 * 34 < 800 < 34 * 55
        -----
        productFib(714) # should return [21, 34, true], 
        productFib(800) # should return [34, 55, false], 
        -----
        productFib(714) # should return {21, 34, 1}, 
        productFib(800) # should return {34, 55, 0},        
        -----
        productFib(714) # should return {21, 34, true}, 
        productFib(800) # should return {34, 55, false}, 
        Note:
        You can see examples for your language in "Sample Tests".

         */

        [TestMethod]
        public void Tests()
        {
            var a = productFib(714);
            Assert.AreEqual(a[0], (ulong)21);
            Assert.AreEqual(a[1], (ulong)34);
            Assert.AreEqual(a[2], (ulong)1);
            var b = productFib(800);
            Assert.AreEqual(b[0], (ulong)34);
            Assert.AreEqual(b[1], (ulong)55);
            Assert.AreEqual(b[2], (ulong)0);

            //Assert.AreEqual(new ulong[3] { 21, 34, 1 }, productFib(714));  // since F(8) = 21, F(9) = 34 and 714 = 21 * 34
            //Assert.AreEqual(new ulong[3] { 34, 55, 0 }, productFib(800)); // since F(8) = 21, F(9) = 34, F(10) = 55 and 21 * 34 < 800 < 34 * 55
        }

        [TestMethod]
        public void Test()
        {
            // 0 1 1 2 3 5
            // 
            var fibs = GetFirst();
            var products = GetProducts(fibs);
        }

        public static ulong[] productFib(ulong prod)
        {
            var fibs = GetFirst();
            var products = GetProducts(fibs);
            var firstProd = products.First(p => p >= prod);
            var index = Array.IndexOf(products, firstProd);
            var result = new ulong[3] { fibs[index], fibs[index + 1], (ulong)(firstProd == prod ? 1 : 0) };
            return result;
        }

        public static ulong[] GetFirst()
        {
            var n = new List<ulong>() { 0, 1 };
            while (true)
            {
                checked
                {
                    try
                    {
                        var newFib = n[n.Count - 1] + n[n.Count - 2];
                        n.Add(newFib);
                    }
                    catch (OverflowException x)
                    {
                        return n.ToArray();
                    }
                }
            }
        }

        private static ulong[] GetProducts(ulong[] fibonacci)
        {
            var products = new List<ulong>();
            var index = 0;
            while (true)
            {
                checked
                {
                    try
                    {
                        var product = fibonacci[index] * fibonacci[index + 1];
                        products.Add(product);
                        index++;
                    }
                    catch (OverflowException x)
                    {
                        return products.ToArray();
                    }
                }
            }
        }

        /// <summary> Copied from CodeWars </summary>
        public static ulong[] productFib_Clever(ulong prod)
        {
            ulong[] result = { 0, 1, 0 };
            ulong next = 1;
            while (result[0] * result[1] < prod)
            {
                next = result[0] + result[1];
                result[0] = result[1];
                result[1] = next;
            }
            if (result[0] * result[1] == prod)
                result[2] = 1;
            return result;
        }
    }
}
