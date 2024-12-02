using DataAccess.Postgres.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    public interface IEquipmentRepository
    {
        /// <summary>
        /// Метод создания экземпляра EquipmentEntity.
        /// </summary>
        Task<EquipmentEntity> Create(EquipmentEntity equipmentEntity);

        /// <summary>
        /// Метод получения списка всех созданных EquipmentEntity.
        /// </summary>
        Task<IEnumerable<EquipmentEntity>> GetAllAsync();

        /// <summary>
        /// Метод удаления экземпляра EquipmentEntity.
        /// </summary>
        Task<EquipmentEntity> Delete(Guid? id);

        /// <summary>
        /// Метод подтверждения удаления экземпляра EquipmentEntity.
        /// </summary>
        Task DeleteConfirmed(Guid? id);

        /// <summary>
        /// Метод получения названий экземпляров EquipmentEntity.
        /// </summary>
        Task<List<string>> GetDeviceNamesAsync();

        /// <summary>
        /// Метод получения названий экземпляров EquipmentEntity,
        /// у которых есть экземпляр UnityEntity.
        /// </summary>
        Task<List<string>> GetAvailableDeviceNamesAsync();

        /// <summary>
        /// Метод получения возможности редактирования экземпляра EquipmentEntity.
        /// </summary>
        Task<EquipmentEntity> Edit(Guid? id);

        /// <summary>
        /// Метод получения возможности редактирования экземпляра EquipmentEntity.
        /// </summary>
        Task EditPost(EquipmentEntity equipmentEntity);

        /// <summary>
        /// Метод проверки наличия экземпляра EquipmentEntity.
        /// </summary>
        bool EquipmentEntityExists(Guid id);
    }
}
