using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace Domain.Entities
{
    public class CDMedicalHistory
    {
        [Key]
        public int IdMedicalHistory { get; set; }        
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int? MedicalAppointmentId { get; set; }
        [Column(TypeName = "date")]
        public DateTime ConsultationDate { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string? Observations { get; set; }
        public string? MedicalNotes { get; set; }
        public char IsDelete { get; set; } = '0';        
        public CDPatient Patients { get; set; }
        public CDDoctor Doctors { get; set; }
        public CDMedicalAppointment? MedicalAppointments { get; set; }
        public ICollection<CDPrescription> Prescriptions { get; set; }
    }
}






