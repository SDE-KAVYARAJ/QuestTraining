using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERFACE
{
    internal class SchoolStudent:IStudent
    {
        public string Name {  get; set; }
        public const string SchoolName = "x";

        
        public void Display()
        {
            Console.WriteLine($"student name: {Name} | school name:{SchoolName}");
        }
    }
}
