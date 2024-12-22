using Domain.Entities.Repository;

namespace Domain.Contracts.UseCases.GetRepositoryInformation
{
    public interface IGetRepositoryInformationUseCase
    {
        Task<Repository> GetRepositoryInformationAsync();
    }
}
