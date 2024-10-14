/* Hospital Management System

Scenario:

Create a basic Hospital Management System in C# that tracks departments, doctors, and patients admitted to the hospital.

 
Requirements:

 
Implement functionality to manage:

Departments: Store a list of department names (e.g., "Cardiology", "Pediatrics", "Emergency").

Doctors: Each doctor belongs to a department. Store doctor names and associate them with the department they belong to.

Patients: Each doctor has a list of patients assigned to them. Store patient details (Name and Status of whether they are admitted or not) for each doctor.

Functionality:

 
Add new departments and assign doctors to specific departments.

Admit a patient to a doctor in a specific department.

List all doctors in a given department.

List all patients assigned to a particular doctor.

Discharge a patient (update the status to indicate they are no longer admitted).

Operations:

 
Adding departments, doctors, and patients.

Searching for doctors and patients.

Displaying information about departments, doctors, and patients

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {
        static List<string> departments = new List<string>();
        static List<Dictionary<string, object>> doctors = new List<Dictionary<string, object>>();
        static List<Dictionary<string, string>> patients = new List<Dictionary<string, string>>(); 
        static void AddDepartment()
        {
            Console.Write("Enter department name: ");
            string departmentName = Console.ReadLine();

            departments.Add(departmentName);
            Console.WriteLine($"Department '{departmentName}' added.");
        }

        static void AddDoctor()
        {
            Console.Write("Enter doctor's name: ");
            string doctorName = Console.ReadLine();

            Console.Write("Enter department name: ");
            string departmentName = Console.ReadLine();

            if (departments.Contains(departmentName))
            {
                var doctor = new Dictionary<string, object>();
                doctor.Add("doctorname", doctorName);
                doctor.Add("departmentName", departmentName);
                doctor.Add("patients", new List<string>());

                doctors.Add(doctor);
                Console.WriteLine($"Doctor '{doctorName}' added to '{departmentName}' department.");
            }
            else
            {
                Console.WriteLine($"Department '{departmentName}' not found.");
            }
        }

        static void AdmitPatient()
        {
            Console.Write("Enter doctor's name to admit patient: ");
            string doctorName = Console.ReadLine();

            
            Dictionary<string, object> doctor = null;
            foreach (var doc in doctors)
            {
                if (doc["doctorname"].ToString().ToLower() == doctorName.ToLower())
                {
                    doctor = doc;
                    break;
                }
            }

            if (doctor != null)
            {
                Console.Write("Enter patient's name: ");
                string patientName = Console.ReadLine();


                var patient = new Dictionary<string, string>();

                patient.Add("patientname",patientName);
                patient["status"] = "admitted";


                patients.Add(patient);

               
                var patientsList = (List<string>)doctor["patients"];
                patientsList.Add(patientName);

                Console.WriteLine($"Patient '{patientName}' admitted to doctor '{doctorName}'.");
            }
            else
            {
                Console.WriteLine($"Doctor '{doctorName}' not found.");
            }
        }

        static void ListDoctorsInDepartment()
        {
            Console.Write("Enter department name to list doctors: ");
            string departmentName = Console.ReadLine();

            if (departments.Contains(departmentName))
            {
                Console.WriteLine($"Doctors in '{departmentName}' department:");
                foreach (var doctor in doctors)
                {
                    if (doctor["departmentName"].ToString().ToLower() == departmentName.ToLower())
                    {
                        Console.WriteLine($"{doctor["doctorname"]}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Department '{departmentName}' not found.");
            }
        }

        static void ListPatientsForDoctor()
        {
            Console.Write("Enter doctor's name to list patients: ");
            string doctorName = Console.ReadLine();

            foreach (var doctor in doctors)
            {
                if (doctor["doctorname"].ToString().ToLower() == doctorName.ToLower())
                {
                    var patientsList = (List<string>)doctor["patients"];
                    if (patientsList.Count > 0)
                    {
                        Console.WriteLine($"Patients assigned to Dr. {doctorName}:");
                        foreach (var patient in patientsList)
                        {
                            Console.WriteLine($"{patient}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Dr. {doctorName} has no patients assigned.");
                    }
                    return; 
                }
            }
            Console.WriteLine($"Doctor '{doctorName}' not found.");
        }

        static void DischargePatient()
        {
            Console.Write("Enter patient's name to discharge: ");
            string patientName = Console.ReadLine();

            foreach (var patient in patients)
            {
                if (patient["patientName"].ToLower() == patientName.ToLower())
                {
                    patient["status"] = "discharged"; 
                    Console.WriteLine($"Patient '{patientName}' has been discharged.");
                    return;
                }
            }
            Console.WriteLine($"Patient '{patientName}' not found.");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. Add Department");
                Console.WriteLine("2. Add Doctor");
                Console.WriteLine("3. Admit Patient");
                Console.WriteLine("4. List Doctors in Department");
                Console.WriteLine("5. List Patients for Doctor");
                Console.WriteLine("6. Discharge Patient");

                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDepartment();
                        break;
                    case "2":
                        AddDoctor();
                        break;
                    case "3":
                        AdmitPatient();
                        break;
                    case "4":
                        ListDoctorsInDepartment();
                        break;
                    case "5":
                        ListPatientsForDoctor();
                        break;
                    case "6":
                        DischargePatient();
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }

}
