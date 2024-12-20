using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                .Include(s => s.System)
                .ThenInclude(sy => sy.Equipment)
                .ToListAsync();
        }

        /// <summary>
        /// Метод получает шаблоны из БД со статусом "В редакции"./>.
        /// </summary>
        /// <returns>Лист SampleEntity/>.</returns>
        public async Task<IEnumerable<SampleEntity>> GetAvailableAsync()
        {
            return await dbContext.Sample
                .Include(s => s.System)
                .ThenInclude(sy => sy.Equipment)
                .Where(s => s.Status == false)
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
        /// Метод создает список экзмепляров класса UnityEntity на основе 
        /// другого экземпляра./>.
        /// <summary>
        /// <param name="equipmentID">Имя шаблона.</param>
        /// <returns>Экземпляр класса SampleEntity/>.</returns>
        public async Task<SampleEntity> CreateBasedOn(int equipmentID, SampleEntity sampleEntity)
        {
            // определяем последний Sample
            var latestSample = dbContext.Sample
                .AsNoTracking()
                .Where(s => s.System != null &&
                       s.System.Equipment != null &&
                       s.System.Equipment.Id == equipmentID)
                .OrderByDescending(s => s.DateCreated)
                .FirstOrDefault();

            //добавляем новый шаблон на основе старого пока без параметров
            await dbContext.Sample.AddAsync(sampleEntity);
            await dbContext.SaveChangesAsync();

            if (latestSample != null)
            {
                var parameters = dbContext.Unity
                    .Include(u => u.Parameters)
                    .Where(u => u.SampleID == latestSample.Id)
                    .ToList();

                //добавлляем параметры к шаблону
                foreach (var unity in parameters)
                {
                    var newUnity = new UnityEntity
                    {
                        SampleID = sampleEntity.Id, // Связываем с новым Sample
                        ParametersID = unity.ParametersID, // Связываем с тем же параметром
                    };
                    await dbContext.Unity.AddAsync(newUnity);
                }
                await dbContext.SaveChangesAsync();
            }
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
                          .Include(s => s.System)
                          .ThenInclude(sy => sy.Equipment) // Включаем данные из Sample
                          .Where(sy => sy.System.Equipment.Name == name);

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

        /// <summary>
        /// Метод поиска экземпляра по id.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса SampleEntity/>.</returns>
        public async Task<SampleEntity> FindById(int? id)
        {
            var sampleEntity = await dbContext.Sample.FindAsync(id);
            return sampleEntity;
        }

        /// <summary>
        /// Метод удаляет экзмепляр класса SampleEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(int? id)
        {
            var sampleEntity = await dbContext.Sample.FindAsync(id);
            if (sampleEntity != null)
            {
                dbContext.Sample.Remove(sampleEntity);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
