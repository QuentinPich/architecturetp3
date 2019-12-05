namespace Archi_TP3.Migration.Clinic
{
    using Archi_TP3.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Archi_TP3.Models.ClinicContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migration\Clinic";
        }

        protected override void Seed(Archi_TP3.Models.ClinicContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Users.AddOrUpdate(u => new { u.login, u.password }, Data.getUsers().ToArray());
            context.SaveChanges();
        }
    }
}
