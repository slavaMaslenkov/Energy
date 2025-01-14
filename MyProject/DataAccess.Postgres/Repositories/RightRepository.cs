using DataAccess.Postgres.Entity;
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
        public async Task AttachRoleToUnity(int unityId, List<int> roleIds)
        {
            foreach (var roleId in roleIds)
            {
                var rightEntity = new RightEntity
                {
                    UnityID = unityId,
                    RoleID = roleId
                };

                await dbContext.Right.AddAsync(rightEntity);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
