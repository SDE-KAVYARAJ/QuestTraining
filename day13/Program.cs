using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERFACE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStudent ss= new SchoolStudent();
            ss.Name = "kavya";
            ss.Display();

        }
    }
}
