using System.Collections.Generic;
using System.Threading.Tasks;

namespace cli_manager_API.Services.Company
{
    public interface ICompany
    {
        Task<List<Models.DTOs.Comp.Company>> Get();
        Task<Models.DTOs.Comp.Company?> Get(int companyId);
        Task<Models.DTOs.Comp.Company> Create(Models.DTOs.Comp.InputCompany newCompany);
        Task Update(int companyId, Models.DTOs.Comp.InputCompany updatedCompany);
        Task Remove(int companyId);
    }
}
