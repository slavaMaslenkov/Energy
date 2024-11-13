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
                HasMany(e => e.Sample)
                .WithOne(s => s.Equipment);
        }
    }
}
