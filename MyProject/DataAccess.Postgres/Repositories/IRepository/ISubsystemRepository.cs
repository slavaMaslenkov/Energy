using DataAccess.Postgres.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    public interface ISubsystemRepository
    {
        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист SubsystemEntity/>.</returns>
        Task<IEnumerable<SubsystemEntity>> GetAllAsync();

        /// <summary>
        /// Метод добавляет экзмепляр класса SubsystemEntity в БД./>.
        /// <summary>
        /// <param name="subsystemEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса SubsystemEntity/>.</returns>
        Task<SubsystemEntity> Create(SubsystemEntity subsystemEntity);

        /// <summary>
        /// Метод возвращает подсистемы конкретного устройства./>.
        /// <summary>
        /// <param name="equipmentId">Имя объекта.</param>
        /// <returns>Список экземпляров SubsystemEntity/>.</returns>
        Task<IEnumerable<SubsystemEntity>> GetByEquipmentIdAsync(int equipmentId);

        /// <summary>
        /// Метод удаляет экзмепляр класса SubsystemEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        Task DeleteConfirmed(int? id);

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса SubsystemEntity/>.</returns>
        Task<SubsystemEntity> FindById(int? id);

        /// <summary>
        /// Метод редактирования экземпляра SubsystemEntity.
        /// <summary>
        /// <param name="subsystemEntity">Имя объекта.</param>
        Task EditPost(SubsystemEntity subsystemEntity);

        // <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        bool SubsystemEntityExists(int id);
    }
}
