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
    public class RightConfiguration : IEntityTypeConfiguration<RightEntity>
    {
        public void Configure(EntityTypeBuilder<RightEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.
                HasOne(u => u.Role)
                .WithMany(s => s.Right)
                .HasForeignKey(u => u.RoleID);

            builder.
                HasOne(u => u.Unity)
                .WithMany(p => p.Right)
                .HasForeignKey(u => u.UnityID);
        }

    }
}
