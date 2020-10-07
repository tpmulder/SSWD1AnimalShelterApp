using AnimalShelter.Core.Constants;
using AnimalShelter.Core.Services.Models;
using AnimalShelter.Core.Models;
using AnimalShelter.Infrastructure.Common.Extensions;
using AnimalShelter.Infrastructure.Data.DbExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AnimalShelter.Infrastructure.Data.EntityConfigurations.Base
{
    public abstract class EntityConfigurationBase<T> : IEntityTypeConfiguration<T>
        where T : class, IDbModel
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.AddDefaultRestrictionsForCommonProperty("Name", 30);
            builder.AddDefaultRestrictionsForCommonProperty("Description", 200);

            if (typeof(T).IsShelterEntity(out var manualShelterRelationEnabled))
            {
                builder.Property<int>(ShadowPropertyNames.ShelterProperty);

                if (!manualShelterRelationEnabled)
                    builder.HasOne<Shelter>()
                        .WithMany()
                        .HasForeignKey(ShadowPropertyNames.ShelterProperty)
                        .HasPrincipalKey(e => e.ShelterReference);
            }

            if (typeof(T).IsAnimalTypeEntity(out var manualAnimalTypeRelationEnabled))
            {
                builder.Property<int>(ShadowPropertyNames.AnimalTypeProperty);

                if (!manualAnimalTypeRelationEnabled)
                    builder.HasOne<AnimalType>()
                        .WithMany()
                        .HasForeignKey(ShadowPropertyNames.AnimalTypeProperty)
                        .HasPrincipalKey(e => e.AnimalTypeReference);
            }

            AddDbRequirements(builder);
        }

        protected virtual string CreateForeignKeyPropName(Type type) =>
            $"{type.Name}Id";

        public abstract void AddDbRequirements(EntityTypeBuilder<T> builder);
    }
}
