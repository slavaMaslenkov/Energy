using DataAccess.Postgres.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    internal class SampleRepository (DataContext dbContext) : ISampleRepository
    {
        ///AsNoTracking вытягивает данные без отслеживания         

        /// Метод получает все виды параметров из БД./>.
        /// </summary>
        /// <returns>Лист параметров./>.</returns>
        /// <summary>
        public async Task<IEnumerable<SampleEntity>> GetAllAsync()
        {
            return await dbContext.Sample.ToListAsync();
        }

        /// Метод добавляет экзмепляр класса SampleEntity в БД./>.
        /// <summary>
        public async Task<SampleEntity> Create(SampleEntity sampleEntity)
        {
            await dbContext.Sample.AddAsync(sampleEntity);
            await dbContext.SaveChangesAsync();
            return sampleEntity;
        }
    }
}
