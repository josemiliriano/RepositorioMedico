using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Patient.DTOs
{
    public class PatientDto
    {
        public int PersonId { get; set; }
        public int InsuranceId { get; set; }
        public string BloodType { get; set; }
        public string? Allergies { get; set; }
        public string? ChronicDiseases { get; set; }
        public string? EmergencyContact { get; set; }
        public string? EmergencyPhone { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string InsuranceName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Identification { get; set; }
        public DateTime Birthday { get; set; }
    }
}
