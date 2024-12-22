using AutoMapper;
using Domain.Contracts.UseCases.GetAccountInformation;
using Domain.DTOs.AccountDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlipTakeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IGetAccountInformationUseCase _getInformationUseCase;
        private readonly IMapper _mapper;

        public AccountController(IGetAccountInformationUseCase getInformationUseCase, IMapper mapper)
        {
            _getInformationUseCase = getInformationUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccountInformation()
        {
            try
            {
                var account = await _getInformationUseCase.GetAccountInformationAsync();
                var accountOutputDTO = _mapper.Map<AccountOutputDTO>(account);
                return Ok(accountOutputDTO);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
