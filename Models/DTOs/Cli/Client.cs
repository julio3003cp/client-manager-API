using System.Collections.Generic;

namespace cli_manager_API.Models.DTOs.Cli

{
    public struct Client
    {
        public int CompanyId { get; set; }

        public string Id { get; set; }
        public string Name { get; set;}
        public string LastName { get; set;}
    }

    public struct ClientResponse
    {
        public ClientResponse(int companyId, int clientId, string id, 
            string name, string lastName, ICollection<Data.Address> addresses): this()
        {
            CompanyId = companyId;
            ClientId = clientId;    
            Id = id;
            Name = name;
            LastName = lastName;

            foreach (Data.Address item in addresses)
            {
                Addresses.Add(new Address(item.Type, item.StreetName, item.Number,
                    item.City, item.Country, item.Comments));
            }

        }
        public int CompanyId { get; set; }

        public int ClientId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
