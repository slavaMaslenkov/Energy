using DataAccess.Postgres.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    public interface ISampleRepository
    {
        Task<SampleEntity> Create(SampleEntity SampleEntity);
        Task<IEnumerable<SampleEntity>> GetAllAsync();

        /// </summary>
        /// Метод получает шаблоны определенного устройства./>.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <returns>Возвращает таблицу Sample по опрделенному шаблону./>.</returns>
        Task<List<SampleEntity>> GetByFilter(string name);
    }
}
