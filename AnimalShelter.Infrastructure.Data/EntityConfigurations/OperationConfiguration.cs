using AnimalShelter.Core.Models;
using AnimalShelter.Infrastructure.Data.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Data.EntityConfigurations
{
    public class OperationConfiguration : EntityConfigurationBase<Operation>
    {
        public override void AddDbRequirements(EntityTypeBuilder<Operation> builder)
        {
            builder.Property(e => e.DateOfOperation)
                .IsRequired();

            builder.HasOne(e => e.Treatment)
                .WithMany(e => e.Operations);

            builder.HasOne(e => e.Doctor)
                .WithMany(e => e.Operations);
        }
    }
}
