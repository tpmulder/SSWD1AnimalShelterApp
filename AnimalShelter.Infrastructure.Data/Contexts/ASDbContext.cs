using AnimalShelter.Core.Constants;
using AnimalShelter.Core.Models;
using AnimalShelter.Core.Services.Data;
using AnimalShelter.Core.Services.Session;
using AnimalShelter.Infrastructure.Common.Extensions;
using AnimalShelter.Infrastructure.Data.DbExtensions;
using AnimalShelter.Infrastructure.Data.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnimalShelter.Infrastructure.Data.Contexts
{
    public sealed class ASDbContext : DbContext, IASDbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Residence> Residences { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        private readonly IUserSession _userSession;

        public ASDbContext(DbContextOptions<ASDbContext> options, IUserSession userSession) : base(options)
        {
            _userSession = userSession;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ASDbContext).Assembly);
            SetGlobalQueryFilters(modelBuilder, _userSession);
        }

        public DbSet<TEntity> DbSet<TEntity>() where TEntity : class =>
            this.Set<TEntity>();

        private void SetGlobalFilterForEntity<T>(ModelBuilder builder, Expression<Func<object, bool>> filter) where T : class =>
            builder.Entity<T>().HasQueryFilter(filter);

        private void SetGlobalQueryFilters(ModelBuilder modelBuilder, IUserSession userSession)
        {
            foreach (var tp in modelBuilder.Model.GetEntityTypes())
            {
                var t = tp.ClrType;
                var type = t.GetType();

                var isShelterEntity = type.IsShelterEntity(out _);
                var isAnimalTypeEntity = type.IsAnimalTypeEntity(out _);

                if (isShelterEntity || isAnimalTypeEntity)
                {
                    var animalTypeFilter = GlobalFilterForAnimalTypeEntity;
                    var shelterFilter = GlobalFilterForShelterEntity;

                    var filter = true switch {
                        var x when !isShelterEntity && isAnimalTypeEntity => animalTypeFilter,
                        var x when isShelterEntity && !isAnimalTypeEntity => shelterFilter,
                        var x when isShelterEntity && isAnimalTypeEntity => (Expression<Func<object, bool>>) Expression.Lambda(
                                                                                Expression.AndAlso(animalTypeFilter, shelterFilter)),
                        _ => throw new NotImplementedException()
                    };

                    var method = typeof(ASDbContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .Single(t => t.IsGenericMethod && t.Name == nameof(SetGlobalFilterForEntity));

                    method.Invoke(this, new object[] { modelBuilder, filter });
                }
            }
        }

        private Expression<Func<object, bool>> GlobalFilterForAnimalTypeEntity =>
            item => _userSession.AnimalTypeFilterEnabled || EF.Property<int>(item, ShadowPropertyNames.AnimalTypeProperty) == _userSession.AnimalTypeReference;

        private Expression<Func<object, bool>> GlobalFilterForShelterEntity =>
            item => _userSession.ShelterFilterEnabled || EF.Property<int>(item, ShadowPropertyNames.ShelterProperty) == _userSession.ShelterReference;
    }
}
