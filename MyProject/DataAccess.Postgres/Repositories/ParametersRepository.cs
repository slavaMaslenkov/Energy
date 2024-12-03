using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    internal class ParametersRepository(DataContext dbContext) : IParametersRepository
    {

        /// <summary>
        /// Метод получает все устройства из БД./>.
        /// </summary>
        /// <returns>Лист ParametersEntity/>.</returns>
        public async Task<IEnumerable<ParametersEntity>> GetAllAsync()
        {
            return await dbContext.Parameters
                .AsNoTracking()
                .OrderBy(e => e.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Метод добавляет экзмепляр класса ParametersEntity в БД./>.
        /// <summary>
        /// <param name="parametersEntity">Имя объекта.</param>
        /// <returns>Экземпляр класса ParametersEntity/>.</returns>
        public async Task<ParametersEntity> Create(ParametersEntity parametersEntity)
        {
            await dbContext.Parameters.AddAsync(parametersEntity);
            await dbContext.SaveChangesAsync();
            return parametersEntity;
        }

        /// <summary>
        /// Метод ищет экзмепляр класса ParametersEntity в БД по id./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса ParametersEntity/>.</returns>
        public async Task<ParametersEntity> Delete(Guid? id)
        {
            var parametersEntity = await dbContext.Parameters
                .FirstOrDefaultAsync(m => m.Id == id);
            return parametersEntity;
        }

        /// <summary>
        /// Метод удаляет экзмепляр класса ParametersEntity в БД./>.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        public async Task DeleteConfirmed(Guid? id)
        {
            var parametersEntity = await dbContext.Parameters.FindAsync(id);
            if (parametersEntity != null)
            {
                dbContext.Parameters.Remove(parametersEntity);
            }

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод получения возможности редактирования.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Экземпляр класса ParametersEntity/>.</returns>
        public async Task<ParametersEntity> Edit(Guid? id)
        {
            var parametersEntity = await dbContext.Parameters.FindAsync(id);
            return parametersEntity;
        }

        /// <summary>
        /// Метод редактирования экземпляра ParametersEntity.
        /// <summary>
        /// <param name="equipmentEntity">Имя объекта.</param>
        public async Task EditPost(ParametersEntity parametersEntity)
        {
            dbContext.Update(parametersEntity);
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод проверки наличия экземпляра.
        /// <summary>
        /// <param name="id">Имя объекта.</param>
        /// <returns>Булевое значение/>.</returns>
        public bool ParametersEntityExists(Guid id)
        {
            return dbContext.Parameters.Any(e => e.Id == id);
        }
    }
}
