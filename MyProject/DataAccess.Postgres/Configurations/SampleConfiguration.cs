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
    public class SampleConfiguration : IEntityTypeConfiguration<SampleEntity>
    {
        public void Configure(EntityTypeBuilder<SampleEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.
                HasOne(s => s.System)
                .WithMany(e => e.Sample)
                .HasForeignKey(s => s.SystemID);

            builder.
                HasMany(s => s.Unity)
                .WithOne(u => u.Sample);
        }

    }
}
