namespace Archi_TP3.Migration.Clinic
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Equipments", "RoomID", "dbo.Rooms");
            DropIndex("dbo.Patients", new[] { "User_UserID" });
            DropIndex("dbo.Equipments", new[] { "RoomID" });
            AddColumn("dbo.Rooms", "Equipment_EquipmentID", c => c.Int());
            AddColumn("dbo.Equipments", "Room_RoomID", c => c.Int());
            AlterColumn("dbo.Appointments", "AppointmentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "BirthDateEmployee", c => c.DateTime());
            AlterColumn("dbo.Employees", "HiringDateEmployee", c => c.DateTime());
            AlterColumn("dbo.Users", "rights", c => c.String());
            AlterColumn("dbo.Patients", "BirthDatePatient", c => c.DateTime());
            AlterColumn("dbo.PatientRecords", "PatientHistory", c => c.String());
            CreateIndex("dbo.Rooms", "Equipment_EquipmentID");
            CreateIndex("dbo.Equipments", "Room_RoomID");
            AddForeignKey("dbo.Rooms", "Equipment_EquipmentID", "dbo.Equipments", "EquipmentID");
            AddForeignKey("dbo.Equipments", "Room_RoomID", "dbo.Rooms", "RoomID");
            DropColumn("dbo.Patients", "User_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "User_UserID", c => c.Int());
            DropForeignKey("dbo.Equipments", "Room_RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Equipment_EquipmentID", "dbo.Equipments");
            DropIndex("dbo.Equipments", new[] { "Room_RoomID" });
            DropIndex("dbo.Rooms", new[] { "Equipment_EquipmentID" });
            AlterColumn("dbo.PatientRecords", "PatientHistory", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Patients", "BirthDatePatient", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Users", "rights", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "HiringDateEmployee", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Employees", "BirthDateEmployee", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Appointments", "AppointmentDate", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Equipments", "Room_RoomID");
            DropColumn("dbo.Rooms", "Equipment_EquipmentID");
            CreateIndex("dbo.Equipments", "RoomID");
            CreateIndex("dbo.Patients", "User_UserID");
            AddForeignKey("dbo.Equipments", "RoomID", "dbo.Rooms", "RoomID", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "User_UserID", "dbo.Users", "UserID");
        }
    }
}
