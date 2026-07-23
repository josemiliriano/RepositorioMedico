using Application.Clinic.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Clinic
{
    public interface IClinicAppService
    {
        public Task<CDClinic> AddClinic(ClinicDto dto);
        public Task<List<CDClinic>> GetAllClinics();
        public Task<List<CDClinic>> ClinicNoDelete();
        public Task<CDClinic> GetClinicById(int id);
        public Task<CDClinic> UpdateClinic(int id, ClinicDto dto);
        public Task DeleteClinic(int id);
        public Task<CDClinic> SoftDelete(int id);
        
    }
}
