using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using XBank.ExchangeService.Entities;
using XBank.M01.ExchangeService.Entities;
using XBank.M01.ExchangeService.Persistence;

namespace XBank.ExchangeService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IExchangeRepositorty _exchangeRepository;
        private readonly ILogger<ExchangeController> _logger;

        public ExchangeController(IConfiguration configuration, IExchangeRepositorty exchangeRepository, ILogger<ExchangeController> logger)
        {
            _configuration = configuration;
            _exchangeRepository = exchangeRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("/usdtoeur")]
        public async Task<IActionResult> UsdToEuro(string amount)
        {
            try
            {
                var requestItem = new ExchangeRequestItem { FromCurrency = CurrenyNames.Usd, ToCurrency = CurrenyNames.Euro, FromAmount = amount, RequestTime = DateTime.UtcNow.ToString() };

                var isValid = float.TryParse(amount, out float parsedAmount);
                if (!string.IsNullOrWhiteSpace(amount) && isValid)
                {
                    var result = await _exchangeRepository.GetCalculatedAmount(requestItem);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }

        }


        [HttpGet]
        [Route("/eurtousd")]
        public async Task<IActionResult> EuroToUsd(string amount)
        {
            try
            {
                var requestItem = new ExchangeRequestItem { FromCurrency = CurrenyNames.Euro, ToCurrency = CurrenyNames.Usd, FromAmount = amount, RequestTime = DateTime.UtcNow.ToString() };

                var isValid = float.TryParse(amount, out float parsedAmount);
                if (!string.IsNullOrWhiteSpace(amount) && isValid)
                {
                    var result = await _exchangeRepository.GetCalculatedAmount(requestItem);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }

        }
    }
}
