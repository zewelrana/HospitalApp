using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalManagementApplication.DAL;
using HospitalManagementApplication.Model;

namespace HospitalManagementApplication.BLL
{
    class DoctorManager
    {
        DoctorGateway doctorGateway = new DoctorGateway();
        public bool Save(Doctor doctor)
        {
            if (doctor.Name == "")
            {
                MessageBox.Show("Name cannot be empty");
                return false;
            }
            else
            {
                return doctorGateway.Save(doctor);
            }
        }

        public List<Doctor> GetDoctorList()
        {
            return doctorGateway.GetDoctorList();
        }

        public List<DoctorDepartment> GetDoctorListWithDepartments()
        {
            return doctorGateway.GetDoctorListWithDepartments();
        }

        public Doctor GetDoctorById(int doctorId)
        {
            return doctorGateway.GetDoctorById(doctorId);
        }

        public bool Update(Doctor doctor)
        {
            if (doctor.Name == "")
            {
                MessageBox.Show("Name cannot be empty");
                return false;
            }
            else
            {
                return doctorGateway.Update(doctor);
            }          
        }

        public bool DeleteDoctorById(int doctorId)
        {
            PatientManager patientManager = new PatientManager();
            List<Patient> patientList = patientManager.GetPatientsByDoctorId(doctorId);
            if (patientList.Count>0)
            {
                return false;
            }
            else
            {
                return doctorGateway.DeleteDoctorById(doctorId);
            }           
        }

        public List<DoctorDepartment> SearchDoctorByNameWithDepartment(string search)
        {
            return doctorGateway.SearchDoctorByNameWithDepartment(search);
        }
    }
}
