using AnimalShelter.Core.Models;
using AnimalShelter.Infrastructure.Data.EntityConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AnimalShelter.Infrastructure.Data.EntityConfigurations
{
    public class ResidenceConfiguration : EntityConfigurationBase<Residence>
    {
        public override void AddDbRequirements(EntityTypeBuilder<Residence> builder)
        {

        }
    }
}
