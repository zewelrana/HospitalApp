using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementApplication.DAL;
using HospitalManagementApplication.Model;

namespace HospitalManagementApplication.BLL
{
    class PatientManager
    {
        PatientGateway patientGateway = new PatientGateway();
        public int Save(Patient patient)
        {
            return patientGateway.Save(patient);
        }

        public List<Patient> GetPatientsByDoctorId(int id)
        {
            return patientGateway.GetPatientsByDoctorId(id);
        }

        public List<PatientDoctor> GetPatientDoctor()
        {
            return patientGateway.GetPatientDoctor();
        }

        public Patient GetPatientById(int patientId)
        {
            return patientGateway.GetPatientById(patientId);
        }

        public Doctor GetDoctorByPatientId(int patientId)
        {
            return patientGateway.GetDoctorByPatientId(patientId);
        }

        public int Update(Patient patient)
        {
            return patientGateway.Update(patient);
        }

        public bool DeleteByPatientId(int patientId)
        {
            return patientGateway.DeleteByPatientId(patientId);
        }

        public List<PatientDoctor> SearchPatientWithDoctorByPatientName(string search)
        {
            return patientGateway.SearchPatientWithDoctorByPatientName(search);
        }
    }
}
