using DataAccess.Postgres.Entity;

namespace MyProject.Models.IService
{
    public interface IUserService
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
    }
}
