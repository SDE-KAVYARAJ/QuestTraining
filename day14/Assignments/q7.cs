// 7: Define a Func<int, int, int> delegate that takes two integers as parameters and returns their sum.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q7
{
    internal class Program
    {
        static int Add(int x, int y)=>x+y;
        static void Main(string[] args)
        {
            Func<int,int,int>sum=Add;
            var res = sum(1, 2);
            Console.WriteLine("sum = "+res);
        }
    }
}
