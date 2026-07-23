using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Clinic.DTOs
{
    public class ClinicDto
    {        
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string? Manager { get; set; }
    }
}
