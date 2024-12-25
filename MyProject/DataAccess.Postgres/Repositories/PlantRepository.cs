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


        /// <summary>
        /// Метод удаляет экзмепляр класса PlantEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(int? id)
        {
            var plantEntity = await dbContext.Plant.FindAsync(id);
            if (plantEntity != null)
            {
                dbContext.Plant.Remove(plantEntity);
            }

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса PlantEntity/>.</returns>
        public async Task<PlantEntity> FindById(int? id)
        {
            var plantEntity = await dbContext.Plant.FindAsync(id);
            return plantEntity;
        }

        /// <summary>
        /// Метод редактирования экземпляра PlantEntity.
        /// <summary>
        /// <param name="plantEntity">Имя объекта.</param>
        public async Task EditPost(PlantEntity plantEntity)
        {
            dbContext.Update(plantEntity);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        public bool PlantEntityExists(int id)
        {
            return dbContext.Plant.Any(e => e.Id == id);
        }

    }
}
