using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Doctor.DTOs
{
    public class DoctorOnlyDto
    {        
        public int PersonId { get; set; }
        public int SpecialityId { get; set; }
        public string MedicalLicense { get; set; }
        public string ProfessionalCode { get; set; }
        public int YearsExperience { get; set; }
        public decimal ConsultationFee { get; set; }
        
    }
}
