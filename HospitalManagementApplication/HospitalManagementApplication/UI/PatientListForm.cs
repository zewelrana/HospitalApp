using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalManagementApplication.Model;

namespace HospitalManagementApplication.UI
{
    public partial class PatientListForm : Form
    {
        public PatientListForm(List<Patient> patientList)
        {
            int count = 1;
            InitializeComponent();
            foreach (var index in patientList)
            {
                ListViewItem listViewItem=new ListViewItem(count.ToString());
                listViewItem.SubItems.Add(index.Name);
                patientListView.Items.Add(listViewItem);
                count++;
            }
        }
    }
}
