using DataAccess.Postgres.Repositories;
using DataAccess.Postgres.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Postgres
{
    public static class Extensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IEquipmentRepository, EquipmentRepository>();
            serviceCollection.AddScoped<IParametersRepository, ParametersRepository>();
            serviceCollection.AddScoped<ISampleRepository, SampleRepository>();
            serviceCollection.AddScoped<IUnityRepository, UnityRepository>();
            serviceCollection.AddScoped<IPlantRepository, PlantRepository>();
            serviceCollection.AddScoped<ISubsystemRepository, SubsystemRepository>();
            serviceCollection.AddScoped<ISystemRepository, SystemRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IConnectionRepository, ConnectionRepository>();
            serviceCollection.AddScoped<IRoleRepository, RoleRepository>();
            serviceCollection.AddScoped<IRightRepository, RightRepository>();
            serviceCollection.AddDbContext<DataContext>(
            options =>
            {
                    options.UseNpgsql("User ID=postgres; Password=0000; Host=localhost; Port=5432; Database= MyProject");
                });
            return serviceCollection;
        }
    }
}
