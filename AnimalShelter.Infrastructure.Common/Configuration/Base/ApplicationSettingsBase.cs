using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Common.Configuration.Base
{
    public abstract class ApplicationSettingsBase
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public IEnumerable<string> Scopes { get; set; }
    }
}
