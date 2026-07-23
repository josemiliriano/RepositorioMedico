using Application.MedicalAppointment.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MedicalAppointment
{
    public interface IMedicalAppointmentAppService
    {
        public Task<CDMedicalAppointment> AddMedicalAppointment(MedicalAppointmentOnlyDto dto);
        public Task<List<CDMedicalAppointment>> GetAllAppoinment();
        public Task<List<CDMedicalAppointment>> GetAllAppoinmentNoDelete();
        public Task<CDMedicalAppointment> SoftDelete(int id);
        public Task DeleteAppointment(int id);
        public Task<CDMedicalAppointment> UpdateAppointment(int id, MedicalAppointmentOnlyDto dto);
        public Task<List<MedicalAppointmentDto>> GetAppointment(MedicalAppointmentDto dto);
    }
}
