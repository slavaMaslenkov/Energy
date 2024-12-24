using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    internal class PlantRepository(DataContext dbContext) : IPlantRepository
    {

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист PlantEntity/>.</returns>
        public async Task<IEnumerable<PlantEntity>> GetAllAsync()
        {
            return await dbContext.Plant
                .AsNoTracking()
                .OrderBy(e => e.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Метод получает названия всех устройств из БД./>.
        /// </summary>
        /// <returns>Лист названий PlantEntity/>.</returns>
        public async Task<List<string>> GetAllAsyncPlants()
        {
            var devices = await dbContext.Plant
                .AsNoTracking()
                .Select(e => e.Name)
                .ToListAsync();
            return devices;
        }

        /// <summary>
        /// Метод добавляет экзмепляр класса PlantEntity в БД./>.
        /// <summary>
        /// <param name="plantEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса PlantEntity/>.</returns>
        public async Task<PlantEntity> Create(PlantEntity plantEntity)
        {
            await dbContext.Plant.AddAsync(plantEntity);
            await dbContext.SaveChangesAsync();
            return plantEntity;
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
