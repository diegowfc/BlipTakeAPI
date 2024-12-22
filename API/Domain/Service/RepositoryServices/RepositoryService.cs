using Domain.Contracts.UseCases.GetRepositoryInformation;
using Domain.Entities.Account;
using Domain.Entities.Repository;
using Newtonsoft.Json;

namespace Domain.Service.RepositoryService
{
    public class RepositoryService: IGetRepositoryInformationUseCase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RepositoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Repository>> GetRepositoryInformationAsync()
        {
            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Add("User-Agent", "MyApp");

            var response = await client.GetAsync("https://api.github.com/users/takenet/repos");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Erro ao obter informações da API do GitHub.");
            }

            var content = await response.Content.ReadAsStringAsync();

            var repositories = JsonConvert.DeserializeObject<List<Repository>>(content);

            var oldestRepositories = repositories
                .OrderBy(repo => repo.created_at) 
                .Take(5)                         
                .ToList();

            return oldestRepositories;
        }

    }
}
