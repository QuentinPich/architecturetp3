namespace Archi_TP3.Migration.Clinic
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRights : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "rights", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "rights", c => c.String());
        }
    }
}
