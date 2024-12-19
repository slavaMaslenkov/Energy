using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Configurations
{
    public class PlantConfiguration : IEntityTypeConfiguration<PlantEntity>
    {
        public void Configure(EntityTypeBuilder<PlantEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.
                HasMany(p => p.Equipment)
                .WithOne(e => e.Plant);
        }
    }
}
