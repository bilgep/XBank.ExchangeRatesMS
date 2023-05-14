using XBank.ExchangeService.Entities;
using static System.Net.WebRequestMethods;

namespace XBank.ExchangeService.Services
{
    public class GetExchangeRateService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GetExchangeRateService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //public async Task<ExchangeResponseItem> GetExchangeRate(ExchangeRequestItem exchangeRequest)
        //{
        //    var exchangeRequest = new ExchangeRequestItem() {  FromCurrency = CurrenyNames.Euro, };
        //    var requestUrl = $"https://api.collectapi.com/economy/exchange?int=10&to={exchangeRequest.ToCurrency}&base={exchangeRequest.FromCurrency}";
        //    var client = _httpClientFactory.CreateClient();
        //    client.DefaultRequestHeaders.Add("authorization", "apikey your_token");
        //    client.DefaultRequestHeaders.Add("content-type", "application/json");
        //    var response = await client.GetAsync(requestUrl);

        //    // map response
        //    var responseItem = new ExchangeResponseItem() { FromCurrency = exchangeRequest.FromCurrency, ToCurrency = exchangeRequest.ToCurrency, Rate = float.Parse(response.StatusCode.ToString())};  //TODO[Bilge]

        //    return responseItem;

        //}
    }
}
