using DataAccess.Postgres.Entity;

namespace MyProject.Models.IService
{
    public interface IRoleService
    {
        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист RoleEntity/>.</returns>
        Task<IEnumerable<RoleEntity>> GetAllAsync();

        /// <summary>
        /// Метод получает все роли из БД без Admin./>.
        /// </summary>
        /// <returns>Лист RoleEntity/>.</returns>
        Task<IEnumerable<RoleEntity>> GetAllAsyncWithoutAdmin();
    }
}
