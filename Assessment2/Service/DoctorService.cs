using Assessment2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2.Service
{
    internal class DoctorService: IDoctorService
    {
        private readonly SqlConnection _connection;

        public DoctorService(SqlConnection connection)
        {
            _connection = connection;
        }

        public void AddDoctor(Doctor doctor)
        {
            var cmd = new SqlCommand("INSERT INTO Doctors (Name, Specialization, PatientId) VALUES (@Name, @Specialization, @PatientId)", _connection);
            {
                cmd.Parameters.AddWithValue("@Name", doctor.Name);
                cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                cmd.Parameters.AddWithValue("@PatientId", (object)doctor.PatientId ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Doctor> GetAllDoctors()
        {
            var doctors = new List<Doctor>();
            var cmd = new SqlCommand("SELECT * FROM Doctors", _connection);
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        doctors.Add(new Doctor
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Specialization = reader.GetString(2),
                            PatientId = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3)
                        });
                    }
                }
            }
            return doctors;
        }

        public void UpdateDoctor(Doctor doctor)
        {
            var cmd = new SqlCommand("UPDATE Doctors SET Name = @Name, Specialization = @Specialization, PatientId = @PatientId WHERE Id = @Id", _connection);
            {
                cmd.Parameters.AddWithValue("@Id", doctor.Id);
                cmd.Parameters.AddWithValue("@Name", doctor.Name);
                cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                cmd.Parameters.AddWithValue("@PatientId", (object)doctor.PatientId ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDoctor(int doctorId)
        {
            using (var cmd = new SqlCommand("DELETE FROM Doctors WHERE Id = @Id", _connection))
            {
                cmd.Parameters.AddWithValue("@Id", doctorId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

