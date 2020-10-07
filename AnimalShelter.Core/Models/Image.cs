using AnimalShelter.Core.Attributes;
using AnimalShelter.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Models
{
    [Shelter(true)]
    public class Image : DbModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] File { get; set; }
    }
}
