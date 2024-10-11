/* You are tasked with developing a simple patient diagnosis management system for a small medical clinic. The system needs to store patient information and track the symptoms they are diagnosed with.
Requirements:
Store patient information using a structure where each patient has the following details:
A unique identifier.
Their name.
Their age.
A list of symptoms they have reported.
Implement the following functionalities:
AddPatient: A function that adds a new patient’s information to the system.
GetPatient: A function that retrieves the details of a patient based on their unique identifier.
GetPatientsBySymptom: A function that returns the identifiers of all patients who have reported a specific symptom.
has context menu*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis
{
    internal class Program
    {
        static List<Dictionary<string, string>> patients = new List<Dictionary<string, string>>();

        
        static void AddPatient()
        {
            var patient = new Dictionary<string, string>();

            Console.WriteLine("Enter patient name:");
            patient.Add("name", Console.ReadLine());

            Console.WriteLine("Enter patient age:");
            patient.Add("age", Console.ReadLine());

            Console.WriteLine("Enter symptoms as comma-separated values:");
            patient.Add("symptoms", Console.ReadLine());

           
            var id = Guid.NewGuid().ToString();
            patient.Add("ID", id);
            patients.Add(patient);

            Console.WriteLine($"Patient added successfully! ID: {id}");
        }

        
        static void GetPatientById()
        {
            Console.WriteLine("Enter patient ID:");
            var id = Console.ReadLine();

            var patient = patients.Find(p => p["ID"] == id);
            if (patient != null)
            {
                Console.WriteLine("Patient found:");
                foreach (var detail in patient)
                {
                    Console.WriteLine($"{detail.Key}: {detail.Value}");
                }
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        
        static void GetPatientsBySymptom()
        {
            Console.WriteLine("Enter the symptom to search:");
            var symptom = Console.ReadLine();

            
            var matchedPatients = new List<Dictionary<string, string>>();

            foreach (var patient in patients)
            {
                if (patient.ContainsKey("symptoms") && patient["symptoms"].Contains(symptom))
                {
                    matchedPatients.Add(patient);
                }
            }

            if (matchedPatients.Count > 0)
            {
                Console.WriteLine($"Patients with symptom '{symptom}':");
                foreach (var patient in matchedPatients)
                {
                    Console.WriteLine($"ID: {patient["ID"]}, Name: {patient["name"]}, Age: {patient["age"]}");
                }
            }
            else
            {
                Console.WriteLine($"No patients found with symptom '{symptom}'.");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add patient");
                Console.WriteLine("2. Search patient by ID");
                Console.WriteLine("3. Get patients by symptom");
                Console.WriteLine("4. Exit");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        AddPatient();
                        break;
                    case "2":
                        GetPatientById();
                        break;
                    case "3":
                        GetPatientsBySymptom();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}
    

