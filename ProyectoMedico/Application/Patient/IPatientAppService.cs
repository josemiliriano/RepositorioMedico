using Application.Patient.DTOs;
using Application.Users.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Patient
{
    public interface IPatientAppService
    {
        public Task<CDPatient> AddPatient(PatientDto dto);
        public Task<CDPatient> GetPatientById(int id);
        public Task<CDPatient> UpdatePatient(int id, PatientOnlyDto dto);
        public Task<List<CDPatient>> GetAllPatient();
        public Task<List<CDPatient>> GetAllPatientNoDelete();
        public Task DeleteUserAsync(int id);
        public Task<CDPatient> SoftDelete(int id);
        public Task<List<PatientOnlyDto>> GetPatientNoDelete();
        public Task<List<PatientDto>> GetAllPatientWhitName(PatientDto dto);
    }
}
