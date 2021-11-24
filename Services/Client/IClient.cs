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

    }
}
