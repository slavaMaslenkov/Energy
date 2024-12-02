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

        public async Task<EquipmentEntity> Delete(Guid? id)
        {
            return await equipmentRepository.Delete(id);
        }

        public async Task DeleteConfirmed(Guid? id)
        {
            await equipmentRepository.DeleteConfirmed(id);
        }

        public async Task<List<string>> GetDeviceNamesAsync()
        {
            return await equipmentRepository.GetDeviceNamesAsync();
        }

        public async Task<List<string>> GetAvailableDeviceNamesAsync()
        {
            return await equipmentRepository.GetAvailableDeviceNamesAsync();
        }
        public async Task<EquipmentEntity> Edit(Guid? id)
        {
            return await equipmentRepository.Edit(id);
        }

        public async Task EditPost(EquipmentEntity equipmentEntity)
        {
            await equipmentRepository.EditPost(equipmentEntity);
        }

        public bool EquipmentEntityExists(Guid id)
        {
            return equipmentRepository.EquipmentEntityExists(id);
        }
    }
}
