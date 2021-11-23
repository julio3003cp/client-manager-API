using System;
using System.Collections.Generic;

namespace cli_manager_API.Models.Data
{
    public partial class Address
    {
        public int IdClient { get; set; }
        public int IdAddress { get; set; }
        public short Type { get; set; }
        public string StreetName { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Comments { get; set; }

        public virtual Client IdClientNavigation { get; set; }
    }
}
