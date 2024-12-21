using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres.Repositories
{
    internal class EquipmentRepository(DataContext dbContext) : IEquipmentRepository
    {

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист EquipmentEntity/>.</returns>
        public async Task<IEnumerable<EquipmentEntity>> GetAllAsync()
        {
            return await dbContext.Equipment
                .AsNoTracking()
                .Include(e => e.Plant)
                .OrderBy(e => e.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Метод добавляет экзмепляр класса EquipmentEntity в БД./>.
        /// <summary>
        /// <param name="equipmentEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса EquipmentEntity/>.</returns>
        public async Task<EquipmentEntity> Create(EquipmentEntity equipmentEntity)
        {
            await dbContext.Equipment.AddAsync(equipmentEntity);
            await dbContext.SaveChangesAsync();
            return equipmentEntity;
        }

        /// <summary>
        /// Метод удаляет экзмепляр класса EquipmentEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(int? id)
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
        /// <returns>Лист экземпляров класса EquipmentEntity/>.</returns>
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
        /// <returns>Лист экземпляров класса EquipmentEntity/>.</returns>
        public async Task<List<string>> GetAvailableDeviceNamesAsync()
        {
            var devices = await dbContext.Equipment
                 .AsNoTracking()
                 .Where(sy => sy.Sample != null && sy.Sample.Any(
                         s => s.Unity != null && s.Unity.Any())) // Устройства с привязанными Unity
                 .Select(e => e.Name)
                 .ToListAsync();
            return devices;
        }

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса EquipmentEntity/>.</returns>
        public async Task<EquipmentEntity> FindById(int? id)
        {
            var equipmentEntity = await dbContext.Equipment.FindAsync(id);
            return equipmentEntity;
        }

        /// <summary>
        /// Метод редактирования экземпляра EquipmentEntity.
        /// <summary>
        /// <param name="equipmentEntity">Имя объекта.</param>
        public async Task EditPost(EquipmentEntity equipmentEntity)
        {
            dbContext.Update(equipmentEntity);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        public bool EquipmentEntityExists(int id)
        {
            return dbContext.Equipment.Any(e => e.Id == id);
        }

    }
}
