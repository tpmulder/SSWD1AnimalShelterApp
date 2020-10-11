using AnimalShelter.Core.Models.Identity;
using AnimalShelter.Core.Services.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Data.Contexts
{
    public sealed class AuthDbContext : IdentityDbContext<ASUser, ASRole, Guid>, IASDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        { }

        public DbSet<TEntity> DbSet<TEntity>() where TEntity : class =>
            this.Set<TEntity>();
    }
}
