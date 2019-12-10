namespace Archi_TP3.Migration.Clinic
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "RoomLabel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "RoomLabel");
        }
    }
}
