﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApplication.Model
{
    public class Patient
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int DoctorId { set; get; }
    }
}
