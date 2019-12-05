namespace Archi_TP3.Migration.Clinic
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentID = c.Int(nullable: false, identity: true),
                        PatientID = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                        ReasonID = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                        AppointmentDate = c.DateTime(nullable: false, storeType: "date"),
                        StartTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.AppointmentID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .ForeignKey("dbo.Reasons", t => t.ReasonID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.PatientID)
                .Index(t => t.DoctorID)
                .Index(t => t.ReasonID)
                .Index(t => t.RoomID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        DoctorTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorID)
                .ForeignKey("dbo.DoctorTypes", t => t.DoctorTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.DoctorTypeID);
            
            CreateTable(
                "dbo.DoctorTypes",
                c => new
                    {
                        DoctorTypeID = c.Int(nullable: false, identity: true),
                        ReasonID = c.Int(nullable: false),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.DoctorTypeID)
                .ForeignKey("dbo.Reasons", t => t.ReasonID, cascadeDelete: false)
                .Index(t => t.ReasonID);
            
            CreateTable(
                "dbo.Reasons",
                c => new
                    {
                        ReasonID = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        ReasonCost = c.String(),
                        duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReasonID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        LastNameEmployee = c.String(),
                        FirstNameEmployee = c.String(),
                        EmailEmployee = c.String(),
                        AddressEmployee = c.String(),
                        TelephoneEmployee = c.Int(nullable: false),
                        BirthDateEmployee = c.DateTime(nullable: false, storeType: "date"),
                        HiringDateEmployee = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        login = c.String(),
                        password = c.String(),
                        rights = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        LastNamePatient = c.String(),
                        FirstNamePatient = c.String(),
                        EmailPatient = c.String(),
                        AddressPatient = c.String(),
                        TelephonePatient = c.Int(nullable: false),
                        BirthDatePatient = c.DateTime(nullable: false, storeType: "date"),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.PatientID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        EquipmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomID);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        EquipmentLabel = c.String(),
                        EquipmentPrice = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentID)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.RoomID);
            
            CreateTable(
                "dbo.PatientRecords",
                c => new
                    {
                        PatientRecordID = c.Int(nullable: false, identity: true),
                        PatientID = c.Int(nullable: false),
                        PatientHistory = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.PatientRecordID)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.PatientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientRecords", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Equipments", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Appointments", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Appointments", "ReasonID", "dbo.Reasons");
            DropForeignKey("dbo.Appointments", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Patients", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Appointments", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "UserID", "dbo.Users");
            DropForeignKey("dbo.Doctors", "DoctorTypeID", "dbo.DoctorTypes");
            DropForeignKey("dbo.DoctorTypes", "ReasonID", "dbo.Reasons");
            DropIndex("dbo.PatientRecords", new[] { "PatientID" });
            DropIndex("dbo.Equipments", new[] { "RoomID" });
            DropIndex("dbo.Patients", new[] { "User_UserID" });
            DropIndex("dbo.Employees", new[] { "UserID" });
            DropIndex("dbo.DoctorTypes", new[] { "ReasonID" });
            DropIndex("dbo.Doctors", new[] { "DoctorTypeID" });
            DropIndex("dbo.Doctors", new[] { "EmployeeID" });
            DropIndex("dbo.Appointments", new[] { "RoomID" });
            DropIndex("dbo.Appointments", new[] { "ReasonID" });
            DropIndex("dbo.Appointments", new[] { "DoctorID" });
            DropIndex("dbo.Appointments", new[] { "PatientID" });
            DropTable("dbo.PatientRecords");
            DropTable("dbo.Equipments");
            DropTable("dbo.Rooms");
            DropTable("dbo.Patients");
            DropTable("dbo.Users");
            DropTable("dbo.Employees");
            DropTable("dbo.Reasons");
            DropTable("dbo.DoctorTypes");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
