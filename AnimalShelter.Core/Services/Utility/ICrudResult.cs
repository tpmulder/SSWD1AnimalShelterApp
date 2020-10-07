using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Services.Utility
{
    public interface ICrudResult
    {
        bool IsSucceeded { get; }
        string Message { get; set; }
        object Result { get; set; }
    }
}
