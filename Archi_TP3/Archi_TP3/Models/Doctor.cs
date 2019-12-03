using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archi_TP3.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public int EmployeeID { get; set; }
        public int DoctorTypeID { get; set; }

        public Employee Employee { get; set; }
        public DoctorType DoctorType { get; set; }
    }
}