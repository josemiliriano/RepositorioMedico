using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Person.DTO
{
    public class PersonDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Identification { get; set; }
        public DateTime Birthday { get; set; }
    }
}
