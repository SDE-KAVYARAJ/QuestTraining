using Assessment2.Models;
using Assessment2.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kavya\OneDrive\Documents\QuestDB.mdf;Integrated Security=True;Connect Timeout=30";

            var connection = new SqlConnection(connectionString);
            {
                connection.Open();

                var createTableQuery = @"CREATE TABLE Patients (
                                       Id INT PRIMARY KEY IDENTITY(1, 1),
                                       Name NVARCHAR(100),
                                       Age INT,
                                       Gender NVARCHAR(10),
                                       MedicalCondition NVARCHAR(200))";

                var command = new SqlCommand(createTableQuery, connection);

                var createDoctorTableQuery = @"CREATE TABLE Doctors (
                                             Id INT PRIMARY KEY IDENTITY(1, 1),
                                             Name NVARCHAR(100),
                                             Specialization NVARCHAR(100),
                                             PatientId INT NULL, -- Nullable field for assigning a patient
                                             CONSTRAINT FK_Doctor_Patient FOREIGN KEY (PatientId) REFERENCES Patients(Id))";

                var command1 = new SqlCommand(createDoctorTableQuery, connection);
                command1.ExecuteNonQuery();

                IPatientService patientService = new PatientService(connection);
                IDoctorService doctorService = new DoctorService(connection);


                while (true)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Add Patient");
                    Console.WriteLine("2. View Patients");
                    Console.WriteLine("3. Add Doctor");
                    Console.WriteLine("4. View Doctors");
                    Console.WriteLine("5. Update Patient Medical Condition");
                    Console.WriteLine("6. Update Doctor Specialization");
                    Console.WriteLine("7. Delete Patient");
                    Console.WriteLine("8. Delete Doctor");
                    Console.WriteLine("9. Exit");
                    Console.Write("Enter your choice: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            // Add Patient
                            var newPatient = new Patient();
                            Console.Write("Enter Patient Name: ");
                            newPatient.Name = Console.ReadLine();
                            Console.Write("Enter Patient Age: ");
                            newPatient.Age = int.Parse(Console.ReadLine());
                            Console.Write("Enter Patient Gender: ");
                            newPatient.Gender = Console.ReadLine();
                            Console.Write("Enter Patient Medical Condition: ");
                            newPatient.MedicalCondition = Console.ReadLine();
                            patientService.AddPatient(newPatient);
                            Console.WriteLine("Patient added successfully!\n");
                            break;

                        case "2":
                            // View Patients
                            var patients = patientService.GetAllPatients();
                            Console.WriteLine("Patients:");
                            foreach (var patient in patients)
                            {
                                Console.WriteLine($"{patient.Id}: {patient.Name}, Age: {patient.Age}, Gender: {patient.Gender}, Condition: {patient.MedicalCondition}");
                            }
                            Console.WriteLine();
                            break;

                        case "3":
                            // Add Doctor
                            var newDoctor = new Doctor();
                            Console.Write("Enter Doctor Name: ");
                            newDoctor.Name = Console.ReadLine();
                            Console.Write("Enter Doctor Specialization: ");
                            newDoctor.Specialization = Console.ReadLine();
                            doctorService.AddDoctor(newDoctor);
                            Console.WriteLine("Doctor added successfully!\n");
                            break;

                        case "4":
                            // View Doctors
                            var doctors = doctorService.GetAllDoctors();
                            Console.WriteLine("Doctors:");
                            foreach (var doctor in doctors)
                            {
                                Console.WriteLine($"{doctor.Id}: {doctor.Name}, Specialization: {doctor.Specialization}, PatientId: {doctor.PatientId}");
                            }
                            Console.WriteLine();
                            break;

                        case "5":
                            // Update Patient Medical Condition
                            Console.Write("Enter Patient ID to update: ");
                            int patientIdToUpdate = int.Parse(Console.ReadLine());
                            var patientToUpdate = new Patient { Id = patientIdToUpdate };
                            Console.Write("Enter new Medical Condition: ");
                            patientToUpdate.MedicalCondition = Console.ReadLine();
                            patientService.UpdatePatient(patientToUpdate);
                            Console.WriteLine("Patient medical condition updated successfully!\n");
                            break;

                        case "6":
                            // Update Doctor Specialization
                            Console.Write("Enter Doctor ID to update: ");
                            int doctorIdToUpdate = int.Parse(Console.ReadLine());
                            var doctorToUpdate = new Doctor { Id = doctorIdToUpdate };
                            Console.Write("Enter new Specialization: ");
                            doctorToUpdate.Specialization = Console.ReadLine();
                            doctorService.UpdateDoctor(doctorToUpdate);
                            Console.WriteLine("Doctor specialization updated successfully!\n");
                            break;

                        case "7":
                            // Delete Patient
                            Console.Write("Enter Patient ID to delete: ");
                            int patientIdToDelete = int.Parse(Console.ReadLine());
                            patientService.DeletePatient(patientIdToDelete);
                            Console.WriteLine("Patient deleted successfully!\n");
                            break;

                        case "8":
                            // Delete Doctor
                            Console.Write("Enter Doctor ID to delete: ");
                            int doctorIdToDelete = int.Parse(Console.ReadLine());
                            doctorService.DeleteDoctor(doctorIdToDelete);
                            Console.WriteLine("Doctor deleted successfully!\n");
                            break;

                        case "9":
                            // Exit
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice! Please try again.\n");
                            break;
                    }
                }
            }

        }    
    }
}


        
    

