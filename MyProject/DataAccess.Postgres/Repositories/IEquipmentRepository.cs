using DataAccess.Postgres.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Postgres.Repositories
{
    public interface IEquipmentRepository
    {
        Task<EquipmentEntity> Create(EquipmentEntity equipmentEntity);
        Task<IEnumerable<EquipmentEntity>> GetAllAsync();
    }
}
