using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Enums;
using DataAccess.Postgres.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    internal class RightRepository(DataContext dbContext) : IRightRepository
    {
        /// <summary>
        /// Метод создает экземпляр класса />.
        /// </summary>
        ///<param name="unityId">Id объекта.</param>
        ///<param name="roleIds">Ids объекта.</param>
        /// <returns>Лист RightEntity/>.</returns>
        public async Task AttachRoleToUnity(int unityId, int roleId)
        {
            // Добавляем роль администратора
            var adminRole = new RightEntity
            {
                UnityID = unityId,
                RoleID = (int)Role.Admin
            };

            await dbContext.Right.AddAsync(adminRole);

            if (roleId == (int)Role.User1 || roleId == (int)Role.User2 || roleId == (int)Role.User3)
            {
                var userRole = new RightEntity
                {
                    UnityID = unityId,
                    RoleID = roleId
                };

                await dbContext.Right.AddAsync(userRole);
            }
            else
            {
                throw new ArgumentException("Недопустимая роль.");
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
