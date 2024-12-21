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

        public DbSet<PlantEntity> Plant { get; set; }

        public DbSet<SubsystemEntity> Subsystem { get; set; }

        public DbSet<SystemEntity> System { get; set; }

        public DbSet<ConnectionEntity> Connection { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new ParametersConfiguration());
            modelBuilder.ApplyConfiguration(new SampleConfiguration());
            modelBuilder.ApplyConfiguration(new UnityConfiguration());
            modelBuilder.ApplyConfiguration(new PlantConfiguration());
            modelBuilder.ApplyConfiguration(new SubsystemConfiguration());
            modelBuilder.ApplyConfiguration(new SystemConfiguration());
            modelBuilder.ApplyConfiguration(new ConnectionConfiguration());


            base.OnModelCreating(modelBuilder);
        }


    }
}
