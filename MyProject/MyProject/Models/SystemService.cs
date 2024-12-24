using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;

namespace MyProject.Models
{
    internal class SystemService(ISystemRepository systemRepository) : ISystemService
    {
        /// <summary>
        /// Метод создает экземпляр класса />.
        /// </summary>
        ///<param name="equipmentId">Имя объекта.</param>
        ///<param name="subsystemIds">Имя объекта.</param>
        /// <returns>Лист SystemEntity/>.</returns>
        public async Task AttachSubsystemsToEquipment(int equipmentId, List<int> subsystemIds)
        {
           await systemRepository.AttachSubsystemsToEquipment(equipmentId, subsystemIds);
        }

        /// <summary>
        /// Метод получает все подустройства конкретного устройства из БД./>.
        /// </summary>
        ///<param name="equipmentId">Имя объекта.</param>
        /// <returns>Лист SystemEntity/>.</returns>
        public async Task<List<SystemEntity>> GetAllByEquipment(int equipmentId)
        {
            return await systemRepository.GetAllByEquipment(equipmentId);
        }
    }
}
