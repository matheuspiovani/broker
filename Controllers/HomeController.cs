﻿using broker.Helpers;
using Microsoft.AspNetCore.Mvc;

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
    }
}
