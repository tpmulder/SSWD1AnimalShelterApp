using AnimalShelter.Core.Attributes;
using AnimalShelter.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Models
{
    public class Operation : DbModelBase
    {
        public string Description { get; set; }
        public DateTime DateOfOperation { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual Treatment Treatment { get; set; }
        public virtual UserProfile Doctor { get; set; }
    }
}
