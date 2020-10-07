using AnimalShelter.Core.Services.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalShelter.Infrastructure.Common.Wrappers
{
    public class ASUserSession : IUserSession
    {
        private IEnumerable<KeyValuePair<string, string>> _claims { get; set; } = new List<KeyValuePair<string, string>>();

        public bool IsAuthenticated { get; private set; }
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public IEnumerable<string> Roles { get => _claims.Where(e => e.Key.Equals("Role")).Select(e => e.Value); }
        public IEnumerable<string> Permissions { get => _claims.Where(e => e.Key.Equals("Permission")).Select(e => e.Value); }
        public int AnimalTypeReference { get; private set; }
        public int ShelterReference { get; private set; }

        public bool AnimalTypeFilterEnabled { get; private set; }
        public bool ShelterFilterEnabled { get; private set; }

        public IUserSession FillSession()
        {


            return this;
        }
    }
}
