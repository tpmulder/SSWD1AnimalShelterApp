using AnimalShelter.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Models.Base
{
    public class DbModelBase : IDbModel
    {
        public Guid Id { get; set; }
    }
}
