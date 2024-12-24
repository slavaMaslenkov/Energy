using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    public interface ISystemRepository
    {
        /// <summary>
        /// Метод создает экземпляр класса />.
        /// </summary>
        ///<param name="equipmentId">Имя объекта.</param>
        ///<param name="subsystemIds">Имя объекта.</param>
        /// <returns>Лист SystemEntity/>.</returns>
        Task AttachSubsystemsToEquipment(int equipmentId, List<int> subsystemIds);

        /// <summary>
        /// Метод получает все подустройства конкретного устройства из БД./>.
        /// </summary>
        ///<param name="equipmentId">Имя объекта.</param>
        /// <returns>Лист SystemEntity/>.</returns>
        Task<List<SystemEntity>> GetAllByEquipment(int equipmentId);
    }
}
