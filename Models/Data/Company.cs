using System;
using System.Collections.Generic;

namespace cli_manager_API.Models.Data
{
    public partial class Company
    {
        public Company()
        {
            Clients = new HashSet<Client>();
        }

        public int IdCompany { get; set; }
        public string Name { get; set; }
        public int? State { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
