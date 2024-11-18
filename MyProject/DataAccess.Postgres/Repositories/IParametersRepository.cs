using DataAccess.Postgres.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    public interface IParametersRepository
    {
        Task<ParametersEntity> Create(ParametersEntity parametersEntity);
        Task<IEnumerable<ParametersEntity>> GetAllAsync();
    }
}
