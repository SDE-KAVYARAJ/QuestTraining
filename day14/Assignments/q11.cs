// 11: Write a Predicate<int> that checks if a given integer is even.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q11
{
    internal class Program
    {
        static bool IsEven(int n) => n % 2 == 0;
        static void Main(string[] args)
        {
            Predicate<int>a = IsEven;
            var res = a(2);
            Console.WriteLine(res);

        }
    }
}
