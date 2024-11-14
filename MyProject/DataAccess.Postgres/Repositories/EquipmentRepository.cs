using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repositories
{
    internal class EquipmentRepository(DataContext dbContext) : IEquipmentRepository
    {
        ///AsNoTracking вытягивает данные без отслеживания         

        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист устройств./>.</returns>
        /// <summary>
        public async Task<IEnumerable<EquipmentEntity>> GetAllAsync()
        {
            return await dbContext.Equipment.ToListAsync();
        }

        /// Метод добавляет экзмепляр класса EquipmentEntity в БД./>.
        /// <summary>
        public async Task<EquipmentEntity> Create(EquipmentEntity equipmentEntity)
        {
            await dbContext.Equipment.AddAsync(equipmentEntity);
            await dbContext.SaveChangesAsync();
            return equipmentEntity;
        }
    }
}
