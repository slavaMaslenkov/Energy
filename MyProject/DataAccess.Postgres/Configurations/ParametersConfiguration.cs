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
    public class ParametersConfiguration : IEntityTypeConfiguration<ParametersEntity>
    {
        public void Configure(EntityTypeBuilder<ParametersEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.
                HasMany(p => p.Unity)
                .WithOne(u => u.Parameters);
        }

    }
}
