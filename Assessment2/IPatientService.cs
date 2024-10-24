using Assessment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal interface IPatientService
    {
        void AddPatient(Patient patient);
        List<Patient> GetAllPatients();
        void UpdatePatient(Patient patient);
        void DeletePatient(int patientId);
    }
}
