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

        public async Task<Models.DTOs.Company> Create(Models.DTOs.Company company)
        {
            if(string.IsNullOrEmpty(company.Name)) throw new ArgumentNullException("Invalid argument value", nameof(company.Name));

            var newCompany = new Models.Data.Company()
            {
                Name = company.Name,
                State = company.State,
            };

            await _context.Companies.AddAsync(newCompany);
            await _context.SaveChangesAsync();

            company.Id = newCompany.IdCompany;

            return company;
        }

        public async Task<List<Models.DTOs.Company>> Get()
        {
            //By default a filter is applied to get only those with an active status
            return await _context.Companies.Where(x => x.State == (int)States.Active)
                .Select(x => new Models.DTOs.Company(x.IdCompany, x.Name, x.State))
                .ToListAsync();
        }

        public async Task<Models.DTOs.Company?> Get(int companyId)
        {
            if (companyId == 0) throw new ArgumentException("Invalid argument value", nameof(companyId));

            return await _context.Companies.Where(x => x.State == (int)States.Active && x.IdCompany == companyId)
                .Select(x => new Models.DTOs.Company(x.IdCompany, x.Name, x.State))
                .SingleOrDefaultAsync();
        }

        public async Task Remove(int companyId)
        {
            if (companyId == 0) throw new ArgumentException("Invalid argument value", nameof(companyId));

            var company = await _context.Companies.FindAsync(companyId);

            if(company != null)
            {
                //Instead of deleting the record, it's state is change so that it won't appear on searchs
                company.State = (int)States.Inactive;
                await _context.SaveChangesAsync();
            }

        }

        public async Task Update(int companyId, Models.DTOs.Company updatedCompany)
        {
            if (companyId == 0) throw new ArgumentException("Invalid argument value", nameof(companyId));

            var company = await _context.Companies.FindAsync(companyId);

            if (company != null)
            {
                company.Name = updatedCompany.Name;
                company.State = updatedCompany.State;
                await _context.SaveChangesAsync();
            }
        }
    }
}
