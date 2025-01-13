using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;
using DataAccess.Postgres.Repositories.IRepository;
using Microsoft.AspNetCore.Identity;

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

        /// <summary>
        /// Метод удаляет экзмепляр класса UserEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(int? id)
        {
            var userEntity = await dbContext.User.FindAsync(id);
            if (userEntity != null)
            {
                dbContext.User.Remove(userEntity);
            }

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса UserEntity/>.</returns>
        public async Task<UserEntity> FindById(int? id)
        {
            var userEntity = await dbContext.User.FindAsync(id);
            return userEntity;
        }

        /// <summary>
        /// Метод редактирования экземпляра UserEntity.
        /// <summary>
        /// <param name="userEntity">Имя объекта.</param>
        public async Task EditPost(UserEntity userEntity)
        {
            dbContext.Update(userEntity);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        public bool UserEntityExists(int id)
        {
            return dbContext.User.Any(e => e.Id == id);
        }

        /// <summary>
        /// Метод проверки пароля.
        /// <summary>
        /// <param name="userId">Имя объекта.</param>
        /// <param name="oldPassword">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        public async Task<bool> ValidatePasswordAsync(int userId, string oldPassword)
        {
            var passwordHasher = new PasswordHasher<UserEntity>();
            var userEntity = await dbContext.User.FindAsync(userId);
            // Проверяем хэш пароля
            var verificationResult = passwordHasher.VerifyHashedPassword(userEntity, userEntity.Password, oldPassword);

            return verificationResult == PasswordVerificationResult.Success;
        }

        /// <summary>
        /// Метод обновления пароля.
        /// <summary>
        /// <param name="userId">Имя объекта.</param>
        /// <param name="newPassword">Новый пароль.</param>
        /// <returns>Булевое значение/>.</returns>
        public async Task ChangePasswordAsync(int userId, string newPassword)
        {
            var userEntity = await dbContext.User.FindAsync(userId);
            var passwordHasher = new PasswordHasher<UserEntity>();
            userEntity.Password = passwordHasher.HashPassword(userEntity, newPassword);

            dbContext.Update(userEntity);
            await dbContext.SaveChangesAsync();
        }
    }
}
