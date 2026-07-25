using Application.Speciality.DTO;
using Domain.Entities;
using Infraestructure.Exeptions;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Speciality
{
    public class SpecialityAppService:ISpecialityAppService
    {
        public readonly GeneralRepository<CDSpecialty> _service;
        public SpecialityAppService(GeneralRepository<CDSpecialty> service)
        {
            _service = service;
        }

        public async Task<CDSpecialty> AddSpeciality(SpecialityDto dto)
        {
            try
            {
                var exist = await _service.ExistsAsync(s => s.Name.ToLower() == dto.Name.ToLower());
                if(exist)
                {
                    throw new AlreadyExistsException("Especialidad", dto.Name);
                }
                var NewSpeciality = new CDSpecialty
                {
                    Name = dto.Name,
                    Description = dto.Description
                };
                await _service.AddSync(NewSpeciality);
                return NewSpeciality;
            }
            catch (AlreadyExistsException e)
            {
                throw new(e.Message);
            }
        }            

        public async Task DeleteSpeciality(int id)
        {
            var speciality = await _service.GetById(id);
            if (speciality != null)
            {
                await _service.DeleteAsync(speciality);
            }
        }

        public async Task<List<CDSpecialty>> GetAllSpeciality()
        {
            return await _service.GetAll();
        }

        public async Task<CDSpecialty> GetSpecialityById(int id)
        {
            var speciality = await _service.GetById(id);
            return speciality;
        }

        public async Task<List<CDSpecialty>> GetSpecialityNoDelete()
        {
            var speciality = await _service.GetAll();
            return speciality.Where(s => s.IsDelete == '0').ToList();
           
        }

        public async Task<CDSpecialty> Softdelete(int id)
        {
            var speciality = await _service.GetById(id);
            if (speciality != null)
            {
                speciality.IsDelete = '1';
            }
            await _service.SoftDelete(speciality);
            return speciality;
        }

        public async Task<CDSpecialty> UpdateSpeciality(int id, SpecialityDto dto)
        {
            var speciality = await _service.GetById(id);
            if (speciality != null)
            {
                speciality.Name = dto.Name;
                speciality.Description = dto.Description;
            }
            await _service.Update(speciality);
            return speciality;
        }
    }
}
