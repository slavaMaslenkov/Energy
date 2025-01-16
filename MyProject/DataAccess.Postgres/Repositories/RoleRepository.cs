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
            var roles = await dbContext.Role
                .AsNoTracking()
                .OrderBy(e => e.Name)
                .ToListAsync();

            // Добавляем описания для ролей
            foreach (var role in roles)
            {
                if (Enum.IsDefined(typeof(Role), role.Id))
                {
                    role.Name = ((Role)role.Id).GetDescription();
                }
            }

            return roles;
        }

        /// <summary>
        /// Метод получает все роли из БД без Admin./>.
        /// </summary>
        /// <returns>Лист RoleEntity/>.</returns>
        public async Task<IEnumerable<RoleEntity>> GetAllAsyncWithoutAdmin()
        {
            var roles = await dbContext.Role
                .AsNoTracking()
                .Where(u => u.Id != (int)Role.Admin)
                .OrderBy(e => e.Name)
                .ToListAsync();

            // Добавляем описания для ролей
            foreach (var role in roles)
            {
                if (Enum.IsDefined(typeof(Role), role.Id))
                {
                    role.Name = ((Role)role.Id).GetDescription();
                }
            }

            return roles;
        }
    }
}
