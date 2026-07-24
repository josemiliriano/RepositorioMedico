using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Insurance.DTOS
{
    public class InsuranceDto
    {        
        public string InsuranceName { get; set; }
        public string PolicyNumber { get; set; }
        public string CoverageType { get; set; }
        public decimal CoveragePercentage { get; set; }       
        public DateTime ExpirationDate { get; set; }        
    }
}
