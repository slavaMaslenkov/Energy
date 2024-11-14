using DataAccess.Postgres.Entity;

namespace MyProject.Models
{
    public interface IEquipmentService
    {
        Task<EquipmentEntity> Create(EquipmentEntity equipmentEntity);
        Task<IEnumerable<EquipmentEntity>> GetAllAsync();
    }
}
