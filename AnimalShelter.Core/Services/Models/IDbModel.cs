using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Services.Models
{
    public interface IDbModel
    {
        Guid Id { get; set; }
    }
}
