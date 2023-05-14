using static XBank.ExchangeService.Controllers.ExchangeController;

namespace XBank.M01.ExchangeService.Entities
{
    public class ExchangeResponseItem
    {
        public bool Success { get; set; }
        public Result Result { get; set; }
    }

    public class Datum
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Rate { get; set; }
        public string CalculatedStr { get; set; }
        public double Calculated { get; set; }
    }

    public class Result
    {
        public string @Base { get; set; }
        public string LastUpdate { get; set; }
        public List<Datum> Data { get; set; }
    }
}
