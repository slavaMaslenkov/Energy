using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;
using DataAccess.Postgres.Repositories.IRepository;
using MyProject.Models.IService;

namespace MyProject.Models
{
    internal class UserService(IUserRepository userRepository) : IUserService
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса UserEntity в БД./>.
        /// <summary>
        /// <param name="userEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса USerEntity/>.</returns>
        public async Task<UserEntity> Create(UserEntity userEntity)
        {
            return await userRepository.Create(userEntity);
        }

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист UserEntity/>.</returns>
        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await userRepository.GetAllAsync();
        }

        /// <summary>
        /// Метод удаляет экзмепляр класса ParametersEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(int? id)
        {
            await userRepository.DeleteConfirmed(id);
        }

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса UserEntity/>.</returns>
        public async Task<UserEntity> FindById(int? id)
        {
            return await userRepository.FindById(id);
        }

        /// <summary>
        /// Метод редактирования экземпляра UserEntity.
        /// <summary>
        /// <param name="userEntity">Имя объекта.</param>
        public async Task EditPost(UserEntity userEntity)
        {
            await userRepository.EditPost(userEntity);
        }

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        public bool UserEntityExists(int id)
        {
            return userRepository.UserEntityExists(id);
        }

        /// <summary>
        /// Метод проверки пароля.
        /// <summary>
        /// <param name="userId">ID пользователя.</param>
        /// <param name="oldPassword">Старый пароль.</param>
        /// <param name="newPassword">Новый пароль.</param>
        /// <returns>Булевое значение/>.</returns>
        public Task<bool> ValidatePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            return userRepository.ValidatePasswordAsync(userId, oldPassword, newPassword);
        }

        /// <summary>
        /// Метод обновления пароля.
        /// <summary>
        /// <param name="userId">ID пользователя.</param>
        /// <param name="newPassword">Новый пароль.</param>
        /// <returns>Булевое значение/>.</returns>
        public Task ChangePasswordAsync(int userId, string newPassword)
        {
            return userRepository.ChangePasswordAsync(userId, newPassword);
        }
    }
}
