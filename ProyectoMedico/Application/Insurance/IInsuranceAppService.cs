using Application.Insurance.DTOS;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Insurance
{
    public interface IInsuranceAppService
    {
        public Task <CDInsurance> AddInsurance(InsuranceDto dto);
        public Task<CDInsurance> UpdateInsuranse(int id, InsuranceDto dto);
        public Task<List<CDInsurance>> GetAllInsuranse();
        public Task<List<CDInsurance>> GetInsuranceNoDelete();
        public Task<CDInsurance> SoftDelete(int id);
        public Task DeleteInsuranse(int id);
        public Task<CDInsurance> GetInsurenceById(int id);

    }
}
