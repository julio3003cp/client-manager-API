namespace cli_manager_API.Services.Client
{
    public interface IClient
    {
        void Get();
        void GetAll();
        void Create();
        void Update();
        void Remove();
        void GetMainAddress();
        void GetAllAddresses();

    }
}
