using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Studentsday11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var student = new StudentManaging();

            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Mark");
                Console.WriteLine("3. Search");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var details = GetStudentData();
                        student.Add(details);
                        break;
                    case "2":
                        Console.WriteLine("Enter Register number");
                        var regNumber= Console.ReadLine();
                        var markdetails = GetMark();
                        student.AddMarks(regNumber,markdetails);
                        break;

                    case "3":
                        Console.Write("Enter the number to search: ");
                        var RegNumber = Console.ReadLine();
                        student.Search(RegNumber);
                        break;
                    case "4":
                        var studentToUpdate = GetStudentData();
                        student.Update(studentToUpdate.Name,
                            studentToUpdate.RegisterNumber,
                            studentToUpdate.classess);
                        break;

                    case "5":
                        Console.Write("Enter the number to delete: ");
                        var studentNumberToDelete = Console.ReadLine();
                        student.Delete(studentNumberToDelete);
                        break;


                }
            }
        }
        private static Student GetStudentData()
        {
            Student details = new Student();

            Console.Write("Enter the student name: ");
            details.Name = Console.ReadLine();

            Console.Write("Enter register number : ");
            details.RegisterNumber = Console.ReadLine();

            Console.Write("Enter the class: ");
            details.classess = int.Parse(Console.ReadLine());

            return details;
        }

        private static marks GetMark()
        {
            marks markdetails = new marks();

            Console.Write("Enter the student name: ");
            markdetails.subject = Console.ReadLine();

            Console.Write("Enter the student mark: ");
            markdetails.markobtained = int.Parse(Console.ReadLine());

            Console.Write("Enter the max mark: ");
            markdetails.maxmark= int.Parse(Console.ReadLine());

            return markdetails;
        }
    }
}
