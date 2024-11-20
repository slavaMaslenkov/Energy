using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;

namespace MyProject.Models
{
    internal class SampleService(ISampleRepository sampleRepository) : ISampleService
    {
        public async Task<SampleEntity> Create(SampleEntity sampleEntity)
        {
            return await sampleRepository.Create(sampleEntity);
        }

        public async Task<IEnumerable<SampleEntity>> GetAllAsync()
        {
            return await sampleRepository.GetAllAsync();
        }
    }
}
