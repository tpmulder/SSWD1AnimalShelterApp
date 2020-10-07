using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Services.Utility
{
    public interface IApiLink
    {
        string Href { get; }
        string Rel { get; }
        string Method { get; }
    }
}
