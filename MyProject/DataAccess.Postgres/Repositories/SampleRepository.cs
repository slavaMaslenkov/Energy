using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    internal class SampleRepository (DataContext dbContext) : ISampleRepository
    {
        /// <summary>
        /// Метод получает все шаблоны из БД./>.
        /// </summary>
        /// <returns>Лист SampleEntity/>.</returns>
        public async Task<IEnumerable<SampleEntity>> GetAllAsync()
        {
            return await dbContext.Sample
                .Include(s => s.Equipment)
                .ToListAsync();
        }

        /// <summary>
        /// Метод добавляет экзмепляр класса SampleEntity в БД./>.
        /// <summary>
        /// <param name="sampleEntity">Имя шаблона.</param>
        /// <returns>Экземпляр класса SampleEntity/>.</returns>
        public async Task<SampleEntity> Create(SampleEntity sampleEntity)
        {
            await dbContext.Sample.AddAsync(sampleEntity);
            await dbContext.SaveChangesAsync();
            return sampleEntity;
        }

        /// <summary>
        /// Метод получает шаблоны определенного устройства./>.
        /// <summary>
        /// <param name="name">Имя объекта.</param>
        /// <returns>Возвращает таблицу Sample по опрделенному шаблону./>.</returns>
        public async Task<List<SampleEntity>> GetByFilter(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new List<SampleEntity>();
            }

            var query = dbContext.Sample
                          .AsNoTracking()
                          .Include(s => s.Equipment) // Включаем данные из Sample
                          .Where(s => s.Equipment.Name == name);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Метод обновляет статус шаблона./>.
        /// <summary>
        /// <param name="values">Словарь объектов.</param>
        public async Task UpdateValues(Dictionary<int, bool> values)
        {
            foreach (var kvp in values)
            {
                var entity = await dbContext.Sample.FindAsync(kvp.Key);
                if (entity != null)
                {
                    entity.Status = kvp.Value;
                }
            }

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод получает статусы шаблона./>.
        /// <summary>
        /// <returns>Возвращает словарь ID:Status./>.</returns>
        public async Task<Dictionary<int, bool>> GetStatusesAsync()
        {
            var entities = await dbContext.Sample
                .Select(e => new { e.Id, e.Status })
                .ToListAsync();

            return entities.ToDictionary(e => e.Id, e => e.Status);
        }
    }
}
