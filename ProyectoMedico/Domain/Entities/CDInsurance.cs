using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class CDInsurance
    {
        [Key]
        public int IdInsurance { get; set; }
        public string InsuranceName { get; set; }
        public string PolicyNumber { get; set; }
        public string CoverageType { get; set; }
        public decimal CoveragePercentage { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; set; }
        public char IsDelete { get; set; } = '0';
        public ICollection<CDPatient> Patients { get; set; } = new List<CDPatient>();
    }
}
