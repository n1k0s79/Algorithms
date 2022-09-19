using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Interviews.Betsson.Question4
{
    // την απάντησα λάθος
    // η Β θα τρέξει πιο αργά
    // υπέθεσα ότι ο compiler κάνει κάποια εξυπνάδα με το type inference. Όμως όχι
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing
    [TestClass]
    public class Question4
    {

        [TestMethod]
        public void Test()
        {
            var time1 = Util.Timer.Measure(MethodA, 100_000_000);
            var time2 = Util.Timer.Measure(MethodB, 100_000_000);
            Assert.AreEqual(time1, time2);
        }

        public void MethodA()
        {
            int i = 123; // στη στοίβα            
            var a = i;   // δημιουργείται μία νέα μεταβλητή στη στοίβα η οποία παίρνει την ίδια τιμή (123)
        }

        /// <summary>
        /// Αυτή θα τρέξει πιο αργά γιατί κάνει κυτιοποίηση (boxing)
        /// </summary>
        public void MethodB()
        {
            int i = 123;
            object a = i;  // δημιουργείται μία νέα μεταβλητή στο σωρό (boxing)
        }

        [TestMethod]
        // παρατήρησα όμως ότι κάνοντας GetType στην κυτιοποιημένη μεταβλητή παίρνω int. Γιατί;
        // μα τι λέω; Σωστό είναι. Αφού είναι int...
        public void TypeOfBoxedVariable()
        {
            int i = 123;
            object a = i;
            var ta = a.GetType();
            object b = 1;
            var tb = b.GetType();
        }
    }
}
