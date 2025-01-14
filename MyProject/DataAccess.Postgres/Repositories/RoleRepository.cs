using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Enums;
using DataAccess.Postgres.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repositories
{
    internal class RoleRepository(DataContext dbContext) : IRoleRepository
    {
        /// <summary>
        /// Метод получает все роли из БД./>.
        /// </summary>
        /// <returns>Лист RoleEntity/>.</returns>
        public async Task<IEnumerable<RoleEntity>> GetAllAsync()
        {
            return await dbContext.Role
                .AsNoTracking()
                .OrderBy(e => e.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Метод получает все роли из БД без Admin./>.
        /// </summary>
        /// <returns>Лист RoleEntity/>.</returns>
        public async Task<IEnumerable<RoleEntity>> GetAllAsyncWithoutAdmin()
        {
            return await dbContext.Role
                .AsNoTracking()
                .Where(u => u.Id != (int)Role.Admin)
                .OrderBy(e => e.Name)
                .ToListAsync();
        }
    }
}
