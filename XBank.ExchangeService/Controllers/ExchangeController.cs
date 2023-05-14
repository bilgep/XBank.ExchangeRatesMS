using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using XBank.ExchangeService.Entities;

namespace XBank.ExchangeService.Controllers
{
    public class ExchangeController : Controller
    {
        [HttpGet]
        public IActionResult UsdToEuro(ExchangeResponseItem exchangeItem)
        {

            var exchangeRequest = new ExchangeRequestItem { FromCurrency = CurrenyNames.Euro, ToCurrency = CurrenyNames.Usd, RequestTime = DateTime.UtcNow};

            var requestUrl = $"https://api.collectapi.com/economy/exchange?int=10&to={exchangeRequest.ToCurrency}&base={exchangeRequest.FromCurrency}";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("authorization", "apikey your_token");
            client.DefaultRequestHeaders.Add("content-type", "application/json");
            var response = client.GetAsync(requestUrl);

            // map response
            var responseItem = new ExchangeResponseItem() { FromCurrency = exchangeRequest.FromCurrency, ToCurrency = exchangeRequest.ToCurrency, Rate = 0 };  //TODO[Bilge]

            // Repository operations
            return Ok();
        }

        [HttpGet]
        public IActionResult EuroToUsd(ExchangeResponseItem exchangeItem)
        {
            // Repository operations
            return Ok();
        }
    }
}
