using AnimalShelter.Core.Models;
using AnimalShelter.Infrastructure.Data.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Data.EntityConfigurations
{
    public class TreatmentConfiguration : EntityConfigurationBase<Treatment>
    {
        public override void AddDbRequirements(EntityTypeBuilder<Treatment> builder)
        {
            builder.Property(e => e.Price)
                .HasPrecision(9, 2)
                .IsRequired();

            builder.Property(e => e.DurationInMinutes)
                .IsRequired();
        }
    }
}
