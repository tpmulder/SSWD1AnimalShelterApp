using AnimalShelter.Core.Attributes;
using AnimalShelter.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Models
{
    [Shelter]
    public class UserProfile : DbModelBase
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Animal> AdoptedAnimals { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
