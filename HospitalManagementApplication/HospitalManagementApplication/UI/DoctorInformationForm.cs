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
    public partial class DoctorInformationForm : Form
    {
        public DoctorInformationForm()
        {
            InitializeComponent();
            GetDoctorListWithPatients();
        }

        private void GetDoctorListWithPatients()
        {
            DoctorManager doctorManager=new DoctorManager();
            List<DoctorDepartment> doctorDepartmentList = doctorManager.GetDoctorListWithDepartments();
            foreach (var index in doctorDepartmentList)
            {
                ListViewItem listViewItem=new ListViewItem(index.DoctorName);
                listViewItem.SubItems.Add(index.DepartmentName);
                listViewItem.Tag = index.Id;
                doctorsListView.Items.Add(listViewItem);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (doctorsListView.SelectedItems.Count > 0)
            {
                int doctorId = int.Parse(doctorsListView.SelectedItems[0].Tag.ToString());
                DoctorEntryForm doctorEntryForm = new DoctorEntryForm("Update", doctorId);
                Close();
                doctorEntryForm.Show();
            }
            else
            {
                MessageBox.Show("You must Select a row");
            }
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (doctorsListView.SelectedItems.Count > 0)
            {
                int doctorId = int.Parse(doctorsListView.SelectedItems[0].Tag.ToString());
                DoctorManager doctorManager = new DoctorManager();
                if (doctorManager.DeleteDoctorById(doctorId))
                {
                    Close();
                    MessageBox.Show("Doctor Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Doctor having patients cannot be deleted");
                }
            }
            else
            {
                MessageBox.Show("You must Select a row");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            doctorsListView.Items.Clear();
            string search = doctorsNameTextBox.Text;
            DoctorManager doctorManager = new DoctorManager();
            List<DoctorDepartment> doctorDepartmentList = doctorManager.SearchDoctorByNameWithDepartment(search);
            foreach (var index in doctorDepartmentList)
            {
                ListViewItem listViewItem = new ListViewItem(index.DoctorName);
                listViewItem.SubItems.Add(index.DepartmentName);
                listViewItem.Tag = index.Id;
                doctorsListView.Items.Add(listViewItem);
            }
        }

        private void showPatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (doctorsListView.SelectedItems.Count > 0)
            {
                int doctorId = int.Parse(doctorsListView.SelectedItems[0].Tag.ToString());
                List<Patient> patientList = new List<Patient>();
                PatientManager patientManager = new PatientManager();
                patientList = patientManager.GetPatientsByDoctorId(doctorId);
                PatientListForm patientListForm = new PatientListForm(patientList);
                patientListForm.Show();
            }
            else
            {
                MessageBox.Show("You must Select a row");
            } 
        }
    }
}
