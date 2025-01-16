using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Enums;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.Postgres.Repositories
{
    internal class UnityRepository (DataContext dbContext) : IUnityRepository
    {
        /// <summary>
        /// Метод получает спсиок значений параметров конкретного шаблона./>.
        /// <summary>
        /// <returns>Лист шаблонов устройства/>.</returns>
        public async Task<IEnumerable<UnityEntity>> GetAllAsync()
        {
            var unities = await dbContext.Unity
               .Include(u => u.Connection)                        // Связь с Connection
               .ThenInclude(c => c.Subsystem)
               .Include(u => u.Right)
               .ThenInclude(s => s.Role)
               .Include(u => u.Connection.Parameters)            // Связь Connection -> Parameters
               .Include(u => u.Sample)                           // Связь Unity -> Sample
               .ToListAsync();

            foreach (var unity in unities)
            {
                if (unity.Right != null && unity.Right.Any())
                {
                    foreach (var right in unity.Right)
                    {
                        if (Enum.IsDefined(typeof(Role), right.Role.Id))
                        {
                            right.Role.Name = ((Role)right.Role.Id).GetDescription();
                        }
                    }
                }
            }

            return unities;
        }

        /// <summary>
        /// Метод добавляет экзмепляр класса UnityEntity в БД./>.
        /// <summary>
        /// <param name="unityEntity">Имя объекта.</param>
        /// <returns>Лист шаблонов устройства/>.</returns>
        public async Task<UnityEntity> Create(UnityEntity unityEntity)
        {
            await dbContext.Unity.AddAsync(unityEntity);
            await dbContext.SaveChangesAsync();
            return unityEntity;
        }

        /// <summary>
        /// Метод удаляет экзмепляр класса UnityEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(int? id)
        {
            var unityEntity = await dbContext.Unity.FindAsync(id);
            if (unityEntity != null)
            {
                dbContext.Unity.Remove(unityEntity);
            }

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса UnityEntity/>.</returns>
        public async Task<UnityEntity> FindById(int? id)
        {
            var unityEntity = await dbContext.Unity.FindAsync(id);
            return unityEntity;
        }

        /// <summary>
        /// Метод получает параметры определенного шаблона устройства./>.
        /// </summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Возвращает таблицу Unity по опрделенному шаблону.</returns>
        public async Task<List<UnityEntity>> GetByFilter(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return new List<UnityEntity>();
            }

            var query = await dbContext.Unity
                  .AsNoTracking() // Не отслеживаем изменения
                  .Include(u => u.Right) // 
                  .ThenInclude(s => s.Role)
                  .Include(u => u.Sample) // Включаем данные из Sample
                  .ThenInclude(s => s.Equipment) // Включаем данные из Equipment через Sample
                  .Include(u => u.Connection)
                  .ThenInclude(c => c.Subsystem)
                  .Include(u => u.Connection)// Включаем данные из Connection (если необходимо)
                  .ThenInclude(c => c.Parameters) // Включаем параметры через Connection
                  .Where(u => u.Sample != null &&
                              u.Sample.Equipment != null && // Проверяем, что Sample и Equipment не null
                              u.Sample.Equipment.Id == id) // Фильтруем по имени оборудования
                  .OrderBy(u => u.Connection.Parameters.Name)
                  .ToListAsync(); ;

            foreach (var unity in query)
            {
                if (unity.Right != null && unity.Right.Any())
                {
                    foreach (var right in unity.Right)
                    {
                        if (Enum.IsDefined(typeof(Role), right.Role.Id))
                        {
                            right.Role.Name = ((Role)right.Role.Id).GetDescription();
                        }
                    }
                }
            }

            return query;
        }

        /// <summary>
        /// Метод обновляет значения параметров в БД./>.
        /// </summary>
        /// <param name="values">Словарь парарметров и значений.</param>
        public async Task UpdateValues(Dictionary<int, string> values)
        {
            foreach (var kvp in values)
            {
                var id = kvp.Key; // ID строки
                var newValue = kvp.Value; // Новое значение Value

                var entity = await dbContext.Unity.FindAsync(id);
                if (entity != null)
                {
                    entity.Value = newValue;
                }
            }

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод возвращает параметры для по определенному шаблону./>.
        /// </summary>
        /// <param name="sampleId">ID шаблонаа.</param>
        /// <returns>Возвращает параметры по опрделенному шаблону.</returns>
        public async Task<IEnumerable<UnityEntity>> GetBySampleIdAsync(int? sampleId)
        {
            if (sampleId == null)
            {
                return Enumerable.Empty<UnityEntity>();
            }

            return await dbContext.Unity
                .Where(u => u.SampleID == sampleId)
                .Include(u => u.Connection)
                .Include(u => u.Right)
                .Include(u => u.Sample)
                .ToListAsync();
        }
    }
}
