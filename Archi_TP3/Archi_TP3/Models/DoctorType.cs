using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archi_TP3.Models
{
    public class DoctorType
    {
        public int DoctorTypeID { get; set; }

        public int ReasonID { get; set; }

        public string Label { get; set; }

        public Reason Reason  { get; set; }
    }
}