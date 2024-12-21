using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Contracts.UseCases.GetAccountInformation
{
    public interface IGetInformationUseCase
    {
        Task<Account> GetAccountInformationAsync();
    }
}
