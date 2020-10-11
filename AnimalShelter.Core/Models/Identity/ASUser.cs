using AnimalShelter.Core.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Models.Identity
{
    [Shelter]
    public class ASUser : IdentityUser<Guid>
    {
        public ASUser()
        { }

        public ASUser(string userName, string email, string firstName, string lastName, DateTime birthdate)
        {
            UserName = userName;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthdate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
