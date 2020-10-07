using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Services.Utility
{
    public interface IPagedList<T>
    {
        int CurrentPage { get; }
        int TotalPages { get; }
        int PageSize { get; }
        int TotalCount { get; }
        bool HasPrevious => CurrentPage > 1;
        bool HasNext => CurrentPage < TotalPages;
    }
}
