using DataAccess.Postgres.Entity;

namespace MyProject.Models
{
    public interface IEquipmentService
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса EquipmentEntity в БД./>.
        /// <summary>
        /// <param name="equipmentEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса EquipmentEntity/>.</returns>
        Task<EquipmentEntity> Create(EquipmentEntity equipmentEntity);

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист EquipmentEntity/>.</returns>
        Task<IEnumerable<EquipmentEntity>> GetAllAsync();

        /// <summary>
        /// Метод удаляет экзмепляр класса EquipmentEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        Task DeleteConfirmed(int? id);

        /// <summary>
        /// Метод получения списка устройств из БД./>.
        /// <summary>
        /// <returns>Лист экземпляров класса EquipmentEntity/>.</returns>
        Task<List<string>> GetDeviceNamesAsync();

        /// <summary>
        /// Метод получения названий экземпляров EquipmentEntity,
        /// у которых есть экземпляр UnityEntity.
        /// <summary>
        /// <returns>Лист экземпляров класса EquipmentEntity/>.</returns>
        Task<List<string>> GetAvailableDeviceNamesAsync();

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса EquipmentEntity/>.</returns>
        Task<EquipmentEntity> FindById(int? id);

        /// <summary>
        /// Метод редактирования экземпляра EquipmentEntity.
        /// <summary>
        /// <param name="equipmentEntity">Имя объекта.</param>
        Task EditPost(EquipmentEntity equipmentEntity);

        // <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        bool EquipmentEntityExists(int id);


    }
}
