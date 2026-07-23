using Application.Patient.DTOs;
using Application.Users.DTOs;
using Domain.Entities;
using Infraestructure.Data;
using Infraestructure.Exeptions;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Patient
{
    public class PatientAppService:IPatientAppService
    {
        private readonly GeneralRepository<CDPatient> _repository;
        private readonly MyDataContext _context;
        public PatientAppService(GeneralRepository<CDPatient> repository, MyDataContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<CDPatient> AddPatient(PatientDto dto)
        {
            try
            {
                var Person = await _context.Persons.FirstOrDefaultAsync(p => p.Identification == dto.Identification);
                if (Person == null)
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
                    await _context.SaveChangesAsync();
                }
                var newPatient = new CDPatient
                {
                    PersonId = Person.IdPerson,
                    InsuranceId = dto.InsuranceId,
                    BloodType = dto.BloodType,
                    Allergies = dto.Allergies,
                    ChronicDiseases = dto.ChronicDiseases,
                    EmergencyContact = dto.EmergencyContact,
                    EmergencyPhone = dto.EmergencyContact
                };
                await _repository.AddSync(newPatient);
                return newPatient;
            }
            catch (AlreadyExistsException e)
            {
                throw new(e.Message);
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var Patient = await _repository.GetById(id);
            if (Patient != null)
            {
                await _repository.DeleteAsync(Patient);
            }
        }

        public async Task<List<CDPatient>> GetAllPatient()
        {
            return await _repository.GetAll();
        }

        public async Task<List<CDPatient>> GetAllPatientNoDelete()
        {
            var NoDelete = await _repository.GetAll();
            NoDelete.Where(p => p.IsDelete == '0').ToList();
            return NoDelete;
        }       
        public async Task<List<PatientDto>> GetAllPatientWhitName(PatientDto dto)
        {
            return await _context.Patients
               .Include(p => p.Person)
               .Include(p => p.Insurance)
               .Select(p => new PatientDto
               {
                   InsuranceId = p.InsuranceId,
                   Name = p.Person.Name,
                   LastName = p.Person.LastName,
                   BloodType = p.BloodType,
                   Allergies = p.Allergies,
                   ChronicDiseases = p.ChronicDiseases,
                   EmergencyContact = p.EmergencyContact,
                   EmergencyPhone = p.EmergencyPhone,
                   RegistrationDate = p.RegistrationDate,
                   InsuranceName = p.Insurance.InsuranceName
               })
               .ToListAsync();
        }

        public async Task<CDPatient> GetPatientById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<List<PatientOnlyDto>> GetPatientNoDelete()
        {
            var patients = await _repository.GetAllByCondition(p => p.IsDelete == '0');

            return patients.Select(p => new PatientOnlyDto
            {                
                InsuranceId = p.InsuranceId,
                BloodType = p.BloodType,
                Allergies = p.Allergies,
                ChronicDiseases = p.ChronicDiseases,
                EmergencyContact = p.EmergencyContact,
                EmergencyPhone = p.EmergencyPhone              
                
            }).ToList();
        }

        public async Task<CDPatient> SoftDelete(int id)
        {
            var patient = await _repository.GetById(id);
            if (patient != null)
            {
                patient.IsDelete = '1';
            }
            await _repository.SoftDelete(patient);
            return patient;
        }

        public async Task<CDPatient> UpdatePatient(int id, PatientOnlyDto dto)
        {
            var patient = await _repository.GetById(id);
            if (patient != null)
            {
                patient.InsuranceId = dto.InsuranceId;
                patient.BloodType = dto.BloodType;
                patient.Allergies = dto.Allergies;
                patient.ChronicDiseases = dto.ChronicDiseases;
                patient.EmergencyContact = dto.EmergencyContact;
                patient.EmergencyPhone = dto.EmergencyPhone;
            }
            await _repository.Update(patient);
            return patient;
        }
    }
}
