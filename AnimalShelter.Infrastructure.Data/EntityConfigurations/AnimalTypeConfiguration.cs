using AnimalShelter.Core.Models;
using AnimalShelter.Infrastructure.Data.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Data.EntityConfigurations
{
    public class AnimalTypeConfiguration : EntityConfigurationBase<AnimalType>
    {
        public override void AddDbRequirements(EntityTypeBuilder<AnimalType> builder)
        {
            #region Properties

            builder.Property(e => e.AnimalTypeReference)
                .ValueGeneratedOnAdd()
                .IsRequired();

            #endregion
        }
    }
}
