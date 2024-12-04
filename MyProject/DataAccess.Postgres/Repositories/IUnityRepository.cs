using DataAccess.Postgres.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    public interface IUnityRepository
    {
        Task<UnityEntity> Create(UnityEntity unityEntity);
        Task<IEnumerable<UnityEntity>> GetAllAsync();
        Task<List<UnityEntity>> GetByFilter(string name);

        Task UpdateValues(Dictionary<int, string> values);
    }
}
