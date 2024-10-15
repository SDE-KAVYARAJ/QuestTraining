using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class Student
    {
        public string name;
    
        public void display()
        {
            Console.WriteLine(name.ToUpper());
        
        }
    
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.name = "kavya";
            s.display();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class Student
    {
        public string Name;
        public int Mark1;
        public int Mark2;
        public int Mark3;

        public void TotalMark()
        {
            int sum = Mark1 + Mark2 + Mark3;
            Console.WriteLine($"total mark {sum}");

        }

        public void AverageMark()
        {
            int avg = (Mark1 + Mark2 + Mark3)/3;
            Console.WriteLine($"average mark {avg}");
        }
    
    }

    internal class Program
    {
        public static void Main(String[] args) 
        {
        Student student1 = new Student();
        student1.Mark1 = 1;
        student1.Mark2 = 2;
        student1.Mark3 = 3;
        student1.TotalMark();
        student1.AverageMark();

        Student student2 = new Student();
        student2.Mark1 = 10;
        student2.Mark2 = 20;
        student2.Mark3 = 30;
        student2.TotalMark();
        student2.AverageMark();


        }
       
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class SmartPhone
    {
        public string Name;
        public string Brand;
        public List<int> Storage;

        public void display()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Brand);
            Console.WriteLine(string.Join(",",Storage));
        }

    }


    internal class Program
    {
        public static void Main(String[] args) 
        {
        
            SmartPhone phone1 = new SmartPhone();
            phone1.Name = "mob1";
            phone1.Brand = "vivo";
            phone1.Storage = new List<int> { 16, 32, 64 };
            phone1.display();

            var phone2 = new SmartPhone()
            {
                Name = "mob2",
                Brand="apple",
                Storage=new List<int> { 2,8,16}

            };
            phone2.display();


        }
       
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class Calculator
    {
        public int Num1;
        public int Num2;
        public int Result;

        public void Add()
        {
            Result=Num1+Num2;
            Console.WriteLine("addition ="+Result);
            
        }

        public void Mul()
        {
            Result = Num1 * Num2;
            Console.WriteLine("multiplication =" + Result);

        }

        public void Div()
        {
            Result = Num1 / Num2;
            Console.WriteLine("division=" + Result);

        }

        public void Sub()
        {
            Result = Num1 - Num2;
            Console.WriteLine("subtraction=" + Result);

        }
    }

    internal class Program
    {
        public static void Main(String[] args) 
        {
        
            Calculator cal = new Calculator();
            cal.Add();
            cal.Mul();
            cal.Div();
            cal.Sub();
        }
       
    }
}



