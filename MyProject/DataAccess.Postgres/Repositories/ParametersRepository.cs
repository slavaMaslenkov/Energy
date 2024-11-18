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
        ///AsNoTracking вытягивает данные без отслеживания         

        /// Метод получает все виды параметров из БД./>.
        /// </summary>
        /// <returns>Лист параметров./>.</returns>
        /// <summary>
        public async Task<IEnumerable<ParametersEntity>> GetAllAsync()
        {
            return await dbContext.Parameters.ToListAsync();
        }

        /// Метод добавляет экзмепляр класса ParametersEntity в БД./>.
        /// <summary>
        public async Task<ParametersEntity> Create(ParametersEntity parametersEntity)
        {
            await dbContext.Parameters.AddAsync(parametersEntity);
            await dbContext.SaveChangesAsync();
            return parametersEntity;
        }
    }
}
