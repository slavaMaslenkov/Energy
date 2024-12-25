using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;

namespace MyProject.Models
{
    internal class SampleService(ISampleRepository sampleRepository) : ISampleService
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса SampleEntity в БД./>.
        /// <summary>
        /// <param name="sampleEntity">Имя шаблона.</param>
        /// <returns>Экземпляр класса SampleEntity/>.</returns>
        public async Task<SampleEntity> Create(SampleEntity sampleEntity)
        {
            return await sampleRepository.Create(sampleEntity);
        }

        /// <summary>
        /// Метод создает список экзмепляров класса UnityEntity на основе 
        /// другого экземпляра./>.
        /// <summary>
        /// <param name="equipmentID">Имя шаблона.</param>
        /// <returns>Экземпляр класса SampleEntity/>.</returns>
        public async Task<SampleEntity> CreateBasedOn(int equipmentID, SampleEntity sampleEntity)
        {
            return await sampleRepository.CreateBasedOn(equipmentID, sampleEntity);
        }


        /// <summary>
        /// Метод получает все шаблоны из БД./>.
        /// </summary>
        /// <returns>Лист SampleEntity/>.</returns>
        public async Task<IEnumerable<SampleEntity>> GetAllAsync()
        {
            return await sampleRepository.GetAllAsync();
        }

        /// <summary>
        /// Метод получает шаблоны из БД со статусом "В редакции"/>.
        /// </summary>
        /// <returns>Лист SampleEntity/>.</returns>
        public async Task<IEnumerable<SampleEntity>> GetAvailableAsync()
        {
            return await sampleRepository.GetAvailableAsync();
        }

        /// <summary>
        /// Метод получает шаблоны определенного устройства./>.
        /// </summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Возвращает таблицу Sample по опрделенному шаблону./>.</returns>
        public async Task<List<SampleEntity>> GetByFilter(int id)
        {
            return await sampleRepository.GetByFilter(id);
        }

        /// <summary>
        /// Метод обновляет статус шаблона./>.
        /// <summary>
        /// <param name="values">Словарь объектов.</param>
        public async Task UpdateValues(Dictionary<int, bool> values)
        {
            await sampleRepository.UpdateValues(values);
        }

        /// <summary>
        /// Метод получает статусы шаблона./>.
        /// <summary>
        /// <returns>Возвращает словарь ID:Status./>.</returns>
        public async Task<Dictionary<int, bool>> GetStatusesAsync()
        {
            return await sampleRepository.GetStatusesAsync();
        }

        /// <summary>
        /// Метод поиска экземпляра по id.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса SampleEntity/>.</returns>
        public async Task<SampleEntity> FindById(int? id)
        {
            return await sampleRepository.FindById(id);
        }

        /// <summary>
        /// Метод удаляет экзмепляр класса SampleEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(int? id)
        {
            await sampleRepository.DeleteConfirmed(id);
        }
    }
}
