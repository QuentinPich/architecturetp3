//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Archi_TP3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientRecord
    {
        public int PatientRecordID { get; set; }
        public int PatientID { get; set; }
        public string PatientHistory { get; set; }
    
        public virtual Patient Patient { get; set; }
    }
}
