// 12: Create a Predicate<string> that checks if a given string starts with the letter 'A'.
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q12
{
    internal class Program
    {
        static bool startA(string message)=> message.StartsWith("A");
        
        static void Main(string[] args)
        {
            Predicate<string>a=startA;
            var res = a("Apple");
            Console.WriteLine(res);
        }
    }
}
