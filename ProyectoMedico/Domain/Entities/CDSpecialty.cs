using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;

namespace Domain.Entities
{
    public class CDSpecialty
    {
        [Key]
        public int IdSpecialty { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        public char IsDelete { get; set; } = '0';        
        public ICollection<CDDoctor> Doctor { get; set; }
    }
}
