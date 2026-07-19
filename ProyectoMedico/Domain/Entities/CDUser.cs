using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class CDUser
    {
        [Key]
        public int IDUser { get; set; }
        public int PersonId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreationDay { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public char IsDelete { get; set; } = '0';
        public CDPerson Person { get; set; }

    }
}
