using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archi_TP3.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [ForeignKey("User")] public int UserID { get; set; }
        public string LastNameEmployee { get; set; }
        public string FirstNameEmployee { get; set; }
        public string EmailEmployee { get; set; }
        public string AddressEmployee { get; set; }
        public int TelephoneEmployee { get; set; }
        public DateTime BirthDateEmployee { get; set; }
        public DateTime HiringDateEmployee { get; set; }

        public virtual User User { get; set; }

    }
}