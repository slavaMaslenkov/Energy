using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;

namespace MyProject.Models
{
    internal class SubsystemService(ISubsystemRepository subsystemRepository) : ISubsystemService
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса SubsystemEntity в БД./>.
        /// <summary>
        /// <param name="subsytemEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса SubsystemEntity/>.</returns>
        public async Task<SubsystemEntity> Create(SubsystemEntity subsytemEntity)
        {
            return await subsystemRepository.Create(subsytemEntity);
        }

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист SubsystemEntity/>.</returns>
        public async Task<IEnumerable<SubsystemEntity>> GetAllAsync()
        {
            return await subsystemRepository.GetAllAsync();
        }

        /// <summary>
        /// Метод возвращает подсистемы конкретного устройства./>.
        /// <summary>
        /// <param name="equipmentId">Имя объекта.</param>
        /// <returns>Список экземпляров SubsystemEntity/>.</returns>
        public async Task<IEnumerable<SubsystemEntity>> GetByEquipmentIdAsync(int equipmentId)
        {
            return await subsystemRepository.GetByEquipmentIdAsync(equipmentId);
        }

        /// <summary>
        /// Метод удаляет экзмепляр класса SubsystemEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(int? id)
        {
            await subsystemRepository.DeleteConfirmed(id);
        }

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса SubsystemEntity/>.</returns>
        public async Task<SubsystemEntity> FindById(int? id)
        {
            return await subsystemRepository.FindById(id);
        }

        /// <summary>
        /// Метод редактирования экземпляра SubsystemEntity.
        /// <summary>
        /// <param name="subsystemEntity">Имя объекта.</param>
        public async Task EditPost(SubsystemEntity subsystemEntity)
        {
            await subsystemRepository.EditPost(subsystemEntity);
        }

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        public bool SubsystemEntityExists(int id)
        {
            return subsystemRepository.SubsystemEntityExists(id);
        }
    }
}
