using AnimalShelter.Core.Models;
using AnimalShelter.Infrastructure.Data.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Infrastructure.Data.EntityConfigurations
{
    public class AnimalConfiguration : EntityConfigurationBase<Animal>
    {
        public override void AddDbRequirements(EntityTypeBuilder<Animal> builder)
        {
            #region Properties

            builder.Property(e => e.DateOfBirth)
                .IsRequired();

            builder.Property(e => e.RegistratedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            #endregion

            builder.HasOne(e => e.AdoptedBy)
                .WithMany(e => e.AdoptedAnimals);

            builder.HasOne(e => e.Breed)
                .WithMany(e => e.Animals);

            builder.HasOne(e => e.Residence)
                .WithMany(e => e.Animals)
                .IsRequired(false);

            builder.HasMany(e => e.Operations)
                .WithOne(e => e.Animal);
        }
    }
}
