using System.Threading.Tasks;
using cli_manager_API.Models.Data;

namespace cli_manager_API.Services.Company
{
    public class CompanyManager : ICompany
    {
        private readonly CLIManagerContext _context;
        public CompanyManager(CLIManagerContext context)
        {
            _context = context;
        }
        public async Task Create(Models.DTOs.Company newCompany)
        {
            await _context.Companies.AddAsync(new Models.Data.Company() { 
                Name = newCompany.Name
            });
            await _context.SaveChangesAsync();
        }

        public async Task Get()
        {
            throw new System.NotImplementedException();
        }

        public void Remove()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
