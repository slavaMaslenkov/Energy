using DataAccess.Postgres.Entity;
using DataAccess.Postgres.Repositories;

namespace MyProject.Models
{
    internal class ParametersService(IParametersRepository parametersRepository) : IParametersService
    {
        public async Task<ParametersEntity> Create(ParametersEntity parametersEntity)
        {
            return await parametersRepository.Create(parametersEntity);
        }

        public async Task<IEnumerable<ParametersEntity>> GetAllAsync()
        {
            return await parametersRepository.GetAllAsync();
        }
    }
}
