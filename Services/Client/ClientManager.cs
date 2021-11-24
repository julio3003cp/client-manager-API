using cli_manager_API.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cli_manager_API.Services.Client
{
    public class ClientManager: IClient
    {
        private readonly CLIManagerContext _context;
        public ClientManager(CLIManagerContext context)
        {
            _context = context;
        }

        public async Task<Models.DTOs.Cli.ClientResponse> Create(Models.DTOs.Cli.Client newClient)
        {
            var client = new Models.Data.Client() { 
                 IdCompany = newClient.CompanyId,
                 Identification = newClient.Id,
                 Name = newClient.Name,
                 LastName = newClient.LastName,
            };

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return new Models.DTOs.Cli.ClientResponse(client.IdCompany, client.IdClient, client.Identification,
                client.Name, client.LastName, client.Addresses);
        }

        public async Task<List<Models.DTOs.Cli.ClientResponse>> Get()
        {
            return await _context.Clients
                .Select(x => new Models.DTOs.Cli.ClientResponse(x.IdCompany, x.IdClient, x.Identification,
                x.Name, x.LastName, x.Addresses))
                .ToListAsync();
        }

        public async Task<Models.DTOs.Cli.ClientResponse?> Get(int clientId)
        {
            var client = await _context.Clients.Where(x => x.IdClient == clientId)
                .SingleOrDefaultAsync();

            if (client != null)
                return new Models.DTOs.Cli.ClientResponse(client.IdCompany, client.IdClient,
                    client.Identification, client.Name, client.LastName, client.Addresses);
            return null; 
        }

        public async Task Remove(int clientId)
        {
            var client = await _context.Clients.FindAsync(clientId);

            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(int clientId, Models.DTOs.Cli.Client updatedClient)
        {
            var client = await _context.Clients.FindAsync(clientId);

            if (client != null)
            {
                client.Name = updatedClient.Name;
                client.LastName = updatedClient.LastName;
                client.Identification = updatedClient.Id;
                await _context.SaveChangesAsync();
            }
        }
    }
}
