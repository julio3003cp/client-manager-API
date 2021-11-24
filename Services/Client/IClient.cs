using System.Collections.Generic;
using System.Threading.Tasks;

namespace cli_manager_API.Services.Client
{
    public interface IClient
    {
        Task<List<Models.DTOs.Cli.ClientResponse>> Get();
        Task<Models.DTOs.Cli.ClientResponse?> Get(int clientId);
        Task<Models.DTOs.Cli.ClientResponse> Create(Models.DTOs.Cli.Client newClient);
        Task Update(int clientId, Models.DTOs.Cli.Client updatedClient);
        Task Remove(int clientId);
        Task AddAddress(int clientId, Models.DTOs.Cli.Address newAddress);
        Task UpdateAddress(int addressId, Models.DTOs.Cli.Address updatedAddress);
        Task DeleteAddress(int addressId);
    }
}
