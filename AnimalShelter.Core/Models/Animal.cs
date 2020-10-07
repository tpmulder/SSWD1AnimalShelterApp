using AnimalShelter.Core.Attributes;
using AnimalShelter.Core.Enums;
using AnimalShelter.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Models
{
    [Shelter]
    public class Animal : DbModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime DateOfBirth { get; set; }
        public bool DOBIsEstimated { get; set; }

        public DateTime? DateOfDeath { get; set; }
        public GenderEnum Gender { get; set; }
        public bool Neutered { get; set; }
        public bool? CanBeWithChildren { get; set; }
        public string ReasonForDistance { get; set; }
        public bool Adoptable { get; set; }
        public DateTime AdoptedOn { get; set; }
        public DateTime RegistratedOn { get; set; }

        public virtual UserProfile AdoptedBy { get; set; }
        public virtual Breed Breed { get; set; }
        public virtual Residence Residence { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
