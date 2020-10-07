using AnimalShelter.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Models
{
    public class AnimalType : DbModelBase
    {
        public int AnimalTypeReference { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
