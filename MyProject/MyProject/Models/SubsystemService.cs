using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;

namespace MyProject.Models
{
    internal class SubsystemService(ISubsystemRepository subsystemRepository) : ISubsystemService
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса SubsystemEntity в БД./>.
        /// <summary>
        /// <param name="subsytemEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса SubsystemEntity/>.</returns>
        public async Task<SubsystemEntity> Create(SubsystemEntity subsytemEntity)
        {
            return await subsystemRepository.Create(subsytemEntity);
        }

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист SubsystemEntity/>.</returns>
        public async Task<IEnumerable<SubsystemEntity>> GetAllAsync()
        {
            return await subsystemRepository.GetAllAsync();
        }
        /*
        /// <summary>
        /// Метод удаляет экзмепляр класса EquipmentEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(int? id)
        {
            await equipmentRepository.DeleteConfirmed(id);
        }

        /// <summary>
        /// Метод получения списка устройств из БД./>.
        /// <summary>
        /// <returns>Лист экземпляров класса EquipmentEntity/>.</returns>
        public async Task<List<string>> GetDeviceNamesAsync()
        {
            return await equipmentRepository.GetDeviceNamesAsync();
        }

        /// <summary>
        /// Метод получения названий экземпляров EquipmentEntity,
        /// у которых есть экземпляр UnityEntity.
        /// <summary>
        /// <returns>Лист экземпляров класса EquipmentEntity/>.</returns>
        public async Task<List<string>> GetAvailableDeviceNamesAsync()
        {
            return await equipmentRepository.GetAvailableDeviceNamesAsync();
        }

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса EquipmentEntity/>.</returns>
        public async Task<EquipmentEntity> FindById(int? id)
        {
            return await equipmentRepository.FindById(id);
        }

        /// <summary>
        /// Метод редактирования экземпляра EquipmentEntity.
        /// <summary>
        /// <param name="equipmentEntity">Имя объекта.</param>
        public async Task EditPost(EquipmentEntity equipmentEntity)
        {
            await equipmentRepository.EditPost(equipmentEntity);
        }

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        public bool EquipmentEntityExists(int id)
        {
            return equipmentRepository.EquipmentEntityExists(id);
        }*/
    }
}
