using DataAccess.Postgres.Entity;

namespace MyProject.Models
{
    public interface ISampleService
    {
        Task<SampleEntity> Create(SampleEntity sampleEntity);
        Task<IEnumerable<SampleEntity>> GetAllAsync();

        /// </summary>
        /// Метод получает шаблоны определенного устройства./>.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <returns>Возвращает таблицу Sample по опрделенному шаблону./>.</returns>
        Task<List<SampleEntity>> GetByFilter(string name);
    }
}
