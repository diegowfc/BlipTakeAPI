using Domain.Contracts.UseCases.GetAccountInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using Domain.Entities.Account;

namespace Domain.Service.AccountServices
{
    public class AccountService : IGetAccountInformationUseCase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Account> GetAccountInformationAsync()
        {
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("User-Agent", "MyApp");

            var response = await client.GetAsync("https://api.github.com/users/takenet");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Erro ao obter informações da API do GitHub.");
            }


            var content = await response.Content.ReadAsStringAsync();

            var account = JsonConvert.DeserializeObject<Account>(content);

            return account;
        }
    }
}
