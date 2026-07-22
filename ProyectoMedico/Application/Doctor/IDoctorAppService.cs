using Application.Doctor.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Doctor
{
    public interface IDoctorAppService
    {
        public Task<CDDoctor> AddDoctor(DoctorDto dto);
        public Task<List<CDDoctor>> GetAllDoctors();
        public Task<CDDoctor> UpdateDoctor(int id, DoctorOnlyDto dto);
        public Task DeleteDoctor(int id);
        public Task<CDDoctor> GetDoctorById(int id);
        public Task<List<CDDoctor>> GetAllDoctorsWhitName(DoctorDto dto);
        public Task<List<CDDoctor>> GetDoctotNoDelete();
        public Task<CDDoctor> SoftDelete(int id);
    }
}
