using Microsoft.AspNetCore.Mvc;
using XBank.M02.ClientService.Entities;
using XBank.M02.ClientService.Repository;

namespace XBank.M02.ClientService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly ClientRepository _clientRepository;
        //private readonly HttpContextAccessor _httpContextAccessor;

        //public ClientController(ILogger<ClientController> logger, ClientRepository clientRepository, HttpContextAccessor httpContextAccessor)
        //{
        //    _logger = logger;
        //    _clientRepository = clientRepository;
        //    _httpContextAccessor = httpContextAccessor;
        //}

        public ClientController(ILogger<ClientController> logger, ClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        [HttpGet]
        [Route("/usdbalance")]
        public async Task<IActionResult> GetClientUsdBalance(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                _logger.LogWarning($"Bad request occured at {nameof(GetClientUsdBalance)}");
                return BadRequest();
            }
            var response = await _clientRepository.GetClientBalance(clientId, AccountTypes.Usd);
            if(response == null) { NoContent(); }

            return Ok(response);
        }

        [HttpGet]
        [Route("/eurobalance")]
        public async Task<IActionResult> GetClientEuroBalance(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                _logger.LogWarning($"Bad request occured at {nameof(GetClientUsdBalance)}");
                return BadRequest();
            }
            var response = await _clientRepository.GetClientBalance(clientId, AccountTypes.Euro);
            if (response == null) { NoContent(); }

            return Ok(response);
        }
    }
}
