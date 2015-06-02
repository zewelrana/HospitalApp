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
    class DepartmentManager
    {
        DepartmentGateway departmentGateway = new DepartmentGateway();
        public bool Save(Department department)
        {
            if (department.Name == "")
            {
                MessageBox.Show("Name cannot be empty");
                return false;
            }
            else
            {
                return departmentGateway.Save(department);
            }           
        }

        public List<Department> GetDepartments()
        {
            return departmentGateway.GetDepartments();
        }
    }
}
