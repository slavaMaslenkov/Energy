using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;

namespace MyProject.Models
{
    internal class UnityService(IUnityRepository unityRepository) : IUnityService
    {
        public async Task<List<UnityEntity>> GetByFilter(string name)
        {
            return await unityRepository.GetByFilter(name);
        }

        public async Task<UnityEntity> Create(UnityEntity unityEntity)
        {
            return await unityRepository.Create(unityEntity);
        }

        public async Task<IEnumerable<UnityEntity>> GetAllAsync()
        {
            return await unityRepository.GetAllAsync();
        }
    }
}
