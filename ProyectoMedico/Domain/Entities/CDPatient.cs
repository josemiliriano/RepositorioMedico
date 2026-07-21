using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class CDPatient
    {
        [Key]
        public int IdPatient { get; set; }
        public int PersonId { get; set; }
        public int InsuranceId { get; set; }
        public string BloodType { get; set; }          
        public string? Allergies { get; set; }         
        public string? ChronicDiseases { get; set; }   
        public string? EmergencyContact { get; set; }
        public string? EmergencyPhone { get; set; }
        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public char IsDelete { get; set; } = '0';
        public CDPerson Person { get; set; }        
        public CDInsurance? Insurance { get; set; }
        public ICollection<CDMedicalAppointment> MedicalAppointments { get; set; } = new List<CDMedicalAppointment>();
        public ICollection<CDMedicalHistory> MedicalHistories { get; set; } = new List<CDMedicalHistory>();

    }
}
