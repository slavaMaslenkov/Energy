using DataAccess.Postgres.Entity;

namespace MyProject.Models
{
    public interface IUnityService
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса UnityEntity в БД./>.
        /// <summary>
        /// <param name="unityEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса EquipmentEntity/>.</returns>
        Task<UnityEntity> Create(UnityEntity unityEntity);

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист UnityEntity/>.</returns>
        Task<IEnumerable<UnityEntity>> GetAllAsync();

        /// <summary>
        /// Метод удаляет экзмепляр класса UnityEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        Task DeleteConfirmed(int? id);

        /// <summary>
        /// Метод получения листа шаблонов по имени устройства из БД./>.
        /// <summary>
        /// <param name="name">Словарь.</param>
        /// <returns>Лист шаблонов одного устройства/>.</returns>
        Task<List<UnityEntity>> GetByFilter(string name);

        /// <summary>
        /// Метод обновления значений в БД./>.
        /// <summary>
        /// <param name="values">Словарь.</param>
        Task UpdateValues(Dictionary<int, string> values);

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса UnityEntity/>.</returns>
        Task<UnityEntity> FindById(int? id);

    }
}
