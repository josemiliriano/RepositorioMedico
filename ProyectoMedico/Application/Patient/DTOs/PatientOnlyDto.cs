using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Patient.DTOs
{
    public class PatientOnlyDto
    {
        public int InsuranceId { get; set; }
        public string BloodType { get; set; }
        public string? Allergies { get; set; }
        public string? ChronicDiseases { get; set; }
        public string? EmergencyContact { get; set; }
        public string? EmergencyPhone { get; set; }
        
    }
}
