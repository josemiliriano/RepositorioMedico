using Application.Prescription.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Prescription
{
    public interface IPrescriptionAppService
    {
        public Task<CDPrescription> AddPrescription(PrescriptionDto dto);       
        public Task<CDPrescription> GetPrescriptionById(int id);
        public Task<CDPrescription> UpdatePrescription(int id, PrescriptionDto dto);
        public Task<List<CDPrescription>> GetAllPrescription();
        public Task<List<CDPrescription>> GetPrescriptionNoDelete();
        public Task DeletePrescripiton(int id);
        public Task<CDPrescription> SoftDelete(int id);
    }
}
