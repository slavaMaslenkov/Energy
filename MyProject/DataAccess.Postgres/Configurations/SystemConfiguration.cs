using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Configurations
{
    public class SystemConfiguration : IEntityTypeConfiguration<SystemEntity>
    {
        public void Configure(EntityTypeBuilder<SystemEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.
                HasOne(u => u.Equipment)
                .WithMany(s => s.System)
                .HasForeignKey(u => u.EquipmentID);

            builder.
                HasOne(u => u.Subsystem)
                .WithMany(p => p.System)
                .HasForeignKey(u => u.SubsystemID);

            builder.
                HasMany(s => s.Sample)
                .WithOne(u => u.System);
        }

    }
}
