// 10: Create an Action<int, int> delegate that takes two integers and prints their sum.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q10
{
    internal class Program
    {
        static void Add(int a, int b) => Console.WriteLine("sum="+(a+b));
        static void Main(string[] args)
        {
            Action<int, int> a = Add;
            a(1,2);
        }
    }
}

