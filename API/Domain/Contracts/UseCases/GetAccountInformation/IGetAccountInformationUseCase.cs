using Domain.Entities.Account;
using System.Threading.Tasks;

namespace Domain.Contracts.UseCases.GetAccountInformation
{
    public interface IGetAccountInformationUseCase
    {
        Task<Account> GetAccountInformationAsync();
    }
}
