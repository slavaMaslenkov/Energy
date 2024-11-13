using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repositories
{
    public class EquipmentRepository
    {
        private readonly DataContext _dbContext;

        public EquipmentRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }


        ///AsNoTracking вытягивает данные без отслеживания         

        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист устройств./>.</returns>
        /// <summary>
        public async Task<List<EquipmentEntity>> Get()
        {
            return await _dbContext.Equipment
                .AsNoTracking()
                .ToListAsync();
        }

        /// Метод добавляет экзмепляр класса EquipmentEntity в БД./>.
        /// <summary>
        public async Task Add(Guid id, string name, string type, string description, string owner)
        {
            var equipmentEntity = new EquipmentEntity
            {
                Id = id,
                Name = name,
                Type = type,
                Description = description,
                Owner = owner                
            };

            await _dbContext.AddAsync(equipmentEntity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
