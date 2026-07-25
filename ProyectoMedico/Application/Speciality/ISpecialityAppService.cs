using Application.Speciality.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Speciality
{
    public interface ISpecialityAppService
    {
        public Task<CDSpecialty> AddSpeciality(SpecialityDto dto);
        public Task<List<CDSpecialty>> GetAllSpeciality();
        public Task<List<CDSpecialty>> GetSpecialityNoDelete();
        public Task<CDSpecialty> UpdateSpeciality(int id, SpecialityDto dto);
        public Task<CDSpecialty> Softdelete(int id);
        public Task DeleteSpeciality(int id);
        public Task<CDSpecialty> GetSpecialityById(int id);
    }
}
