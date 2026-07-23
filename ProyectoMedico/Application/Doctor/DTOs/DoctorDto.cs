using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Doctor.DTOs
{
    public class DoctorDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Identification { get; set; }
        public DateTime Birthday { get; set; }
        public int PersonId { get; set; }
        public int SpecialityId { get; set; }
        public string MedicalLicense { get; set; }
        public string ProfessionalCode { get; set; }
        public int YearsExperience { get; set; }
        public decimal ConsultationFee { get; set; }        
    }
}
