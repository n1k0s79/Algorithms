namespace Generics
{
    [TestClass]
    public class Generics
    {
        [TestMethod]
        public void Test()
        {
            // Assignment compatibility.
            string str = "test";
            // An object of a more derived type is assigned to an object of a less derived type.
            object obj = str;

            // Covariance.
            IEnumerable<string> strings = new List<string>();
            // An object that is instantiated with a more derived type argument
            // is assigned to an object instantiated with a less derived type argument.
            // Assignment compatibility is preserved.
            IEnumerable<object> objects = strings;

            // Contravariance.
            // Assume that the following method is in the class:
            static void SetObject(object o) { }
            Action<object> actObject = SetObject;
            // An object that is instantiated with a less derived type argument
            // is assigned to an object instantiated with a more derived type argument.
            // Assignment compatibility is reversed.
            Action<string> actString = actObject;
        }
    }
}