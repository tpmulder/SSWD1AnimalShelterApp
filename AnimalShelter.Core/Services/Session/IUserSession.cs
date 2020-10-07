using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Services.Session
{
    public interface IUserSession
    {
        bool IsAuthenticated { get; }
        Guid Id { get; }
        string Email { get; }
        string FirstName { get; }
        string LastName { get; }
        DateTime DateOfBirth { get; }
        int AnimalTypeReference { get; }
        int ShelterReference { get; }

        bool AnimalTypeFilterEnabled { get; }
        bool ShelterFilterEnabled { get; }

        IUserSession FillSession();
    }
}
