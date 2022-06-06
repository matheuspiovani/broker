using broker.Helpers;
using broker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace broker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // POST: Home/SendMail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMail(string To, string Message)
        {
            MailingHelper.SendMail(To, Message);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> YahooFinanceTest()
        {
            var r = await YahooFinanceHelper.GetQuotesAsync("MGLU3.SA,CSAN3.SA");
            if(r == null)
            {
                return StatusCode(500);
            }


            return Ok(r);
        }
    }
}
