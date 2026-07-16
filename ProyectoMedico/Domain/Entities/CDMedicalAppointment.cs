using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace Domain.Entities
{
    public class CDMedicalAppointment
    {
        [Key]
        public int IdMedicalAppointment { get; set; }        
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }
        [Column(TypeName = "date")]
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string? Notes { get; set; }
        public char IsDelete { get; set; } = '0';        
        public CDPatient Patients { get; set; }
        public CDDoctor Doctors { get; set; }
        public CDClinic Clinics { get; set; }
    }
}
