using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;

namespace MyProject.Models
{
    internal class SampleService(ISampleRepository sampleRepository) : ISampleService
    {
        public async Task<SampleEntity> Create(SampleEntity sampleEntity)
        {
            return await sampleRepository.Create(sampleEntity);
        }

        public async Task<IEnumerable<SampleEntity>> GetAllAsync()
        {
            return await sampleRepository.GetAllAsync();
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
        /// Метод обновления значений в БД./>.
        /// <summary>
        /// <param name="values">Словарь.</param>
        public async Task UpdateValues(Dictionary<int, bool> values)
        {
            await sampleRepository.UpdateValues(values);
        }
    }
}
