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
    public partial class PatientsInformationForm : Form
    {
        PatientManager patientManager = new PatientManager();
        public PatientsInformationForm()
        {
            InitializeComponent();
            GetPatientListWithDoctor();
        }

        private void GetPatientListWithDoctor()
        {
            List<PatientDoctor> patientDoctorList = patientManager.GetPatientDoctor();
            foreach (var index in patientDoctorList)
            {
                ListViewItem listViewItem = new ListViewItem(index.PatientName);
                listViewItem.SubItems.Add(index.DoctorName);
                listViewItem.Tag = index.Id;
                patientsListView.Items.Add(listViewItem);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (patientsListView.SelectedItems.Count>0)
            {
                int patientId = int.Parse(patientsListView.SelectedItems[0].Tag.ToString());
                PatientEntryForm patientEntryForm = new PatientEntryForm("Update", patientId);
                Close();
                patientEntryForm.Show();
            }
            else
            {
                MessageBox.Show("You must Select a row");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (patientsListView.SelectedItems.Count > 0)
            {
                int patientId = int.Parse(patientsListView.SelectedItems[0].Tag.ToString());
                Patient patient = patientManager.GetPatientById(patientId);
                PatientDiseaseManager patientDiseaseManager = new PatientDiseaseManager();
                patientDiseaseManager.DeleteExisting(patient);
                if (patientManager.DeleteByPatientId(patientId))
                {
                    Close();
                    MessageBox.Show("Patient Successfully Deleted");
                }
                else
                {
                    MessageBox.Show("An Error Occured");
                }
            }
            else
            {
                MessageBox.Show("You must Select a row");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            patientsListView.Items.Clear();
            string search = patientsNameTextBox.Text;
            List<PatientDoctor> patientDoctorList = patientManager.SearchPatientWithDoctorByPatientName(search);
            foreach (var index in patientDoctorList)
            {
                ListViewItem listViewItem = new ListViewItem(index.PatientName);
                listViewItem.SubItems.Add(index.DoctorName);
                listViewItem.Tag = index.Id;
                patientsListView.Items.Add(listViewItem);
            }
        }

        private void showDiseasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (patientsListView.SelectedItems.Count > 0)
            {
                int patientId = int.Parse(patientsListView.SelectedItems[0].Tag.ToString());
                List<Disease> diseaseList = new List<Disease>();
                DiseaseManager diseaseManager = new DiseaseManager();
                diseaseList = diseaseManager.GetDiseasesBypatientId(patientId);
                DiseaseListForm diseaseListForm = new DiseaseListForm(diseaseList);
                diseaseListForm.Show();
            }
            else
            {
                MessageBox.Show("A row must be selected");
            }
            
        }
    }
}
