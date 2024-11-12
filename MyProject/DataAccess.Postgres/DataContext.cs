using Microsoft.EntityFrameworkCore;
using DataAccess.Postgres.Entity;

namespace DataAccess.Postgres
{
    public class DataContext: DbContext
    {
        public DbSet<ParametersEntity> Parameters { get; set; };



        //шаблон объединение устройство 
        public DataContext(DbContextOptions<DataContext> options): base(options) { }


    }
}
