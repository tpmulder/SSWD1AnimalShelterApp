using AnimalShelter.Core.Models;
using AnimalShelter.Infrastructure.Data.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Data.EntityConfigurations
{
    public class AddressConfiguration : EntityConfigurationBase<Address>
    {
        public override void AddDbRequirements(EntityTypeBuilder<Address> builder)
        {
            #region Properties

            builder.Property(e => e.City)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.HouseNumber)
                .IsRequired();

            builder.Property(e => e.HouseNumberAddition)
                .HasMaxLength(10);

            builder.Property(e => e.StreetName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.CountryCode)
                .HasMaxLength(5)
                .IsRequired();

            #endregion

            var foreignKeyPropName = CreateForeignKeyPropName(typeof(Address));

            builder.HasOne<UserProfile>()
                .WithOne(e => e.Address)
                .HasForeignKey<UserProfile>(foreignKeyPropName);

            builder.HasOne<Shelter>()
                .WithOne(e => e.Address)
                .HasForeignKey<Shelter>(foreignKeyPropName);
        }
    }
}
