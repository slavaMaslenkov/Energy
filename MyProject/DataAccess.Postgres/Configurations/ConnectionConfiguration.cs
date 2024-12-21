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
    public class ConnectionConfiguration : IEntityTypeConfiguration<ConnectionEntity>
    {
        public void Configure(EntityTypeBuilder<ConnectionEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.
                HasOne(u => u.Parameters)
                .WithMany(s => s.Connection)
                .HasForeignKey(u => u.ParametersID);

            builder.
                HasOne(u => u.Subsystem)
                .WithMany(p => p.Connection)
                .HasForeignKey(u => u.SubsystemID);

            builder.
                HasMany(e => e.Unity)
                .WithOne(s => s.Connection);
        }

    }
}
