using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Interviews.Betsson.Question5
{
    // Την απάντησα λάθος
    // H μέθοδος Α μπορεί να κληθεί και από τις δύο
    // η μέθοδος είναι sealed το οποίο σημαίνει ότι δε μπορεί να γίνει override

    public abstract class ClassA 
    {
        protected abstract void MethodA();
    }

    public class ClassB : ClassA
    {
        public ClassB()
        {
            MethodA();
        }

        protected sealed override void MethodA()
        {
        }
    }

    public class ClassC : ClassB
    {
        public ClassC()
        {
            MethodA();
        }
    }

    [TestClass]
    public class Question5
    {
        [TestMethod] 
        public void Test()
        {
            var c = new ClassC();
            var b = new ClassB();            
        }
    }
}
