using AnimalShelter.Core.Services.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Common.Utility
{
    public class ApiLink : IApiLink
    {
        public string Href { get; private set; }
        public string Rel { get; private set; }
        public string Method { get; private set; }

        public ApiLink(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}
