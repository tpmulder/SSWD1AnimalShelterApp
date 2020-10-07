using AnimalShelter.Infrastructure.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.AuthServer.Configuration
{
    public class IdentityServerSettings
    {
        public const string Section = "IdentityServer";

        public IEnumerable<ApiSettings> Apis { get; set; }
        public IEnumerable<ClientSettings> Clients { get; set; }
    }
}
