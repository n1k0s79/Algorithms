using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Interviews.Betsson.Question6
{
    // Την απάντησα λάθος
    // η σωστή απάντηση είναι 3
    // πριν τον instance constructor τρέχει ο static constructor
    // πότε καλείται ο static constructor;
    // πριν από την πρώτη αναφορά στην κλάση
    [TestClass]
    public class Question7
    {
        [TestMethod] 
        public void Test()
        {
            var numberProvider = new NumberProvider(5);            
            Console.WriteLine($"Number = {numberProvider.GetNumber()}");
            Console.ReadKey();
        }

        class NumberProvider
        {
            private static int _number;
            static NumberProvider()
            {
                if (_number == 0)
                {
                    _number = 2;
                }
            }

            public NumberProvider(int number)
            {
                if (_number == 0)
                {
                    _number = number;
                }
            }

            public int GetNumber()
            {
                if (_number++ == 5)
                {
                    _number = 10;
                }
                return _number;
            }
        }
    }
}
