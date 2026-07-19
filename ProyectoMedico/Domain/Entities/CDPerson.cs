using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class CDPerson
    {
        [Key]
        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }
        public string Identification { get; set; }
        public char IsDelete { get; set; } = '0';
        public CDUser? User { get; set; }
        public CDPatient? Patient { get; set; }
        public CDDoctor? Doctor { get; set; }
    }
}
