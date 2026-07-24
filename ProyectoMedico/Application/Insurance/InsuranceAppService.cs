using Application.Insurance.DTOS;
using Domain.Entities;
using Infraestructure.Exeptions;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Insurance
{
    public class InsuranceAppService:IInsuranceAppService
    {
        private readonly GeneralRepository<CDInsurance> _service;
        public InsuranceAppService(GeneralRepository<CDInsurance> service)
        {
            _service = service;
        }

        public async Task<CDInsurance> AddInsurance(InsuranceDto dto)
        {
            var exist = await _service.ExistsAsync(p => p.InsuranceName.ToLower() == dto.InsuranceName.ToLower());
            if (exist)
            {
                throw new AlreadyExistsException("Seguro", dto.InsuranceName);
            }
            var NewInsuranse = new CDInsurance
            {
                InsuranceName = dto.InsuranceName,
                PolicyNumber = dto.PolicyNumber,
                CoverageType = dto.CoverageType,
                CoveragePercentage = dto.CoveragePercentage,
                ExpirationDate = dto.ExpirationDate
            };
            await _service.AddSync(NewInsuranse);
            return NewInsuranse;
        }       

        public async Task DeleteInsuranse(int id)
        {
            var Insuranse = await _service.GetById(id);
            if (Insuranse != null)
            {
                await _service.DeleteAsync(Insuranse);
            }
        }

        public async Task<List<CDInsurance>> GetAllInsuranse()
        {
            return await _service.GetAll();
        }

        public async Task<List<CDInsurance>> GetInsuranceNoDelete()
        {
            var InsuranceList = await _service.GetAll();
            return InsuranceList.Where(i => i.IsDelete == '0').ToList();
        }

        public async Task<CDInsurance> GetInsurenceById(int id)
        {
            return await _service.GetById(id);
        }

        public async Task<CDInsurance> SoftDelete(int id)
        {
            var Insuranse = await _service.GetById(id);
            if (Insuranse != null)
            {
                Insuranse.IsDelete = '1';
            }
            return await _service.SoftDelete(Insuranse);

        }

        public async Task<CDInsurance> UpdateInsuranse(int id, InsuranceDto dto)
        {
            var Insuranse = await _service.GetById(id);
            if (Insuranse != null)
            {
                Insuranse.InsuranceName = dto.InsuranceName;
                Insuranse.PolicyNumber = dto.PolicyNumber;
                Insuranse.CoverageType = dto.CoverageType;
                Insuranse.CoveragePercentage = dto.CoveragePercentage;
                Insuranse.ExpirationDate = dto.ExpirationDate;
            }
            return await _service.Update(Insuranse);
        }
        
    }
}
