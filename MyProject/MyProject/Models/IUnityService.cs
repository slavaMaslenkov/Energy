using DataAccess.Postgres.Entity;

namespace MyProject.Models
{
    public interface IUnityService
    {
        Task<UnityEntity> Create(UnityEntity unityEntity);
        Task<IEnumerable<UnityEntity>> GetAllAsync();
        Task<List<UnityEntity>> GetByFilter(string name);

    }
}
