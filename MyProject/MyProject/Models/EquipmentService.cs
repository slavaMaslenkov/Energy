using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;

namespace MyProject.Models
{
    internal class EquipmentService(IEquipmentRepository equipmentRepository) : IEquipmentService
    {
        public async Task<EquipmentEntity> Create(EquipmentEntity equipmentEntity)
        {
           return await equipmentRepository.Create(equipmentEntity);
        }

        public async Task<IEnumerable<EquipmentEntity>> GetAllAsync()
        {
            return await equipmentRepository.GetAllAsync();
        }
    }
}
