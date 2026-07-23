using Application.Clinic.DTOs;
using Domain.Entities;
using Infraestructure.Exeptions;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Clinic
{
    public class ClinicAppService:IClinicAppService
    {
        private readonly GeneralRepository<CDClinic> _service;
        public ClinicAppService(GeneralRepository<CDClinic> service)
        {
            _service = service;
        }

        public async Task<CDClinic> AddClinic(ClinicDto dto)
        {
            var exist = await _service.ExistsAsync(c =>c.Name.ToLower() == dto.Name.ToLower());

            if (exist)
            {
                throw new AlreadyExistsException("Identificacion", dto.Name);
            }

            var newClinic = new CDClinic
            {
                Name = dto.Name,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                Manager = dto.Manager
            };

            await _service.AddSync(newClinic);

            return newClinic;
        }        

        public async Task<List<CDClinic>> ClinicNoDelete()
        {
            var ListClinics = await _service.GetAll();
            return ListClinics.Where(c => c.IsDelete == '0').ToList();
        }

        public async Task DeleteClinic(int id)
        {
            var clinic = await _service.GetById(id);
            if (clinic != null)
            {
                await _service.DeleteAsync(clinic);
            }
        }

        public async Task<List<CDClinic>> GetAllClinics()
        {
            return await _service.GetAll();
        }

        public async Task<CDClinic> GetClinicById(int id)
        {
            return await _service.GetById(id);
        }

        public async Task<CDClinic> SoftDelete(int id)
        {
            var clinic = await _service.GetById(id);
            if (clinic != null)
            {
                clinic.IsDelete = '1';
            }
            await _service.SoftDelete(clinic);
            return clinic;
        }

        public async Task<CDClinic> UpdateClinic(int id, ClinicDto dto)
        {
            var clinic = await _service.GetById(id);
            if (clinic != null)
            {
                clinic.Name = dto.Name;
                clinic.Address = dto.Address;
                clinic.Phone = dto.Phone;
                clinic.Email = dto.Email;
                clinic.Manager = dto.Manager;
            }
            await _service.Update(clinic);
            return clinic;
        }
    }
}
