using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repositories
{
    internal class RoleRepository(DataContext dbContext) : IRoleRepository
    {
        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист RoleEntity/>.</returns>
        public async Task<IEnumerable<RoleEntity>> GetAllAsync()
        {
            return await dbContext.Role
                .AsNoTracking()
                .OrderBy(e => e.Name)
                .ToListAsync();
        }
    }
}
