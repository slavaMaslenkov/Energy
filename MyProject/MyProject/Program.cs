using DataAccess.Postgres;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDataAccess();

            // Добавление зависимостей из Models
            builder.Services.AddScoped<IEquipmentService, EquipmentService>();
            builder.Services.AddScoped<IParametersService, ParametersService>();
            builder.Services.AddScoped<ISampleService, SampleService>();
            builder.Services.AddScoped<IUnityService, UnityService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=MainPage}/{id?}");

            app.Run();
        }
    }
}
