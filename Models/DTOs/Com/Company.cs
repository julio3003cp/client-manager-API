namespace cli_manager_API.Models.DTOs.Comp
{
    public struct Company
    {
        public Company(int id): this()
        {
            Id = id;
        }
        public Company(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public struct InputCompany
    {
        public string Name { get; set; }

    }
}
