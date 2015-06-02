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
    public partial class DiseaseListForm : Form
    {
        public DiseaseListForm(List<Disease> diseaseList)
        {
            InitializeComponent();
            int count = 1;
            foreach (var index in diseaseList)
            {
                ListViewItem listViewItem = new ListViewItem(count.ToString());
                listViewItem.SubItems.Add(index.Name);
                patientListView.Items.Add(listViewItem);
                count++;
            }
        }
    }
}
