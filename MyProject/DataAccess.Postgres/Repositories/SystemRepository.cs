using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Postgres.Repositories
{
    internal class SystemRepository(DataContext dbContext) : ISystemRepository
    {
        /// <summary>
        /// Метод получает все подустройства конкретного устройства из БД./>.
        /// </summary>
        ///<param name="name">Имя объекта.</param>
        /// <returns>Лист SystemEntity/>.</returns>
        public async Task<List<SystemEntity>> GetAllByEquipment(string name)
        {
            return await dbContext.System
                .AsNoTracking()
                .Include(s => s.Equipment)
                .Where(s => s.Equipment.Name == name)
                .ToListAsync();
        }

        /// <summary>
        /// Метод создает экземпляр класса />.
        /// </summary>
        ///<param name="equipmentId">Имя объекта.</param>
        ///<param name="subsystemIds">Имя объекта.</param>
        /// <returns>Лист SystemEntity/>.</returns>
        public async Task AttachSubsystemsToEquipment(int equipmentId, List<int> subsystemIds)
        {
            foreach (var subsystemId in subsystemIds)
            {
                var systemEntity = new SystemEntity
                {
                    EquipmentID = equipmentId,
                    SubsystemID = subsystemId
                };

                await dbContext.System.AddAsync(systemEntity);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
