using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Prescription.DTOs
{
    public class PrescriptionDto
    {        
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public string? Instructions { get; set; }
    }
}
