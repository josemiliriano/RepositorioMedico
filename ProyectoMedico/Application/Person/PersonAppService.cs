using Application.Person.DTO;
using Domain.Entities;
using Infraestructure.Exeptions;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Person
{
    public class PersonAppService:IPersonAppService
    {
        private readonly GeneralRepository<CDPerson> _Reporsitory;
        public PersonAppService(GeneralRepository<CDPerson> Reporsitory)
        {
            _Reporsitory = _Reporsitory;
        }

        public async Task<CDPerson> AddPerson(PersonDto dto)
        {
            try
            {
                var exist = await _Reporsitory.ExistsAsync(p => p.Identification.ToLower() == dto.Identification.ToLower());
                if (exist == null)
                {
                    throw new AlreadyExistsException("Identificacion", dto.Identification);
                }
                var NewPerson = new CDPerson
                {
                    Name = dto.Name,
                    LastName = dto.LastName,
                    Address = dto.Address,
                    Phone = dto.Phone,
                    Identification = dto.Identification,
                    Birthday = dto.Birthday
                };
                return NewPerson; 
            }
            catch (AlreadyExistsException e)
            {
                throw new(e.Message);
            }
        }

        public async Task DeletePersonAsync(int id)
        {
            var Person = await _Reporsitory.GetById(id);
            if (Person != null)
            {
              await _Reporsitory.DeleteAsync(Person);
            }
        }

        public async Task<List<CDPerson>> GetAllPerson()
        {
            return await _Reporsitory.GetAll();
        }

        public async Task<CDPerson> GetPersonById(int id)
        {
            return await _Reporsitory.GetById(id);
        }

        public async Task<List<CDPerson>> GetPersonNoDelete()
        {
            var PersonsNoDelete = await _Reporsitory.GetAll();
            return PersonsNoDelete.Where(p => p.IsDelete == '0').ToList();
        }

        public async Task<CDPerson> SoftDelete(int id)
        {
            var person = await _Reporsitory.GetById(id);
            if (person != null)
            {
                person.IsDelete = '1';
            }
            return await _Reporsitory.SoftDelete(person);
        }

        public async Task<CDPerson> UpdatePerson(int id, PersonDto dto)
        {
            var person = await _Reporsitory.GetById(id);
            if (person != null)
            {
                person.Name = dto.Name;
                person.LastName = dto.LastName;
                person.Address = dto.Address;
                person.Phone = dto.Phone;
                person.Identification = dto.Identification;
                person.Birthday = dto.Birthday;
            }
            return await _Reporsitory.Update(person);
        }
    }
}
