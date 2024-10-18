// 6: Create a delegate PrintMessage that takes a string as a parameter. Write a method DisplayMessage that prints the string passed to it. Use the delegate to call DisplayMessage.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q6
{
    

    internal class Program
    {

       delegate void PrintMessage(string message);
       static void DisplayMessage(string message) => Console.WriteLine(message);
       static void Main(string[] args)
       {
          
            PrintMessage pm = DisplayMessage;
            pm("Hello");

       }
    }
}
