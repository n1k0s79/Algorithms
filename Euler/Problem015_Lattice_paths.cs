using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Text;

namespace Euler
{  
    [TestClass]
    public class Problem015_Lattice_paths
    {            
        [TestMethod]
        public void TestSolution()
        {
            Assert.AreEqual(137846528820, Math.LatticePaths.Calculate(20));
            // a route can be denoted with the direction at each step: Up or Right:
            // URURRUR
            // to go to position [m,n] I will always need m ups and n rights
            Assert.AreEqual(137846528820, Math.Combination.GetNumberOfAllPossible(40, 20));
        }
    }
}