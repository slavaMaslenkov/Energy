using DataAccess.Postgres.Entity;

namespace MyProject.Models
{
    public interface ISampleService
    {
        Task<SampleEntity> Create(SampleEntity sampleEntity);
        Task<IEnumerable<SampleEntity>> GetAllAsync();

        /// <summary>
        /// Метод получает шаблоны определенного устройства./>.
        /// <summary>
        /// <param name="name">Имя объекта.</param>
        /// <returns>Возвращает таблицу Sample по опрделенному шаблону./>.</returns>
        Task<List<SampleEntity>> GetByFilter(string name);

        /// <summary>
        /// Метод обновления значений в БД./>.
        /// <summary>
        /// <param name="values">Словарь.</param>
        Task UpdateValues(Dictionary<int, bool> values);
    }
}
