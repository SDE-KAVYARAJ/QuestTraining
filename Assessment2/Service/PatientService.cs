using Assessment2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2.Service
{
    internal class PatientService:IPatientService
    {
        private readonly SqlConnection _connection;

        public PatientService(SqlConnection connection)
        {
            _connection = connection;
        }

        public void AddPatient(Patient patient)
        {
            var cmd = new SqlCommand("INSERT INTO Patients (Name, Age, Gender, MedicalCondition) VALUES (@Name, @Age, @Gender, @MedicalCondition)", _connection);
            {
                cmd.Parameters.AddWithValue("@Name", patient.Name);
                cmd.Parameters.AddWithValue("@Age", patient.Age);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@MedicalCondition", patient.MedicalCondition);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Patient> GetAllPatients()
        {
            var patients = new List<Patient>();
            var cmd = new SqlCommand("SELECT * FROM Patients", _connection);
            {
                var reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        patients.Add(new Patient
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Age = reader.GetInt32(2),
                            Gender = reader.GetString(3),
                            MedicalCondition = reader.GetString(4)
                        });
                    }
                }
            }
            return patients;
        }

        public void UpdatePatient(Patient patient)
        {
            var cmd = new SqlCommand("UPDATE Patients SET Name = @Name, Age = @Age, Gender = @Gender, MedicalCondition = @MedicalCondition WHERE Id = @Id", _connection);
            {
                cmd.Parameters.AddWithValue("@Id", patient.Id);
                cmd.Parameters.AddWithValue("@Name", patient.Name);
                cmd.Parameters.AddWithValue("@Age", patient.Age);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@MedicalCondition", patient.MedicalCondition);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePatient(int patientId)
        {
            var cmd = new SqlCommand("DELETE FROM Patients WHERE Id = @Id", _connection);
            {
                cmd.Parameters.AddWithValue("@Id", patientId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

