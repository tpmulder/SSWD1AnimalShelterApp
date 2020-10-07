using AnimalShelter.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Models
{
    public class Shelter : DbModelBase
    {
        public int ShelterReference { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
