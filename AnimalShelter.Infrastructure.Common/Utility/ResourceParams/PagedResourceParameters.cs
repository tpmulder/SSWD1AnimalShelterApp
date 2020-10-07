using AnimalShelter.Core.Enums;
using AnimalShelter.Core.Services.Utility.ResourceParams;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Common.Utility.ResourceParams
{
    public class PagedResourceParameters : ResourceParameters, IPagedResourceParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 20;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public string OrderBy { get; set; }
        public SortOrder SortOrder { get; set; }
    }
}
