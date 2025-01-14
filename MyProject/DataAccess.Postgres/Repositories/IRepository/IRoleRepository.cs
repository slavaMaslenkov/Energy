﻿using DataAccess.Postgres.Entity;

namespace DataAccess.Postgres.Repositories.IRepository
{
    public interface IRoleRepository
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
