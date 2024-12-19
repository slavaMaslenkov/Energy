using DataAccess.Postgres.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            serviceCollection.AddDbContext<DataContext>(
            options =>
            {
                    options.UseNpgsql("User ID=postgres; Password=0000; Host=localhost; Port=5432; Database= MyProject");
                });
            return serviceCollection;
        }
    }
}
