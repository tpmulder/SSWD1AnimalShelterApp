using AnimalShelter.Core.Models;
using AnimalShelter.Infrastructure.Data.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Data.EntityConfigurations
{
    public class RestrictionConfiguration : EntityConfigurationBase<Restriction>
    {
        public override void AddDbRequirements(EntityTypeBuilder<Restriction> builder)
        {
            #region Properties

            builder.Property(e => e.Operator)
                .IsRequired();

            builder.Property(e => e.PropName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Value)
                .HasMaxLength(200)
                .IsRequired();

            #endregion

            builder.HasOne<Residence>()
                .WithMany(e => e.Restrictions)
                .HasForeignKey(CreateForeignKeyPropName(typeof(Residence)))
                .IsRequired(false);

            builder.HasOne<Treatment>()
                .WithMany(e => e.Restrictions)
                .HasForeignKey(CreateForeignKeyPropName(typeof(Treatment)))
                .IsRequired(false);
        }
    }
}
