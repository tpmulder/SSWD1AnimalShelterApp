using AnimalShelter.Core.Models;
using AnimalShelter.Infrastructure.Data.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Data.EntityConfigurations
{
    public class UserProfileConfiguration : EntityConfigurationBase<UserProfile>
    {
        public override void AddDbRequirements(EntityTypeBuilder<UserProfile> builder)
        {
            #region Properties

            builder.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(20)
                .IsRequired();

            #endregion
        }
    }
}
