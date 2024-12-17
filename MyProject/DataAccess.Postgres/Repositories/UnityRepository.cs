using DataAccess.Postgres.Entity;
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
            return await dbContext.Unity
                .Include(u => u.Parameters)
                .ToListAsync();
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

        /// </summary>
        /// Метод получает параметры определенного шаблона устройства./>.
        /// </summary>
        /// <param name="name">Имя объекта.</param>
        /// <returns>Возвращает таблицу Unity по опрделенному шаблону./>.</returns>
        public async Task<List<UnityEntity>> GetByFilter(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new List<UnityEntity>();
            }

            var query = dbContext.Unity
                          .AsNoTracking()
                          .Include(u => u.Sample) // Включаем данные из Sample
                          .ThenInclude(s => s.Equipment) // Включаем данные из Equipment
                          .Include(u => u.Parameters)
                          .Where(u => u.Sample != null &&
                               u.Sample.Equipment != null &&
                               u.Sample.Equipment.Name == name)
                          .OrderBy(u => u.Parameters.Name); ;
            return await query.ToListAsync();
        }

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
    }
}
