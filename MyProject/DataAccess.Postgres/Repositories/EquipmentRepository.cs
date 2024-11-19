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
            return await dbContext.Equipment.AsNoTracking().ToListAsync();
        }

        /// Метод добавляет экзмепляр класса EquipmentEntity в БД./>.
        /// <summary>
        public async Task<EquipmentEntity> Create(EquipmentEntity equipmentEntity)
        {
            await dbContext.Equipment.AddAsync(equipmentEntity);
            await dbContext.SaveChangesAsync();
            return equipmentEntity;
        }

        /// Метод ищет экзмепляр класса EquipmentEntity в БД по id./>.
        /// <summary>
        public async Task<EquipmentEntity> Delete(Guid? id)
        {
            
            var equipmentEntity = await dbContext.Equipment
                .FirstOrDefaultAsync(m => m.Id == id);
            return equipmentEntity;
        }

        /// Метод удаляет экзмепляр класса EquipmentEntity в БД./>.
        /// <summary>
        public async Task DeleteConfirmed(Guid? id)
        {
            var equipmentEntity = await dbContext.Equipment.FindAsync(id);
            if (equipmentEntity != null)
            {
                dbContext.Equipment.Remove(equipmentEntity);
            }

            await dbContext.SaveChangesAsync();
        }

        /// Метод получения списка устройств из БД./>.
        /// <summary>
        public async Task<List<string>> GetDeviceNamesAsync()
        {
            try
            {
                var devices = await dbContext.Equipment.AsNoTracking().Select(e => e.Name).ToListAsync();
                Console.WriteLine($"Найдено устройств: {devices.Count}");
                return devices;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении данных: {ex.Message}");
                throw;
            }
        }
    }
}
