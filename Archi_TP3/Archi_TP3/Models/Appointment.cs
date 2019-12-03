using System;

namespace Archi_TP3.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int ReasonID { get; set; }
        public int RoomID { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Date")] public DateTime AppointmentDate { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Time")] public TimeSpan StartTime { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Reason Reason { get; set; }
        public Room Room { get; set; }
    }
}