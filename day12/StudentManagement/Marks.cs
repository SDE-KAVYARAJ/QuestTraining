using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Studentsday11
{
    internal class marks
    {
        public string subject;
        public int markobtained;
        public int maxmark;

        public override string ToString()=>$"subject name:{subject},markobtained:{markobtained},maxmark:{maxmark}";
        

    }
}
