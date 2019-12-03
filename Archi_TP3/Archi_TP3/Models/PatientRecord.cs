using System;

namespace Archi_TP3.Models
{
    public class PatientRecord
    {
        public int PatientRecordID { get; set; }
        public int PatientID { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "text")] public String PatientHistory { get; set; }

        public Patient Patient { get; set; }
    }
}