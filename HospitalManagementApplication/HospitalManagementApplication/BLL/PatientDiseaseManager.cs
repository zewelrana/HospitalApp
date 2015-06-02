using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementApplication.DAL;
using HospitalManagementApplication.Model;

namespace HospitalManagementApplication.BLL
{
    class PatientDiseaseManager
    {
        PatientDiseaseGateway patientDiseaseGateway = new PatientDiseaseGateway();
        public void Save(PatientDisease patientDisease)
        {       
            patientDiseaseGateway.Save(patientDisease);
        }

        public void DeleteExisting(Patient patient)
        {
            patientDiseaseGateway.DeleteExisting(patient);
        }
    }
}
