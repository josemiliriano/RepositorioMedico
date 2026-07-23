using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.MedicalAppointment.DTOs
{
    public class MedicalAppointmentOnlyDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }        
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string? Notes { get; set; }
    }
}
