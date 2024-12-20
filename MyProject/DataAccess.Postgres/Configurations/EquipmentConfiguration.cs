using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Postgres.Configurations
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<EquipmentEntity>
    {
        public void Configure(EntityTypeBuilder<EquipmentEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.
                HasOne(e => e.Plant)
                .WithMany(p => p.Equipment)
                .HasForeignKey(e => e.PlantID);

            builder.
                HasMany(e => e.System)
                .WithOne(s => s.Equipment);
        }
    }
}
