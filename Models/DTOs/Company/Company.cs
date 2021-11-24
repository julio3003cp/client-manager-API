namespace cli_manager_API.Models.DTOs
{
    public struct Company
    {
        public Company(int id): this()
        {
            Id = id;
        }
        public Company(int id, string name, int? state)
        {
            Id = id;
            Name = name;
            State = state;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? State { get; set; }
    }
}
