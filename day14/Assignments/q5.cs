// 5: Define a delegate Operation that takes two integers as parameters. Write methods Add and Multiply that match this delegate signature. Demonstrate how to use the delegate to call these methods.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q5
{
    internal class Program
    {
        delegate int Operation(int a, int b);
        static int Add(int a, int b)=>a+b;
        static int Multiply(int a, int b)=>a* b;
        static void Main(string[] args)
        {
            Operation op = Add;
            Console.WriteLine($"Addition = "+op(1,2));

            op=Multiply;
            Console.WriteLine($"Subtraction = "+op(1,2));
        }
    }
}
