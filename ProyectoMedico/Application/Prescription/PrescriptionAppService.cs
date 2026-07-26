using Application.Prescription.DTOs;
using Domain.Entities;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Prescription
{
    public class PrescriptionAppService:IPrescriptionAppService
    {
        private readonly GeneralRepository<CDPrescription> _service;        
        public PrescriptionAppService(GeneralRepository<CDPrescription> service)
        {
            _service = service;
        }

        public async Task<CDPrescription> AddPrescription(PrescriptionDto dto)
        {
            var newPrescription = new CDPrescription
            {
                MedicationName = dto.MedicationName,
                Dosage = dto.Dosage,
                Frequency = dto.Frequency,
                Duration = dto.Duration,
                Instructions = dto.Instructions
            };
            await _service.AddSync(newPrescription);
            return newPrescription;
        }
       

        public async Task DeletePrescripiton(int id)
        {
            var prescription = await _service.GetById(id);
            if (prescription != null)
            {
                await _service.DeleteAsync(prescription);
            }
        }

        public async Task<List<CDPrescription>> GetAllPrescription()
        {
            return await _service.GetAll();
        }

        public async Task<CDPrescription> GetPrescriptionById(int id)
        {
            return await _service.GetById(id);
        }

        public async Task<List<CDPrescription>> GetPrescriptionNoDelete()
        {
            var prescription = await _service.GetAll();
            return prescription.Where(p => p.IsDelete == '0').ToList();
        }

        public async Task<CDPrescription> SoftDelete(int id)
        {
            var prescription = await _service.GetById(id);
            if (prescription != null)
            {
                prescription.IsDelete = '1';
            }
            await _service.SoftDelete(prescription);
            return prescription;
        }

        public async Task<CDPrescription> UpdatePrescription(int id, PrescriptionDto dto)
        {
            var prescription = await _service.GetById(id);
            if (prescription != null)
            {
                prescription.MedicationName = dto.MedicationName;
                prescription.Dosage = dto.Dosage;
                prescription.Frequency = dto.Frequency;
                prescription.Duration = dto.Duration;
                prescription.Instructions = dto.Instructions;
            }
            await _service.Update(prescription);
            return prescription;
        }
       
    }
}
