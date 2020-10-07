using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Services.Utility.ResourceParams
{
    public interface IResourceParameters
    {
        string Fields { get; set; }
        string Includes { get; set; }
        string SearchQuery { get; set; }
        string MainCategory { get; set; }
    }
}
