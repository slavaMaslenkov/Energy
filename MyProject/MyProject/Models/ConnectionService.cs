using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories.IRepository;
using MyProject.Models.IService;

namespace MyProject.Models
{
    internal class ConnectionService(IConnectionRepository connectionRepository) : IConnectionService
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса ConnectionEntity в БД./>.
        /// <summary>
        /// <param name="subsystemId">Имя объекта.</param>
        /// <returns>Лист экземпляров класса />.</returns>
        public async Task<List<object>> GetParametersBySubsystem(int subsystemId)
        {
            return await connectionRepository.GetParametersBySubsystem(subsystemId);
        }

        /// <summary>
        /// Метод создает экземпляр класса />.
        /// </summary>
        ///<param name="subsystemId">Имя объекта.</param>
        ///<param name="parametersIds">Имя объекта.</param>
        /// <returns>Лист SystemEntity/>.</returns>
        public async Task AttachParametersToSubsystem(int subsystemId, List<int> parametersIds)
        {
           await connectionRepository.AttachParametersToSubsystem(subsystemId, parametersIds);
        }

        /// <summary>
        /// Метод находит экземпляр класса  ConnectionEntity/>.
        /// </summary>
        ///<param name="subsystemId">Имя объекта.</param>
        ///<param name="parameterId">Имя объекта.</param>
        /// <returns>Экземпляр ConnectionEntity/>.</returns>
        public async Task<ConnectionEntity> GetConnectionBySubsystemAndParameterAsync(int subsystemId, int parameterId)
        {
            return await connectionRepository.GetConnectionBySubsystemAndParameterAsync(subsystemId, parameterId);
        }
    }
}
