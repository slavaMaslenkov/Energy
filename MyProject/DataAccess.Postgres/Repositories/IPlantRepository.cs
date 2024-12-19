using DataAccess.Postgres.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    public interface IPlantRepository
    {
        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист PlantEntity/>.</returns>
        Task<IEnumerable<PlantEntity>> GetAllAsync();

        /// <summary>
        /// Метод добавляет экзмепляр класса PlantEntity в БД./>.
        /// <summary>
        /// <param name="plantEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса PlantEntity/>.</returns>
        Task<PlantEntity> Create(PlantEntity plantEntity);
        /*
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
        bool EquipmentEntityExists(int id);*/
    }
}
