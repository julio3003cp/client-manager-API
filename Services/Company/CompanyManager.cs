using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cli_manager_API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace cli_manager_API.Services.Company
{
    public class CompanyManager : ICompany
    {
        private readonly CLIManagerContext _context;
        public CompanyManager(CLIManagerContext context)
        {
            _context = context;
        }

        private IQueryable<Models.Data.Company> GetActiveCompanies()
        {
            //By default a filter is applied to get only those with an active status
            return _context.Companies.Where(x => x.State == (int)States.Active);
        }

        public async Task<Models.DTOs.Comp.Company> Create(Models.DTOs.Comp.InputCompany company)
        {
            //The company's name is required
            if(string.IsNullOrEmpty(company.Name)) throw new ArgumentNullException("Invalid argument value", nameof(company.Name));

            var newCompany = new Models.Data.Company()
            {
                Name = company.Name,
                State = (int)States.Active,
            };

            await _context.Companies.AddAsync(newCompany);
            await _context.SaveChangesAsync();

            return new Models.DTOs.Comp.Company(newCompany.IdCompany, newCompany.Name);
        }

        public async Task<List<Models.DTOs.Comp.Company>> Get()
        {
            return await GetActiveCompanies()
                .Select(x => new Models.DTOs.Comp.Company(x.IdCompany, x.Name))
                .ToListAsync();
        }

        public async Task<Models.DTOs.Comp.Company?> Get(int companyId)
        {
            if (companyId == 0) throw new ArgumentException("Invalid argument value", nameof(companyId));

            var company = await GetActiveCompanies().Where(x => x.IdCompany == companyId)
                .SingleOrDefaultAsync();

            if (company != null)
                return new Models.DTOs.Comp.Company(company.IdCompany, company.Name);

            return null;
        }

        public async Task Remove(int companyId)
        {
            if (companyId == 0) throw new ArgumentException("Invalid argument value", nameof(companyId));

            var company = await _context.Companies.FindAsync(companyId);

            if(company != null)
            {
                //Instead of deleting the record, it's state is changed so that it won't appear on searchs
                //this could change later on
                company.State = (int)States.Inactive;
                await _context.SaveChangesAsync();
            }

        }

        public async Task Update(int companyId, Models.DTOs.Comp.InputCompany updatedCompany)
        {
            if (companyId == 0) throw new ArgumentException("Invalid argument value", nameof(companyId));

            var company = await _context.Companies.FindAsync(companyId);

            if (company != null)
            {
                company.Name = updatedCompany.Name;
                await _context.SaveChangesAsync();
            }
        }
    }
}
