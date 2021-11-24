using System.Collections.Generic;
using System.Threading.Tasks;

namespace cli_manager_API.Services.Company
{
    public interface ICompany
    {
        Task<List<Models.DTOs.Company>> Get();
        Task<Models.DTOs.Company?> Get(int companyId);
        Task<Models.DTOs.Company> Create(Models.DTOs.Company newCompany);
        Task Update(int companyId, Models.DTOs.Company updatedCompany);
        Task Remove(int companyId);
    }
}
