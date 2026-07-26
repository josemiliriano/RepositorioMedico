using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class CDPrescription
    {
        [Key]
        public int IdPrescription { get; set; }                 
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public string? Instructions { get; set; }
        public DateTime PrescriptionDate { get; set; } = DateTime.Now;
        public char IsDelete { get; set; } = '0';        
    }
}
