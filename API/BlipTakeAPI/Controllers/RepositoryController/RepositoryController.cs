using AutoMapper;
using Domain.Contracts.UseCases.GetAccountInformation;
using Domain.Contracts.UseCases.GetRepositoryInformation;
using Domain.DTOs.AccountDTO;
using Domain.DTOs.RepositoryDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlipTakeAPI.Controllers.RepositoryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly IGetRepositoryInformationUseCase _getRepositoryInformationUseCase;
        private readonly IMapper _mapper;

        public RepositoryController(IGetRepositoryInformationUseCase getRepositoryInformationUseCase, IMapper mapper)
        {
            _getRepositoryInformationUseCase = getRepositoryInformationUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRepositoryInformation()
        {
            try
            {
                var repositories = await _getRepositoryInformationUseCase.GetRepositoryInformationAsync();
                var repositoryOutputDTOs = _mapper.Map<List<RepositoryOutputDTO>>(repositories);
                return Ok(repositoryOutputDTOs);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

    }
}
