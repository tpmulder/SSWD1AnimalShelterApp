using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AnimalShelter.Infrastructure.Data.DbExtensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<T> AddDefaultRestrictionsForCommonProperty<T>(this EntityTypeBuilder<T> builder, string propName, int maxLength)
            where T : class
        {
            if (typeof(T).GetProperty(propName, BindingFlags.Public | BindingFlags.Instance) != null)
                builder.Property(propName)
                    .HasMaxLength(maxLength)
                    .IsRequired();

            return builder;
        }
    }
}
