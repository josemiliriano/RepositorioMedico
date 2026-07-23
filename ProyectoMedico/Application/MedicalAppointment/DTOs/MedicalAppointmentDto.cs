using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.MedicalAppointment.DTOs
{
    public class MedicalAppointmentDto
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string ClinicName { get; set; }        
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }       
    }
}
