using System.Data.Entity;

namespace Archi_TP3.Models
{
    public class Context : DbContext
    {
        public Context() : base("DentalClinicDB") { }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}