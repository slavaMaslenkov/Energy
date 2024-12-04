using DataAccess.Postgres.Entity;

namespace MyProject.Models
{
    public interface IParametersService
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса ParametersEntity в БД./>.
        /// <summary>
        /// <param name="parametersEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса ParametersEntity/>.</returns>
        Task<ParametersEntity> Create(ParametersEntity parametersEntity);

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист ParametersEntity/>.</returns>
        Task<IEnumerable<ParametersEntity>> GetAllAsync();

        /// <summary>
        /// Метод ищет экзмепляр класса ParametersEntity в БД по id./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса ParametersEntity/>.</returns>
        Task<ParametersEntity> Delete(int? id);

        /// <summary>
        /// Метод удаляет экзмепляр класса ParametersEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        Task DeleteConfirmed(int? id);

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса ParametersEntity/>.</returns>
        Task<ParametersEntity> Edit(int? id);

        /// <summary>
        /// Метод редактирования экземпляра ParametersEntity.
        /// <summary>
        /// <param name="parametersEntity">Имя объекта.</param>
        Task EditPost(ParametersEntity parametersEntity);

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        bool ParametersEntityExists(int id);
    }
}
