using Microsoft.EntityFrameworkCore;
using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Configurations;
using Microsoft.AspNetCore.Identity;


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

        public DbSet<UserEntity> User { get; set; }

        public DbSet<RoleEntity> Role { get; set; }

        public DbSet<RightEntity> Right { get; set; }


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
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RightConfiguration());

            var passwordHasher = new PasswordHasher<UserEntity>();
            var adminPasswordHash = passwordHasher.HashPassword(null, "0000");

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = 1,
                UserName = "admin",
                Password = adminPasswordHash,
                RoleID = 1
            });

            base.OnModelCreating(modelBuilder);
        }


    }
}
