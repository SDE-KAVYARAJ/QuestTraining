using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Studentsday11
{
    internal class Student
    {
        public string Name;
        public string RegisterNumber;
        public int classess;

        public List<marks>markslist=new List<marks>();
        public override string ToString()
        {
            return $"StudentName: {Name}, CardNumber: {RegisterNumber}, Classes:{classess}";
        }
    }
   
}
