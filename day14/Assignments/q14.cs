// 14: Create an abstract class Person with an abstract method Work(). Implement Work() in derived classes Doctor and Engineer to describe their specific jobs.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q14
{
    abstract class Person
    {
        public abstract void Work();
    }
    class Doctor:Person
    {
        public override void Work() => Console.WriteLine("Doctor is treating Patients");
    }
    class Engineer : Person
    {
        public override void Work() => Console.WriteLine("Engineer is Designing solutions");
    }
   

    internal class Program
    {
        static void Main(string[] args)
        {
            var engineer=new Engineer();
            engineer.Work();

            var doctor=new Doctor();
            doctor.Work();
            
        }
    }
}
