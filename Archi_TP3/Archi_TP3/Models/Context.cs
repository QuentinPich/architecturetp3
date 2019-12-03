using System.Data.Entity;

namespace Archi_TP3.Models
{
    public class Context : DbContext
    {
        public Context() : base("DentalClinicDB") { }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<DoctorType> DoctorTypes { get; set; }

        public virtual DbSet<Reason> Reasons { get; set; }



    }
}