using DataAccess.Postgres.Entity;
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
    }
}
