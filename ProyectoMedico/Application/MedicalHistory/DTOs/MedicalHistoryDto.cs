using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.MedicalHistory.DTOs
{
    public class MedicalHistoryDto
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public int? MedicalAppointmentId { get; set; }        
        public DateTime ConsultationDate { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string Observations { get; set; }
        public string MedicalNotes { get; set; }
    }
}
