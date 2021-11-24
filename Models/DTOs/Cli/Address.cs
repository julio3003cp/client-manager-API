namespace cli_manager_API.Models.DTOs.Cli
{
    public struct Address
    {
        public Address(int id,short type, string streetname, int number, string city, string country, string comments)
        {
            Id = id;
            Type = type;
            StreetName = streetname;
            Number = number;
            City = city;
            Country = country;
            Comments = comments;
        }

        public int Id { get; set; }
        public short Type { get; set; }
        public string StreetName { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Comments { get; set; }
    }
}
