using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repositories
{
    internal class EquipmentRepository(DataContext dbContext) : IEquipmentRepository
    {
        ///AsNoTracking вытягивает данные без отслеживания         
        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист устройств./>.</returns>
        /// <summary>
        public async Task<IEnumerable<EquipmentEntity>> GetAllAsync()
        {
            return await dbContext.Equipment.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Метод добавляет экзмепляр класса EquipmentEntity в БД./>.
        /// <summary>
        public async Task<EquipmentEntity> Create(EquipmentEntity equipmentEntity)
        {
            await dbContext.Equipment.AddAsync(equipmentEntity);
            await dbContext.SaveChangesAsync();
            return equipmentEntity;
        }

        /// <summary>
        /// Метод ищет экзмепляр класса EquipmentEntity в БД по id./>.
        /// <summary>
        public async Task<EquipmentEntity> Delete(Guid? id)
        {
            
            var equipmentEntity = await dbContext.Equipment
                .FirstOrDefaultAsync(m => m.Id == id);
            return equipmentEntity;
        }

        /// <summary>
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

        /// <summary>
        /// Метод получения списка устройств из БД./>.
        /// <summary>
        public async Task<List<string>> GetDeviceNamesAsync()
        {
            var devices = await dbContext.Equipment
                .AsNoTracking()
                .Select(e => e.Name)
                .ToListAsync();
            return devices;
        }

        /// <summary>
        /// Метод получения названий экземпляров EquipmentEntity,
        /// у которых есть экземпляр UnityEntity.
        /// <summary>
        public async Task<List<string>> GetAvailableDeviceNamesAsync()
        {
            var devices = await dbContext.Equipment
                 .AsNoTracking()
                 .Where(e => e.Sample != null && e.Sample.Any(s => s.Unity != null && s.Unity.Any())) // Устройства с привязанными Unity
                 .Select(e => e.Name)
                 .ToListAsync();
            return devices;
        }
    }
}
