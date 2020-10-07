using AnimalShelter.Core.Attributes;
using AnimalShelter.Core.Enums;
using AnimalShelter.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Models
{
    [Shelter]
    public class Treatment : DbModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationInMinutes { get; set; }

        public virtual ICollection<Restriction> Restrictions { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
