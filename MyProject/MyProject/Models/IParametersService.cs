using DataAccess.Postgres.Entity;

namespace MyProject.Models
{
    public interface IParametersService
    {
        Task<ParametersEntity> Create(ParametersEntity parametersEntity);
        Task<IEnumerable<ParametersEntity>> GetAllAsync();
    }
}
