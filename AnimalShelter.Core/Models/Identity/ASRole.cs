using AnimalShelter.Core.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Models.Identity
{
    [Shelter]
    public class ASRole : IdentityRole<Guid>
    {
        public ASRole()
        { }

        public ASRole(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Description { get; set; }
    }
}
