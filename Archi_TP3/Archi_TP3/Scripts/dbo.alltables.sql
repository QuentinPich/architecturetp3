CREATE TABLE [dbo].[User]
(
	UserID	int NOT NULL primary key,
	login	char(30) NOT NULL,
	password	char(30) NOT NULL,
	rights	char(30) NOT NULL,
)

GO CREATE TABLE [dbo].[Employee] (
    [EmployeeID]         INT       NOT NULL PRIMARY KEY,
    [UserID]             INT       NOT NULL ,
	FOREIGN KEY ([UserID]) REFERENCES [dbo].[User]([UserID]),
    [LastNameEmployee]   CHAR (30) NOT NULL,
    [FirstNameEmployee]  CHAR (30) NOT NULL,
    [EmailEmployee]      CHAR (30) NOT NULL,
    [AddressEmployee]    CHAR (40) NOT NULL,
    [TelephoneEmployee]  INT       NOT NULL,
    [BirthDateEmployee]  DATETIME  NULL,
    [HiringDateEmployee] DATETIME  NULL
);

GO CREATE TABLE [dbo].[Patient] (
    [PatientID]         INT       NOT NULL PRIMARY KEY,
    [LastNamePatient]   CHAR (30) NOT NULL,
    [FirstNamePatient]  CHAR (30) NOT NULL,
    [EmailPatient]      CHAR (30) NOT NULL,
    [AddressPatient]    CHAR (40) NOT NULL,
    [TelephonePatient]  INT       NOT NULL,
    [BirthDatePatient]  DATETIME  NULL
);

GO CREATE TABLE [dbo].[PatientRecord] (
    [PatientRecordID]         INT       NOT NULL PRIMARY KEY,
    [PatientID]   INT NOT NULL,
	FOREIGN KEY ([PatientID]) REFERENCES [dbo].[Patient]([PatientID]),
    [PatientHistory]  CHAR (100) NOT NULL,
);


GO CREATE TABLE [dbo].[DoctorType] (
    [DoctorTypeID]         INT       NOT NULL PRIMARY KEY,
    [ReasonID]   INT NOT NULL,
	FOREIGN KEY ([ReasonID]) REFERENCES [dbo].[Reason]([ReasonID]),
    [Label]  CHAR(30) NOT NULL,
);

GO CREATE TABLE [dbo].[Doctor] (
    [DoctorID]         INT       NOT NULL PRIMARY KEY,
    [EmployeeID]   INT NOT NULL,
	FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee]([EmployeeID]),
    [DoctorTypeID]  INT NOT NULL,
	FOREIGN KEY ([DoctorTypeID]) REFERENCES [dbo].[DoctorType]([DoctorTypeID]),
);


GO CREATE TABLE [dbo].[Reason] (
    [ReasonID]         INT       NOT NULL PRIMARY KEY,
    [Label]   CHAR(30) NOT NULL,
	FOREIGN KEY ([Label]) REFERENCES [dbo].[DoctorType]([Label]),
    [PatientHistory]  CHAR (100) NOT NULL,
);


GO CREATE TABLE [dbo].[Equipment] (
    [EquipmentID]         INT       NOT NULL PRIMARY KEY,
    [EquipmentLabel]   CHAR(30) NOT NULL,
	[EquipmentPrice] INT NOT NULL,
	[RoomID] INT NOT NULL,
	FOREIGN KEY ([RoomID]) REFERENCES [dbo].[Room]([RoomID]),

);

GO CREATE TABLE [dbo].[Room] (
    [RoomID]         INT       NOT NULL PRIMARY KEY,
    [EquipmentID]   INT NOT NULL,
	FOREIGN KEY ([EquipmentID]) REFERENCES [dbo].[Equipment]([EquipmentID]),
);

GO CREATE TABLE [dbo].[Appointment] (
    [AppointmentID]         INT       NOT NULL PRIMARY KEY,
    [PatientID]   INT NOT NULL,
	FOREIGN KEY ([PatientID]) REFERENCES [dbo].[Patient]([PatientID]),
	[DoctorID]   INT NOT NULL,
	FOREIGN KEY ([DoctorID]) REFERENCES [dbo].[Doctor]([DoctorID]),
	[ReasonID]   INT NOT NULL,
	FOREIGN KEY ([ReasonID]) REFERENCES [dbo].[Reason]([ReasonID]),
	[RoomID]   INT NOT NULL,
	FOREIGN KEY ([RoomID]) REFERENCES [dbo].[Room]([RoomID]),
	[AppointmentDate] DateTime NOT NULL,
	[StartTime] TIME NOT NULL,	
);
