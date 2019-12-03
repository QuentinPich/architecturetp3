using System;

namespace Archi_TP3.Models
{
    public class Patient
    {

        public int PatientID { get; set; }

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