using AnimalShelter.Core.Constants;
using AnimalShelter.Core.Models;
using AnimalShelter.Infrastructure.Data.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Data.EntityConfigurations
{
    public class ShelterConfiguration : EntityConfigurationBase<Shelter>
    {
        public override void AddDbRequirements(EntityTypeBuilder<Shelter> builder)
        {
            builder.HasMany(e => e.Images)
                .WithOne()
                .HasPrincipalKey(e => e.ShelterReference);
        }
    }
}
