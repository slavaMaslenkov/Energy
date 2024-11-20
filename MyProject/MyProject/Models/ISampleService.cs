using DataAccess.Postgres.Entity;

namespace MyProject.Models
{
    public interface ISampleService
    {
        Task<SampleEntity> Create(SampleEntity sampleEntity);
        Task<IEnumerable<SampleEntity>> GetAllAsync();
    }
}
