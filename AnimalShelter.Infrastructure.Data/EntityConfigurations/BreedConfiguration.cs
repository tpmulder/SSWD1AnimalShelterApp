using AnimalShelter.Core.Models;
using AnimalShelter.Infrastructure.Data.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Data.EntityConfigurations
{
    public class BreedConfiguration : EntityConfigurationBase<Breed>
    {
        public override void AddDbRequirements(EntityTypeBuilder<Breed> builder)
        {

        }
    }
}
