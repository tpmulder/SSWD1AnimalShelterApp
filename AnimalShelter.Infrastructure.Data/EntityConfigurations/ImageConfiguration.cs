using AnimalShelter.Core.Models;
using AnimalShelter.Infrastructure.Data.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Data.EntityConfigurations
{
    public class ImageConfiguration : EntityConfigurationBase<Image>
    {
        public override void AddDbRequirements(EntityTypeBuilder<Image> builder)
        {
            builder.HasOne<Animal>()
                .WithMany(e => e.Images)
                .HasForeignKey(CreateForeignKeyPropName(typeof(Animal)))
                .IsRequired(false);
        }
    }
}
