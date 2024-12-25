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

        /// <summary>
        /// Метод возвращает подсистемы конкретного устройства./>.
        /// <summary>
        /// <param name="equipmentId">Имя объекта.</param>
        /// <returns>Список экземпляров SubsystemEntity/>.</returns>
        public async Task<IEnumerable<SubsystemEntity>> GetByEquipmentIdAsync(int equipmentId)
        {
            return await dbContext.System
                                   .Where(s => s.EquipmentID == equipmentId)
                                   .Select(s => s.Subsystem)
                                   .Distinct()
                                   .ToListAsync();
        }

        /// <summary>
        /// Метод удаляет экзмепляр класса SubsystemEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(int? id)
        {
            var subsystemEntity = await dbContext.Subsystem.FindAsync(id);
            if (subsystemEntity != null)
            {
                dbContext.Subsystem.Remove(subsystemEntity);
            }

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса SubsystemEntity/>.</returns>
        public async Task<SubsystemEntity> FindById(int? id)
        {
            var subsystemEntity = await dbContext.Subsystem.FindAsync(id);
            return subsystemEntity;
        }

        /// <summary>
        /// Метод редактирования экземпляра SubsystemEntity.
        /// <summary>
        /// <param name="subsystemEntity">Имя объекта.</param>
        public async Task EditPost(SubsystemEntity subsystemEntity)
        {
            dbContext.Update(subsystemEntity);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        public bool SubsystemEntityExists(int id)
        {
            return dbContext.Subsystem.Any(e => e.Id == id);
        }
    }
}
