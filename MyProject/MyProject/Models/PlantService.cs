using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;

namespace MyProject.Models
{
    internal class PlantService(IPlantRepository plantRepository) : IPlantService
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса PlantEntity в БД./>.
        /// <summary>
        /// <param name="plantEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса PlantEntity/>.</returns>
        public async Task<PlantEntity> Create(PlantEntity plantEntity)
        {
            return await plantRepository.Create(plantEntity);
        }

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист PlantEntity/>.</returns>
        public async Task<IEnumerable<PlantEntity>> GetAllAsync()
        {
            return await plantRepository.GetAllAsync();
        }

        /// <summary>
        /// Метод достает данные из БД для отображения
        /// иерархичного дерева./>.
        /// <summary>
        /// <returns>Экземпляр класса PlantEntity/>.</returns>
        public async Task<List<dynamic>> Hierarchy()
        {
            return await plantRepository.Hierarchy();
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
