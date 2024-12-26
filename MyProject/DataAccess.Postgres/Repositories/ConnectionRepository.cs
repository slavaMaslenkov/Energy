using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    internal class ConnectionRepository(DataContext dbContext) : IConnectionRepository
    {

        /// <summary>
        /// Метод получает все параметры из БД, связанных с выбранной подсистемой./>.
        /// </summary>
        /// <param name="subsystemId">Имя объекта.</param>
        /// <returns>Лист EquipmentEntity/>.</returns>
        public async Task<List<object>> GetParametersBySubsystem(int subsystemId)
        {
            // Получение всех параметров, связанных с выбранной подсистемой
            var connections = await dbContext.Connection
                .Include(c => c.Parameters)
                .Where(c => c.SubsystemID == subsystemId)
                .Select(c => new
                {
                    id = c.ParametersID,
                    name = c.Parameters.Name
                })
                .ToListAsync();

            return connections.Cast<object>().ToList();
        }

        /// <summary>
        /// Метод создает экземпляр класса />.
        /// </summary>
        ///<param name="subsystemId">Имя объекта.</param>
        ///<param name="parametersIds">Имя объекта.</param>
        /// <returns>Лист SystemEntity/>.</returns>
        public async Task AttachParametersToSubsystem(int subsystemId, List<int> parametersIds)
        {
            foreach (var parameterId in parametersIds)
            {
                var connectionEntity = new ConnectionEntity
                {
                    SubsystemID = subsystemId,
                    ParametersID = parameterId
                };

                await dbContext.Connection.AddAsync(connectionEntity);
            }

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод находит экземпляр класса  ConnectionEntity/>.
        /// </summary>
        ///<param name="subsystemId">Имя объекта.</param>
        ///<param name="parameterId">Имя объекта.</param>
        /// <returns>Экземпляр ConnectionEntity/>.</returns>
        public async Task<ConnectionEntity> GetConnectionBySubsystemAndParameterAsync(int subsystemId, int parameterId)
        {
            // Предположим, что у вас есть контекст базы данных, и вы выполняете запрос для поиска нужной связи
            return await dbContext.Connection
                                 .FirstOrDefaultAsync(c => c.SubsystemID == subsystemId && c.ParametersID == parameterId);
        }
    }
}
