﻿
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
    class DiseaseManager
    {
        public bool Save(Disease disease)
        {
            if (disease.Name == "")
            {
                MessageBox.Show("Name cannot be empty");
                return false;
            }
            else
            {
                DiseaseGateway diseaseGateway = new DiseaseGateway();
                return diseaseGateway.Save(disease);
            }            
        }

        public List<Disease> GetDiseaseList()
        {
            DiseaseGateway diseaseGateway=new DiseaseGateway();
            return diseaseGateway.GetDiseaseList();
        }

        public List<Disease> GetDiseasesBypatientId(int id)
        {
            DiseaseGateway diseaseGateway=new DiseaseGateway();
            return diseaseGateway.GetDiseasesBypatientId(id);
        }
    }
}
