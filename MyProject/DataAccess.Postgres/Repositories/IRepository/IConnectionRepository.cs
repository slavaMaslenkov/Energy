using DataAccess.Postgres.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories.IRepository
{
    public interface IConnectionRepository
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса ConnectionEntity в БД./>.
        /// <summary>
        /// <param name="subsystemId">Имя объекта.</param>
        /// <returns>Лист экземпляров класса />.</returns>
        Task<List<object>> GetParametersBySubsystem(int subsystemId);

        /// <summary>
        /// Метод создает экземпляр класса />.
        /// </summary>
        ///<param name="subsystemId">Имя объекта.</param>
        ///<param name="parametersIds">Имя объекта.</param>
        /// <returns>Лист SystemEntity/>.</returns>
        Task AttachParametersToSubsystem(int subsystemId, List<int> parametersIds);

        /// <summary>
        /// Метод находит экземпляр класса  ConnectionEntity/>.
        /// </summary>
        ///<param name="subsystemId">Имя объекта.</param>
        ///<param name="parameterId">Имя объекта.</param>
        /// <returns>Экземпляр ConnectionEntity/>.</returns>
        Task<ConnectionEntity> GetConnectionBySubsystemAndParameterAsync(int subsystemId, int parameterId);
    }
}