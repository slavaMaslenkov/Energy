using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    internal class SubsystemRepository(DataContext dbContext) : ISubsystemRepository
    {

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист SubsystemEntity/>.</returns>
        public async Task<IEnumerable<SubsystemEntity>> GetAllAsync()
        {
            return await dbContext.Subsystem
                .AsNoTracking()
                .OrderBy(e => e.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Метод добавляет экзмепляр класса SubsystemEntity в БД./>.
        /// <summary>
        /// <param name="subsystemEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса SubsystemEntity/>.</returns>
        public async Task<SubsystemEntity> Create(SubsystemEntity subsystemEntity)
        {
            await dbContext.Subsystem.AddAsync(subsystemEntity);
            await dbContext.SaveChangesAsync();
            return subsystemEntity;
        }
        /*
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
                 .Where(e => e.Sample != null && e.Sample.Any(s => s.Unity != null && s.Unity.Any())) // Устройства с привязанными Unity
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
        }*/

    }
}
