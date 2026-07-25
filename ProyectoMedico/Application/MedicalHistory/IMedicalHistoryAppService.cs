using Application.MedicalHistory.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MedicalHistory
{
    public interface IMedicalHistoryAppService
    {
        public Task<CDMedicalHistory> AddHistory(MedicalHistoryOnlyDto dto);
        public Task<CDMedicalHistory> GetHistoryById(int id);
        public Task<List<CDMedicalHistory>> GetAllHistory();
        public Task<CDMedicalHistory> UpdateHistory(int id, MedicalHistoryOnlyDto dto);
        public Task<List<MedicalHistoryDto>> GetAllHistoryComplete(MedicalHistoryDto dto);
        public Task<List<CDMedicalHistory>> GetAllHistoryNoDelete();
        public Task<CDMedicalHistory> SoftDelete(int id);
        public Task DeleletHistory(int id);
    }
}
