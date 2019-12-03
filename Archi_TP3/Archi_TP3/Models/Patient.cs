using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archi_TP3.Models
{
    public class Patient
    {

        public int IdPatient { get; set; }

        public string LastNamePatient { get; set; }

        public string FirstNamePatient { get; set; }

        public string EmailPatient { get; set; }

        public string AddressPatient { get; set; }

        public int TelephonePatient { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Date")]
        public DateTime BirthDatePatient { get; set; }

        public User User { get; set; }
    }
}