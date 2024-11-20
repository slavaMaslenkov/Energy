using DataAccess.Postgres.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    public interface ISampleRepository
    {
        Task<SampleEntity> Create(SampleEntity SampleEntity);
        Task<IEnumerable<SampleEntity>> GetAllAsync();
    }
}
