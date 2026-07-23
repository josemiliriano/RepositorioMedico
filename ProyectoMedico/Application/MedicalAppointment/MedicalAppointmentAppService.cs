using Application.MedicalAppointment.DTOs;
using Domain.Entities;
using Infraestructure.Data;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MedicalAppointment
{
    public class MedicalAppointmentAppService:IMedicalAppointmentAppService
    {
        private readonly GeneralRepository<CDMedicalAppointment> _service;
        private readonly MyDataContext _context;
        public MedicalAppointmentAppService(GeneralRepository<CDMedicalAppointment> service, MyDataContext context)
        {
            _service = service;
            _context = _context;
        }

        public async Task<CDMedicalAppointment> AddMedicalAppointment(MedicalAppointmentOnlyDto dto)
        {
            var NewAppointment = new CDMedicalAppointment
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                ClinicId = dto.ClinicId,
                AppointmentDate = dto.AppointmentDate,
                Reason = dto.Reason,
                Status = dto.Status,
                Notes = dto.Notes
            };
            await _service.AddSync(NewAppointment);
            return NewAppointment;
        }
        
        public async Task DeleteAppointment(int id)
        {
            var appointment = await _service.GetById(id);
            if (appointment != null)
            {
               await _service.DeleteAsync(appointment);
            }
        }

        public async Task<List<CDMedicalAppointment>> GetAllAppoinment()
        {
            return await _service.GetAll(); 
        }

        public async Task<List<CDMedicalAppointment>> GetAllAppoinmentNoDelete()
        {
            var AppointmentNodelete = await _service.GetAll();
            return AppointmentNodelete.Where(a => a.IsDelete == '0').ToList();
        }

        public async Task<List<MedicalAppointmentDto>> GetAppointment(MedicalAppointmentDto dto)
        {
            var AppoitnmentList = await _context.MedicalAppointments.
                                 Include(m => m.Patient).
                                 Include(m => m.Doctor).
                                 Include(m => m.Clinic).Select(m => new MedicalAppointmentDto
                                 {
                                     PatientName = m.Patient.Person.Name,
                                     DoctorName = m.Doctor.Person.Name,
                                     ClinicName = m.Clinic.Name,
                                     AppointmentDate = m.AppointmentDate,
                                     Reason = m.Reason,
                                     Status = m.Status,
                                     Notes = m.Notes
                                 }).ToListAsync();
            return AppoitnmentList;

        }

        public async Task<CDMedicalAppointment> SoftDelete(int id)
        {
            var Appointment = await _service.GetById(id);
            if (Appointment != null)
            {
                Appointment.IsDelete = '1';
            }
            await _service.SoftDelete(Appointment);
            return Appointment;
        }

        public async Task<CDMedicalAppointment> UpdateAppointment(int id, MedicalAppointmentOnlyDto dto)
        {
            var Appointment = await _service.GetById(id);
            if (Appointment != null)
            {
                Appointment.DoctorId = dto.DoctorId;
                Appointment.ClinicId = dto.ClinicId;
                Appointment.AppointmentDate = dto.AppointmentDate;
                Appointment.Reason = dto.Reason;
                Appointment.Status = dto.Status;
                Appointment.Notes = dto.Notes;
            }
            await _service.Update(Appointment);
            return Appointment;
            
        }
    }
}