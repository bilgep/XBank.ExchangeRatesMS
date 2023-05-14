using Microsoft.AspNetCore.Mvc;
using XBank.M03.TransactionService.Entities;
using XBank.M03.TransactionService.Repository;

namespace XBank.M03.TransactionService.Controllers
{
    [ApiController]
    [Route("[controller")]
    public class ExchangeTransactionController : Controller
    {
        private readonly ILogger<ExchangeTransactionController> _logger;
        private readonly ExchangeTransactionRepository _exchangeTransactionRepository;

        public ExchangeTransactionController(ILogger<ExchangeTransactionController> logger, ExchangeTransactionRepository exchangeTransactionRepository)
        {
            _logger = logger;
            _exchangeTransactionRepository = exchangeTransactionRepository;
        }

        [HttpPost]
        [Route("/execute")]
        public async Task<IActionResult> ExecuteTransaction(ClientExchangeTransaction clientExchangeTransaction)
        {
            // TODO[Bilge] A Transaction pattern with Rollback feature will be implemented later

            var response = await _exchangeTransactionRepository.AddExchangeTransaction(clientExchangeTransaction);

            return response ? Ok(response) : BadRequest();
        }
    }
}
