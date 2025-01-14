using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories.IRepository
{
    public interface IRightRepository
    {
        /// <summary>
        /// Метод создает экземпляр класса />.
        /// </summary>
        ///<param name="unityId">Id объекта.</param>
        ///<param name="roleIds">Ids объекта.</param>
        /// <returns>Лист RightEntity/>.</returns>
        Task AttachRoleToUnity(int unityId, int roleIds);
    }
}
