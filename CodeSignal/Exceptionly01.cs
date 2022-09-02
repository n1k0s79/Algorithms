using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeSignal
{
    [TestClass]
    public class Exceptionly01
    {
        [TestMethod]
        public void Test()
        {
            var words = new string[] { "is", "valid", "right" };
            var varName = "isValid";
            var k = solution(words, varName);
        }

        bool solution(string[] words, string variableName)
        {
            for(var i = 0; i < words.Length; i++)
            {
                words[i] = words[i][0].ToString().ToUpperInvariant() + words[i].Substring(1);
            }
            
            var uvarName = variableName[0].ToString().ToUpperInvariant() + variableName.Substring(1);
            foreach(var uword in words)
            {
                uvarName = uvarName.Replace(uword, string.Empty);
            }
            return string.IsNullOrWhiteSpace(uvarName);
        }
    }
}
