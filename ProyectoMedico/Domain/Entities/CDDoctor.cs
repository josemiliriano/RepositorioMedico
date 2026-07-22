using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class CDDoctor
    {
        [Key]
        public int IdDoctor { get; set; }
        public int PersonId { get; set; }
        public int SpecialityId { get; set; }
        public string MedicalLicense { get; set; }      
        public string ProfessionalCode { get; set; }    
        public int YearsExperience { get; set; }        
        public decimal ConsultationFee { get; set; }
        [Column(TypeName = "date")]
        public DateTime HireDate { get; set; } = DateTime.Now;   
        public char IsDelete { get; set; } = '0';        
        public CDPerson Person { get; set; }
        public CDSpecialty Specialty { get; set; }
        public ICollection<CDMedicalAppointment> MedicalAppointments { get; set; }

        public ICollection<CDMedicalHistory> MedicalHistories { get; set; }
    }
}
