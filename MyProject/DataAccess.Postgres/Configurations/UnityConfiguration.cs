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
    public class UnityConfiguration : IEntityTypeConfiguration<UnityEntity>
    {
        public void Configure(EntityTypeBuilder<UnityEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.
                HasOne(u => u.Sample)
                .WithMany(s => s.Unity)
                .HasForeignKey(u => u.SampleID);

            builder.
                HasOne(u => u.Connection)
                .WithMany(p => p.Unity)
                .HasForeignKey(u => u.ConnectionID);
        }

    }
}
