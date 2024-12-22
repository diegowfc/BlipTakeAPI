using Domain.Entities.Repository;

namespace Domain.Contracts.UseCases.GetRepositoryInformation
{
    public interface IGetRepositoryInformationUseCase
    {
        Task<List<Repository>> GetRepositoryInformationAsync();
    }
}
