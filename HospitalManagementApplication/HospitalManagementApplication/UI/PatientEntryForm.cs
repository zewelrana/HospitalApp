using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalManagementApplication.BLL;
using HospitalManagementApplication.Model;

namespace HospitalManagementApplication.UI
{
    public partial class PatientEntryForm : Form
    {
        private string mode = "";
        private int patientId = 0;
        PatientManager patientManager = new PatientManager();
        public PatientEntryForm(string mode,int patientId)
        {
            InitializeComponent();
            if (mode == "Update")
            {
                Patient patient=patientManager.GetPatientById(patientId);
                patientsNameTextBox.Text = patient.Name;
                Doctor doctor=patientManager.GetDoctorByPatientId(patientId);
                GetDoctorsListInComboBox();
                doctorComboBox.Text = doctor.Name;           
                List<Disease> patientDiseaseList=new List<Disease>();
                List<Disease> diseaseList = new List<Disease>();
                DiseaseManager diseaseManager=new DiseaseManager();
                patientDiseaseList=diseaseManager.GetDiseasesBypatientId(patientId);
                diseaseList = diseaseManager.GetDiseaseList();
                diseaseCheckedListBox.DataSource = null;
                diseaseCheckedListBox.DataSource = diseaseList;
                diseaseCheckedListBox.ValueMember = "Id";
                diseaseCheckedListBox.DisplayMember = "Name";
                for (int index = 0; index < diseaseList.Count; index++)
                {
                    foreach (var patientIndex in patientDiseaseList)
                    {
                       if(diseaseList[index].Id==patientIndex.Id)
                       {
                           diseaseCheckedListBox.SetItemChecked(index,true);
                           break;
                       }
                    }
                }
                this.mode = mode;
                this.patientId = patientId;
            }
            else
            {
                GetDoctorsListInComboBox();
                GetDiseaseListInDiseaseCheckedListBox();
            }
        }

        private void GetDiseaseListInDiseaseCheckedListBox()
        {
            DiseaseManager diseaseManager=new DiseaseManager();
            List<Disease> diseaseList=new List<Disease>();
            diseaseList = diseaseManager.GetDiseaseList();
            diseaseCheckedListBox.DataSource = null;
            diseaseCheckedListBox.DataSource = diseaseList;
            diseaseCheckedListBox.ValueMember = "Id";
            diseaseCheckedListBox.DisplayMember = "Name";
        }

        private void GetDoctorsListInComboBox()
        {
            DoctorManager doctorManager=new DoctorManager();
            List<Doctor> doctorList=new List<Doctor>();
            doctorList=doctorManager.GetDoctorList();
            doctorComboBox.DataSource = null;
            doctorComboBox.DataSource = doctorList;
            doctorComboBox.ValueMember = "Id";
            doctorComboBox.DisplayMember = "Name";            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            PatientManager patientManager=new PatientManager();
            PatientDiseaseManager patientDiseaseManager=new PatientDiseaseManager();
            Patient patient=new Patient();
            patient.Id = patientId;
            patient.Name = patientsNameTextBox.Text;
            patient.DoctorId = int.Parse(doctorComboBox.SelectedValue.ToString());
            if (mode == "Update" && patient.Name!="")
            {
                int row = patientManager.Update(patient);
                if (row == 1)
                {
                    PatientDiseaseManager aPatientDiseaseManager=new PatientDiseaseManager();
                    aPatientDiseaseManager.DeleteExisting(patient);
                    foreach (var index in diseaseCheckedListBox.CheckedItems)
                    {
                        Disease disease = (Disease)index;
                        PatientDisease patientDisease = new PatientDisease();
                        patientDisease.PatientId = patient.Id;
                        patientDisease.DiseaseId = disease.Id;
                        patientDiseaseManager.Save(patientDisease);
                    }
                    Close();
                    MessageBox.Show("Patient Successfully Updated");                   
                }
            }
            else if(patient.Name!="")
            {
                int retrievedPatientId = patientManager.Save(patient);
                if (retrievedPatientId > 0)
                {
                    foreach (var index in diseaseCheckedListBox.CheckedItems)
                    {
                        Disease disease = (Disease) index;
                        PatientDisease patientDisease = new PatientDisease();
                        patientDisease.PatientId = retrievedPatientId;
                        patientDisease.DiseaseId = disease.Id;
                        patientDiseaseManager.Save(patientDisease);
                    }
                    Close();
                    MessageBox.Show("Patient Successfully Saved");
                }
            }
            else
            {
                MessageBox.Show("Name cannot be empty");
            }
        }

        private void addNewDiseaseButton_Click(object sender, EventArgs e)
        {
            DiseaseEntryForm diseaseEntryForm = new DiseaseEntryForm();
            Close();
            diseaseEntryForm.Show();
        }
    }
}
