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
    public class SubsystemConfiguration : IEntityTypeConfiguration<SubsystemEntity>
    {
        public void Configure(EntityTypeBuilder<SubsystemEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.
                HasMany(e => e.System)
                .WithOne(s => s.Subsystem);
        }
    }
}
