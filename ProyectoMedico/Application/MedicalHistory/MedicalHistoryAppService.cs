using Application.MedicalHistory.DTOs;
using Application.Patient.DTOs;
using Domain.Entities;
using Infraestructure.Data;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MedicalHistory
{
    public class MedicalHistoryAppService:IMedicalHistoryAppService
    {
        private readonly GeneralRepository<CDMedicalHistory> _sevices;
        private readonly MyDataContext _context;
        public MedicalHistoryAppService(GeneralRepository<CDMedicalHistory> sevices, MyDataContext context)
        {
            _context = context;
            _sevices = sevices;
        }
        public async Task<CDMedicalHistory> AddHistory(MedicalHistoryOnlyDto dto)
        {
            var historyP = await _context.MedicalHistories.Include(h => h.Patient).FirstOrDefaultAsync(h => h.PatientId == dto.PatientId);
            var historyD = await _context.MedicalHistories.Include(h => h.Doctor).FirstOrDefaultAsync(h => h.DoctorId == dto.DoctorId);
            var historyA = await _context.MedicalHistories.Include(h => h.MedicalAppointment).FirstOrDefaultAsync(h => h.MedicalAppointmentId == dto.MedicalAppointmentId);

            var NewHistory = new CDMedicalHistory
            {
                PatientId = historyP.PatientId,
                DoctorId = historyD.DoctorId,
                MedicalAppointmentId = historyA.MedicalAppointmentId,
                ConsultationDate = dto.ConsultationDate,
                Diagnosis = dto.Diagnosis,
                Treatment = dto.Treatment,
                Observations = dto.Observations,
                MedicalNotes = dto.MedicalNotes
            };
            await _sevices.AddSync(NewHistory);
            return NewHistory;
        }

        public async Task DeleletHistory(int id)
        {
            var history = await _sevices.GetById(id);
            if (history != null)
            {
                await _sevices.DeleteAsync(history);
            }
            
        }

        public async Task<List<CDMedicalHistory>> GetAllHistory()
        {
            return await _sevices.GetAll();
        }

        public async Task<List<MedicalHistoryDto>> GetAllHistoryComplete(MedicalHistoryDto dto)
        {
            return await _context.MedicalHistories.
                Include(m => m.Patient).
                Include(m => m.Doctor).
                Include(m=> m.MedicalAppointment).Select(m=>new MedicalHistoryDto
                {
                    PatientName =m.Patient.Person.Name,
                    DoctorName=m.Doctor.Person.Name,
                    MedicalAppointmentId=m.MedicalAppointmentId,
                    ConsultationDate=dto.ConsultationDate,
                    Diagnosis=dto.Diagnosis,
                    Treatment=dto.Treatment,
                    Observations=dto.Observations,
                    MedicalNotes=dto.MedicalNotes
                }).ToListAsync();
        }

        public async Task<List<CDMedicalHistory>> GetAllHistoryNoDelete()
        {
            var history = await _sevices.GetAll();
            return history.Where(p => p.IsDelete == '0').ToList();
        }

        public async Task<CDMedicalHistory> GetHistoryById(int id)
        {
            return await _sevices.GetById(id);
        }

        public async Task<CDMedicalHistory> SoftDelete(int id)
        {
            var history = await _sevices.GetById(id);
            if (history != null)
            {
                history.IsDelete = '1';
            }
            await _sevices.SoftDelete(history);
            return history;
        }

        public async Task<CDMedicalHistory> UpdateHistory(int id, MedicalHistoryOnlyDto dto)
        {
            var history = await _sevices.GetById(id);
            if (history != null)
            {
                history.PatientId = dto.PatientId;
                history.DoctorId = dto.DoctorId;
                history.MedicalAppointmentId = dto.MedicalAppointmentId;
                history.ConsultationDate = dto.ConsultationDate;
                history.Diagnosis = dto.Diagnosis;
                history.Treatment = dto.Treatment;
                history.Observations = dto.Observations;
                history.MedicalNotes = dto.MedicalNotes;
            }
            await _sevices.Update(history);
            return history;
        }
    }
}