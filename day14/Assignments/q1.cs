//1: Define an abstract class called Shape with an abstract method Area(). Create two derived classes Circle and Rectangle that implement the Area() method for calculating the area of the respective shapes.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    abstract class Shape
    {
        public abstract double Area();
    }
    class Circle:Shape
    {
        private double radius;
        public Circle(double r)
        {
            radius = r;
        }
        public override double Area()=>Math.PI*radius*radius;
    }
    class Rectangle : Shape
    {
        private double length, width;
        public Rectangle(double l, double w)
        {
            length = l;
            width = w;
        }
        public override double Area()=>length*width;
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle(1);
            var rectangle = new Rectangle(1,2);

            Console.WriteLine($"Circle Area= {circle.Area()}");
            Console.WriteLine($"Rectangle Area = {rectangle.Area()}");
            
            
        }
    }
}
