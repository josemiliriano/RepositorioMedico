using Application.Doctor.DTOs;
using Domain.Entities;
using Infraestructure.Data;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Doctor
{
    public class DoctorAppService:IDoctorAppService
    {
        private readonly GeneralRepository<CDDoctor> _repository;
        private readonly MyDataContext _context;
        public DoctorAppService(GeneralRepository<CDDoctor> repository, MyDataContext context) 
        {
            _repository = repository;
            _context = context;
        }

        public async Task<CDDoctor> AddDoctor(DoctorDto dto)
        {
            var exist = await _context.Persons.FirstOrDefaultAsync(p => p.Name.ToLower() == dto.Name.ToLower());
            if (exist == null)
            {
                var NewPerson = new CDPerson
                {
                    Name = dto.Name,
                    LastName = dto.LastName,
                    Address = dto.Address,
                    Phone = dto.Phone,
                    Identification = dto.Identification,
                    Birthday = dto.Birthday
                };
                _context.Add(NewPerson);
                _context.SaveChangesAsync();
            }
            var MewDoctor = new CDDoctor
            {
                PersonId = exist.IdPerson,
                SpecialityId = dto.SpecialityId,
                MedicalLicense = dto.MedicalLicense,
                ProfessionalCode = dto.ProfessionalCode,
                YearsExperience = dto.YearsExperience,
                ConsultationFee = dto.ConsultationFee
            };
            return MewDoctor;

        }

        public async Task DeleteDoctor(int id)
        {
            var Doctor = await _repository.GetById(id);
            if (Doctor != null)
            {
                await _repository.DeleteAsync(Doctor);
            }
        }

        public async Task<List<CDDoctor>> GetAllDoctors()
        {
            return await _repository.GetAll();
        }

        public async Task<List<DoctorDto>> GetAllDoctorsWhitName(DoctorDto dto)
        {
            return await _context.Doctors
                .Include(d => d.Person)
                .Select(d => new DoctorDto
                {
                    PersonId = d.PersonId,
                    SpecialityId = d.SpecialityId,
                    Name = d.Person.Name,
                    LastName = d.Person.LastName,
                    Address = d.Person.Address,
                    Phone = d.Person.Phone,
                    Identification = d.Person.Identification,
                    Birthday = d.Person.Birthday,
                    MedicalLicense = d.MedicalLicense,
                    ProfessionalCode = d.ProfessionalCode,
                    YearsExperience = d.YearsExperience,
                    ConsultationFee = d.ConsultationFee
                }).ToListAsync();
        }

        public async Task<CDDoctor> GetDoctorById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<List<CDDoctor>> GetDoctotNoDelete()
        {
            var DoctorNoDelete = await _repository.GetAll();
            DoctorNoDelete.Where(d => d.IsDelete == '0');
            return DoctorNoDelete;
        }

        public async Task<CDDoctor> SoftDelete(int id)
        {
            var Doctor = await _repository.GetById(id);
            if (Doctor != null)
            {
                Doctor.IsDelete = '1';
            }
            _repository.SoftDelete(Doctor);
            return Doctor;
        }

        public async Task<CDDoctor> UpdateDoctor(int id, DoctorOnlyDto dto)
        {
            var Doctor = await _repository.GetById(id);
            if (Doctor != null)
            {
                Doctor.PersonId = dto.PersonId;
                Doctor.SpecialityId = dto.SpecialityId;
                Doctor.MedicalLicense = dto.MedicalLicense;
                Doctor.ProfessionalCode = dto.ProfessionalCode;
                Doctor.YearsExperience = dto.YearsExperience;
                Doctor.ConsultationFee = dto.ConsultationFee;
            }
            _repository.Update(Doctor);
            return Doctor;
        }
    }
}
