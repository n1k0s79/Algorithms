using System.Dynamic;
using System.Runtime.InteropServices;

namespace Runner
{
    class Program
    {
        public enum CarType
        {
            Sedan,
            SUV,
            Electric
        }

        //class Car
        //{
        //    public string Make { get; init; }

        //    public Car(CarType type, string make)
        //    {
        //        int a = (int)type;
        //        CarType t = (CarType)1;
        //        Make = make;
        //    }
        //}            

        static void Main(string[] args)
        {
            const int DaysOffPerYear = 15;
            var yearsOfWork = 3;
            var daysOff = yearsOfWork * DaysOffPerYear;
            
            //var myCar = new Car(CarType.Sedan, "Ford");
            //myCar.Make = "Ford";
            //myCar.Make = "Toyota";

            //var myCarMake = myCar.Make;

            //var radius = 5;
            //var perimeter = 3.14 * radius * 2;

            //ArrayList l = new ArrayList();
            //l.Add(a);
            //l.Add(new )

            //var test = Stelios.MultiplicationValidator.Validate(87652892, 982345);

            //const int max = 1000;
            //long counter = 0;
            //long total = max * max;

            //for(int a = 1; a < max; a++)
            //    for (int b = 1; b < max; b++)
            //    {
            //        counter++;
            //        var percent = (double)counter / (double)total * (double)100;
            //        var v = Stelios.MultiplicationValidator.Validate(a, b);
            //        if (!v) throw new Exception(a.ToString() + "," + b.ToString());
            //    }
        }
    }
}