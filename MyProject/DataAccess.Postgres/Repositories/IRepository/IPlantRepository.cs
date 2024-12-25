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

        /// <summary>
        /// Метод получает названия всех устройств из БД./>.
        /// </summary>
        /// <returns>Лист названий PlantEntity/>.</returns>
        Task<List<string>> GetAllAsyncPlants();

        /// <summary>
        /// Метод удаляет экзмепляр класса PlantEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        Task DeleteConfirmed(int? id);

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса PlantEntity/>.</returns>
        Task<PlantEntity> FindById(int? id);

        /// <summary>
        /// Метод редактирования экземпляра PlantEntity.
        /// <summary>
        /// <param name="plantEntity">Имя объекта.</param>
        Task EditPost(PlantEntity plantEntity);

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        bool PlantEntityExists(int id);
    }
}
