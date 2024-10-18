// 8: Write a Func<string, int> delegate that takes a string as input and returns the length of the string.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace q8
{
    internal class Program
    {
        static  int StringLength(string s)
        {
            return s.Length;
        }
        static void Main(string[] args)
        {
            Func<string,int>length=StringLength;
            var res=length("Kavya");
            Console.WriteLine("string length = "+res);
        }
    }
}
