using System.Threading.Tasks;

namespace cli_manager_API.Services.Company
{
    public interface ICompany
    {
        void Get();
        Task Create();
        void Update();
        void Remove();
    }
}
