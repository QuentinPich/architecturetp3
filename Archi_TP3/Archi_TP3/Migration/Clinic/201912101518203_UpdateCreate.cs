namespace Archi_TP3.Migration.Clinic
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCreate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "EquipmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "EquipmentID", c => c.Int(nullable: false));
        }
    }
}
