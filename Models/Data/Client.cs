using System;
using System.Collections.Generic;

namespace cli_manager_API.Models.Data
{
    public partial class Client
    {
        public Client()
        {
            Addresses = new HashSet<Address>();
        }

        public int IdCompany { get; set; }
        public int IdClient { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public virtual Company IdCompanyNavigation { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
