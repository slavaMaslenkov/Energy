using DataAccess.Postgres.Entity;
using MyProject.Models.IService;
using DataAccess.Postgres.Repositories.IRepository;

namespace MyProject.Models
{
    internal class RoleService(IRoleRepository roleRepository) : IRoleService
    {
        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист RoleEntity/>.</returns>
        public async Task<IEnumerable<RoleEntity>> GetAllAsync()
        {
            return await roleRepository.GetAllAsync();
        }

        /// <summary>
        /// Метод получает все роли из БД без Admin./>.
        /// </summary>
        /// <returns>Лист RoleEntity/>.</returns>
        public async Task<IEnumerable<RoleEntity>> GetAllAsyncWithoutAdmin()
        {
            return await roleRepository.GetAllAsyncWithoutAdmin();
        }
    }
}
