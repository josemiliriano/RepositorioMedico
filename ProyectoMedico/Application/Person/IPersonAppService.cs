using Application.Person.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Person
{
    public interface IPersonAppService
    {
        public Task<CDPerson> AddPerson(PersonDto dto);
        public Task<List<CDPerson>> GetAllPerson();
        public Task<List<CDPerson>> GetPersonNoDelete();
        public Task<CDPerson> GetPersonById(int id);
        public Task<CDPerson> UpdatePerson(int id, PersonDto dto);
        public Task<CDPerson> SoftDelete(int id);
        public Task DeletePersonAsync(int id);

    }
}
