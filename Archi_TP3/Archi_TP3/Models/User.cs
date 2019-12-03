using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archi_TP3.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int rights { get; set; }

        //public ICollection<Employee> Employees { get; set; }
    }
}