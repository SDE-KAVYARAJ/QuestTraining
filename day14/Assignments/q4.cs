//4: Write an interface ICalculator that has methods Add(int a, int b) and Subtract(int a, int b). Implement this interface in a SimpleCalculator class.
//Interface
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q4
{
    internal interface ICalculator
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
    }
}
//class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q4
{
    internal class Program
    {
        class SimpleCalculator : ICalculator
        {
            public int Add(int a, int b) => a + b;
            public int Subtract(int a, int b) =>a-b;
        }
        static void Main(string[] args)
        {
            //SimpleCalculator c = new SimpleCalculator();

            var calculator= new SimpleCalculator();

            //c.Add(1, 2);
            //c.Subtract(1, 2);


            Console.WriteLine("Addition = "+calculator.Add(1,2));
            Console.WriteLine("Subtraction = " + calculator.Subtract(1, 2));
        }
    }
}

