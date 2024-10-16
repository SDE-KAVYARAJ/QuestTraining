using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentsday11
{
    internal class StudentManaging
    {

        private List<Student> studentsList = new List<Student>();

        public void Add(Student details)
        {
            
            foreach (var item in studentsList)
            {
                if (item.Name == details.Name)
                {
                    Console.WriteLine("student already exists");
                    return;
                }
            }
            studentsList.Add(details);
            Console.WriteLine("Added successfully");
        }

        public void AddMarks(string regNumber,marks markdetails)
        {
            var student = GetStudentByNumber(regNumber);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            student.markslist.Add(markdetails);
            Console.WriteLine("Marks added successfully.");
        }
        public void Search(string RegNumber)
        {
            var details=GetStudentByNumber(RegNumber);
            Console.WriteLine(details);
        }

        public void Update(string Name,string RegNumber,int classess)
        {
            var details= GetStudentByNumber(RegNumber);
            if (details == null)
            {
                Console.WriteLine("Student not found");
                return;
            }
            details.Name = Name;
            details.RegisterNumber = RegNumber;
            details.classess=classess;

            Console.WriteLine(details);

        }

        public void Delete(string RegNumber)
        {
            var details = GetStudentByNumber(RegNumber);
            if (details == null)
            {
                Console.WriteLine("student not found");
                return;
            }

            studentsList.Remove(details);
            Console.WriteLine("Deleted successfully");
        }


        private Student GetStudentByNumber(string RegNumber)
        {
            // Check if the same student exists.
            foreach (var details in studentsList)
            {
                if (details.RegisterNumber == RegNumber)
                {
                    return details;
                }
            }
            return null;
        }
    }
}
