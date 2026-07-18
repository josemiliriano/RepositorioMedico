using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class CDClinic
    {
        [Key]
        public int IdClinic { get; set; }        
        public string Name { get; set; }       
        public string Address { get; set; }        
        public string Phone { get; set; }        
        public string? Email { get; set; }        
        public string? Manager { get; set; }
        public char IsDelete { get; set; } = '0';        
        public ICollection<CDMedicalAppointment> MedicalAppointment { get; set; }
    }
}
