using AnimalShelter.Core.Services.Utility.ResourceParams;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Common.Utility.ResourceParams
{
    public class ResourceParameters : IResourceParameters
    {
        public string Fields { get; set; }
        public string Includes { get; set; }
        public string SearchQuery { get; set; }
        public string MainCategory { get; set; }
    }
}
