using AnimalShelter.Core.Attributes;
using AnimalShelter.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Models
{
    [AnimalType]
    public class Breed : DbModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
