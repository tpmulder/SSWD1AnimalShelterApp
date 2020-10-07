using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Constants
{
    public class ShadowPropertyNames
    {
        // Shelter
        public const string ShelterProperty = "ShelterReference";

        // AnimalType
        public const string AnimalTypeProperty = "AnimalTypeReference";

        // Softdeletable
        public const string SoftDeletableProperty = "IsDeleted";

        // Auditable
        public const string CreatedOnProperty = "CreatedOn";
        public const string CreatedByProperty = "CreatedBy";
        public const string ModifiedOnProperty = "ModifiedOn";
        public const string ModifiedByProperty = "ModifiedBy";
    }
}
