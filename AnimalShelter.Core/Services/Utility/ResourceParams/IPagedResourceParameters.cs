using AnimalShelter.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Services.Utility.ResourceParams
{
    public interface IPagedResourceParameters : IResourceParameters
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        string OrderBy { get; set; }
        SortOrder SortOrder { get; set; }
    }
}
