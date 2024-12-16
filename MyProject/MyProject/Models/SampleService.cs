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
        /// <param name="name">Имя объекта.</param>
        /// <returns>Возвращает таблицу Sample по опрделенному шаблону./>.</returns>
        public async Task<List<SampleEntity>> GetByFilter(string name)
        {
            return await sampleRepository.GetByFilter(name);
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
    }
}
