using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;
using DataAccess.Postgres.Repositories.IRepository;

namespace DataAccess.Postgres.Repositories
{
    internal class UserRepository(DataContext dbContext) : IUserRepository
    {
        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист UserEntity/>.</returns>
        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await dbContext.User
                .AsNoTracking()
                .Include(e => e.Role)
                .OrderBy(e => e.UserName)
                .ToListAsync();
        }

        /// <summary>
        /// Метод добавляет экзмепляр класса UserEntity в БД./>.
        /// <summary>
        /// <param name="userEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса UserEntity/>.</returns>
        public async Task<UserEntity> Create(UserEntity userEntity)
        {
            // Проверяем, что пользователь с таким именем ещё не существует
            if (await dbContext.User.AnyAsync(u => u.UserName == userEntity.UserName))
                throw new InvalidOperationException("User with the same username already exists.");

            await dbContext.User.AddAsync(userEntity);
            await dbContext.SaveChangesAsync();
            return userEntity;
        }
    }
}
