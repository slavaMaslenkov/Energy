using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;

namespace MyProject.Models
{
    internal class ParametersService(IParametersRepository parametersRepository) : IParametersService
    {
        /// <summary>
        /// Метод добавляет экзмепляр класса ParametersEntity в БД./>.
        /// <summary>
        /// <param name="parametersEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса ParametersEntity/>.</returns>
        public async Task<ParametersEntity> Create(ParametersEntity parametersEntity)
        {
            return await parametersRepository.Create(parametersEntity);
        }

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист ParametersEntity/>.</returns>
        public async Task<IEnumerable<ParametersEntity>> GetAllAsync()
        {
            return await parametersRepository.GetAllAsync();
        }

        /// <summary>
        /// Метод удаляет экзмепляр класса ParametersEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(int? id)
        {
            await parametersRepository.DeleteConfirmed(id);
        }

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса ParametersEntity/>.</returns>
        public async Task<ParametersEntity> FindById(int? id)
        {
            return await parametersRepository.FindById(id);
        }

        /// <summary>
        /// Метод редактирования экземпляра ParametersEntity.
        /// <summary>
        /// <param name="parametersEntity">Имя объекта.</param>
        public async Task EditPost(ParametersEntity parametersEntity)
        {
            await parametersRepository.EditPost(parametersEntity);
        }

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        public bool ParametersEntityExists(int id)
        {
            return parametersRepository.ParametersEntityExists(id);
        }
    }
}
