using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repositories
{
    public class UnityRepository
    {
        private readonly DataContext _dbContext;

        public UnityRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// Метод получает параметры определенного шаблона устройства./>.
        /// </summary>
        /// <returns>Возвращает таблицу Unity по опрделенному шаблону./>.</returns>
        /// <summary>
        public async Task<List<UnityEntity>> GetByFilter(string name)
        {
            var query = _dbContext.Unity.AsNoTracking();
            if (!string.IsNullOrEmpty(name))
            {
                query = _dbContext.Unity
                    .Include(s => s.Sample)
                    .Where(s => s.Sample.Name == name);                    ;
            }

            return await query.ToListAsync();
        }
    }
}
