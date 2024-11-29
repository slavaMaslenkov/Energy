using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repositories
{
    internal class UnityRepository (DataContext dbContext) : IUnityRepository
    {

        /// Метод получает все виды параметров из БД./>.
        /// </summary>
        /// <returns>Лист шаблонов устройства./>.</returns>
        /// <summary>
        public async Task<IEnumerable<UnityEntity>> GetAllAsync()
        {
            return await dbContext.Unity.ToListAsync();
        }

        /// Метод добавляет экзмепляр класса SampleEntity в БД./>.
        /// <summary>
        public async Task<UnityEntity> Create(UnityEntity unityEntity)
        {
            await dbContext.Unity.AddAsync(unityEntity);
            await dbContext.SaveChangesAsync();
            return unityEntity;
        }

        /// Метод получает параметры определенного шаблона устройства./>.
        /// </summary>
        /// <returns>Возвращает таблицу Unity по опрделенному шаблону./>.</returns>
        /// <summary>
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
                          .Where(u => u.Sample != null &&
                               u.Sample.Equipment != null &&
                               u.Sample.Equipment.Name == name);
            return await query.ToListAsync();
        }
    }
}
