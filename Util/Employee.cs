using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    class Employee
    {
        public int Id { get; init; }

        public Employee()
        {
            int age = 40;
            var height = 186;
            object employeeAge = age;
            int a = (int)employeeAge;
            var k = new ArrayList();
        }

        public void Outer(int a)
        {
            Inner(a);
        }

        private void Inner(int b) 
        {
            Innermost(b);
        }

        private void Innermost(int c)
        {
        }

        private IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}