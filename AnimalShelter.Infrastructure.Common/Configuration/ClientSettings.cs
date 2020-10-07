using AnimalShelter.Infrastructure.Common.Configuration.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Common.Configuration
{
    public class ClientSettings : ApplicationSettingsBase
    {
        public const string Section = "AnimalShelter.Client";

        public IEnumerable<string> Secrets { get; set; }
    }
}
