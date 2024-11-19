using DataAccess.Postgres.Entity;

namespace MyProject.Models
{
    public interface IEquipmentService
    {
        Task<EquipmentEntity> Create(EquipmentEntity equipmentEntity);
        Task<IEnumerable<EquipmentEntity>> GetAllAsync();
        Task<EquipmentEntity> Delete(Guid? id);
        Task DeleteConfirmed(Guid? id);
        Task<List<string>> GetDeviceNamesAsync();
    }
}
