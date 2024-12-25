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
        /// Метод получает названия всех устройств из БД./>.
        /// </summary>
        /// <returns>Лист названий PlantEntity/>.</returns>
        public async Task<List<string>> GetAllAsyncPlants()
        {
            return await plantRepository.GetAllAsyncPlants();
        }

        /// <summary>
        /// Метод удаляет экзмепляр класса EquipmentEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(int? id)
        {
            await plantRepository.DeleteConfirmed(id);
        }

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса PlantEntity/>.</returns>
        public async Task<PlantEntity> FindById(int? id)
        {
            return await plantRepository.FindById(id);
        }

        /// <summary>
        /// Метод редактирования экземпляра PlantEntity.
        /// <summary>
        /// <param name="plantEntity">Имя объекта.</param>
        public async Task EditPost(PlantEntity plantEntity)
        {
            await plantRepository.EditPost(plantEntity);
        }

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        public bool PlantEntityExists(int id)
        {
            return plantRepository.PlantEntityExists(id);
        }
    }
}
