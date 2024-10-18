// 9: Define an Action<string> delegate that prints a string to the console. Use this delegate to call a method that prints a welcome message.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q9
{
    internal class Program
    {
        static void Greet(string message) => Console.WriteLine(message);
        static void Main(string[] args)
        {
            Action<string> gm = Greet;
            gm("welcome");
        }
    }
}
