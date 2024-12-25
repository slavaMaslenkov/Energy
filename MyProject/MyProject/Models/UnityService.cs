using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Models
{
    internal class UnityService(IUnityRepository unityRepository) : IUnityService
    {
        /// <summary>
        /// Метод получения листа шаблонов по имени устройства из БД./>.
        /// <summary>
        /// <param name="id">Словарь.</param>
        /// <returns>Лист шаблонов одного устройства/>.</returns>
        public async Task<List<UnityEntity>> GetByFilter(int id)
        {
            return await unityRepository.GetByFilter(id);
        }

        /// <summary>
        /// Метод добавляет экзмепляр класса UnityEntity в БД./>.
        /// <summary>
        /// <param name="unityEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса EquipmentEntity/>.</returns>
        public async Task<UnityEntity> Create(UnityEntity unityEntity)
        {
            return await unityRepository.Create(unityEntity);
        }

        /// <summary>
        /// Метод удаляет экзмепляр класса UnityEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(int? id)
        {
            await unityRepository.DeleteConfirmed(id);
        }

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист UnityEntity/>.</returns>
        public async Task<IEnumerable<UnityEntity>> GetAllAsync()
        {
            return await unityRepository.GetAllAsync();
        }

        /// <summary>
        /// Метод обновления значений в БД./>.
        /// <summary>
        /// <param name="values">Словарь.</param>
        public async Task UpdateValues(Dictionary<int, string> values)
        {
            await unityRepository.UpdateValues(values);
        }

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса UnityEntity/>.</returns>
        public async Task<UnityEntity> FindById(int? id)
        {
            return await unityRepository.FindById(id);
        }
    }
}
