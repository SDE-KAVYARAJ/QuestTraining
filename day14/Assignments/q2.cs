// 2: Create an abstract class Vehicle with a property Speed and an abstract method Drive(). Implement the Drive() method in two derived classes Car and Bicycle.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q2
{
    internal class Program
    {
        abstract class Vehicle
        {
            public int Speed {  get; set; }
            public abstract void Drive();
        }
        class Car : Vehicle
        {
            public override void Drive() => Console.WriteLine($"Car is driving at {Speed}");
        }
        class Bicycle : Vehicle
        {
            public override void Drive()=> Console.WriteLine($"Bicycle is at the speed of {Speed}");

        }
        static void Main(string[] args)
        {
            //Vehicle car= new Car{ Speed=100};
            Vehicle car = new Car();
            car.Speed = 100;
            car.Drive();

            Vehicle bicycle= new Bicycle { Speed = 50 };
            bicycle.Drive();
        }
    }
}
