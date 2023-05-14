using Microsoft.AspNetCore.Mvc;

namespace XBank.M03.TransactionService.Controllers
{
    public class ExchangeTransactionController : Controller
    {
        public IActionResult ExecuteTransaction()
        {
            // TODO[Bilge] A Transaction pattern with Rollback feature will be implemented later


            return View();
        }
    }
}
