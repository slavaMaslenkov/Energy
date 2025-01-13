using DataAccess.Postgres.Entity;


namespace DataAccess.Postgres.Repositories.IRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса UserEntity в БД./>.
        /// <summary>
        /// <param name="userEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса USerEntity/>.</returns>
        Task<UserEntity> Create(UserEntity userEntity);

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист UserEntity/>.</returns>
        Task<IEnumerable<UserEntity>> GetAllAsync();

        /// <summary>
        /// Метод удаляет экзмепляр класса UserEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        Task DeleteConfirmed(int? id);

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса UserEntity/>.</returns>
        Task<UserEntity> FindById(int? id);

        /// <summary>
        /// Метод редактирования экземпляра UserEntity.
        /// <summary>
        /// <param name="userEntity">Имя объекта.</param>
        Task EditPost(UserEntity userEntity);

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        bool UserEntityExists(int id);

        /// <summary>
        /// Метод проверки пароля.
        /// <summary>
        /// <param name="userId">ID пользователя.</param>
        /// <param name="oldPassword">Старый пароль.</param>
        /// <returns>Булевое значение/>.</returns>
        Task<bool> ValidatePasswordAsync(int userId, string oldPassword);

        /// <summary>
        /// Метод обновления пароля.
        /// <summary>
        /// <param name="userId">ID пользователя.</param>
        /// <param name="newPassword">Новый пароль.</param>
        /// <returns>Булевое значение/>.</returns>
        Task ChangePasswordAsync(int userId, string newPassword);
    }
}
