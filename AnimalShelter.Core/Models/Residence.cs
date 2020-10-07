using AnimalShelter.Core.Attributes;
using AnimalShelter.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Models
{
    [Shelter]
    public class Residence : DbModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<Restriction> Restrictions { get; set; }
    }
}
