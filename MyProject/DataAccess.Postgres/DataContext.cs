using Microsoft.EntityFrameworkCore;
using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Configurations;


namespace DataAccess.Postgres
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ParametersEntity> Parameters { get; set; }

        public DbSet<UnityEntity> Unity { get; set; }

        public DbSet<SampleEntity> Sample { get; set; }
        public DbSet<EquipmentEntity> Equipment { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new ParametersConfiguration());
            modelBuilder.ApplyConfiguration(new SampleConfiguration());
            modelBuilder.ApplyConfiguration(new UnityConfiguration());


            base.OnModelCreating(modelBuilder);
        }


    }
}
