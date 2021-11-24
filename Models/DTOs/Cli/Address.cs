namespace cli_manager_API.Models.DTOs.Cli
{
    public struct Address
    {
        public Address(short type, string streetname, int number, string city, string country, string comments)
        {
            Type = type;
            StreetName = streetname;
            Number = number;
            City = city;
            Country = country;
            Comments = comments;
        }

        public short Type { get; set; }
        public string StreetName { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Comments { get; set; }
    }
}
