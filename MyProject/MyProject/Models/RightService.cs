using DataAccess.Postgres.Repositories;
using DataAccess.Postgres.Repositories.IRepository;
using MyProject.Models.IService;

namespace MyProject.Models
{
    internal class RightService(IRightRepository rightRepository) : IRightService
    {
        /// <summary>
        /// Метод создает экземпляр класса />.
        /// </summary>
        ///<param name="unityId">Id объекта.</param>
        ///<param name="roleIds">Ids объекта.</param>
        /// <returns>Лист RightEntity/>.</returns>
        public async Task AttachRoleToUnity(int unityId, int roleIds)
        {
            await rightRepository.AttachRoleToUnity(unityId, roleIds);
        }
    }
}
