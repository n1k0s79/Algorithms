// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

try
{
    Car ford = null;
    var engine = ford.Engine;
}
catch (ArgumentException exception)
{
    var message = exception.Message;
}
catch (Exception exception)
{
    var message = exception.Message;
}

Console.WriteLine("Reached here");

//var myCar = new Car(Drive);
//static string Drive(double averageSpeed, double topSpeed)
//{
//    return "too fast!";
//}


















//var myCar = new Car();
//var builder = new CarBuilder();
//var myOtherCar = builder.Build();

var i = int.MaxValue;

var numbers = GetNumbers();
var i1 = numbers.First();
var i2 = numbers.Skip(1).First();

//var myCar = new Car(CarType.Sedan) { Make = "Ford" };
//var otherCar = new Car(CarType.Electric);

//var comparison = myCar == otherCar;
//var cars = new List<Car>();

//foreach(var car in cars)
//{
//    // do stuff
//}

//for (int i = 0; i < cars.Count; i++)
//{
//    // do stuff
//}

static IEnumerable<int> GetNumbers()
{
    yield return 1;
    yield return 2;
    yield return 3;
    yield return 4;
    yield return 5;
}

//class Car
//{
//    public string Make { get; init; }

//    public Car(CarType type)
//    {
//        int a = (int)type;
//        CarType t = (CarType)1;
//        //Make = make;
//    }


//}
