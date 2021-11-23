using System.Threading.Tasks;

namespace cli_manager_API.Services.Company
{
    public class CompanyManager : ICompany
    {
        private readonly Models.Data.CLIManagerContext _context;
        public CompanyManager(Models.Data.CLIManagerContext context)
        {
            _context = context;
        }
        public async Task Create()
        {
            await _context.Companies.AddAsync(new Models.Data.Company() { 
                Name = "Alternative Company"
            });
            await _context.SaveChangesAsync();
        }

        public void Get()
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
