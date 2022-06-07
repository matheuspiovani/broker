using broker.Data;
using broker.Helpers;
using broker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace broker.Jobs
{
    public class AlertJob
    {
        IServiceProvider _serviceProvider;
        public AlertJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult?> UpdatePricesAndSendMail()
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            using (ApplicationDbContext _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
            {

                Console.WriteLine("Run Update Stock Prices");
                var stocks = _context.Stock.Select(s => s.Ticker).ToListAsync();
                string tickers = string.Join(
                    ",",
                    stocks.Result);

                var r = await YahooFinanceHelper.GetQuotesAsync(tickers);

                Console.WriteLine(r);

                JObject json = JObject.Parse(r);

                foreach (var result in json["quoteResponse"]["result"])
                {
                    string ticker = result["symbol"].ToString();
                    decimal value = Convert.ToDecimal(result["regularMarketPrice"]);

                    Stock stock = await _context.Stock.Where(s => s.Ticker.Equals(ticker)).FirstAsync();
                    stock.LastPrice = value;
                    _context.Update(stock);

                    CheckAndSendMail(_context, stock, value);
                }
                await _context.SaveChangesAsync();
                Console.WriteLine("Finish Update Stock Prices");
            }

            return null;
        }

        private async void CheckAndSendMail(ApplicationDbContext _context, Stock stock, decimal newPrice)
        {
            var sellAlerts = _context.Alert.Where(a =>
                !a.WasSent && a.StockId == stock.Id && a.Price <= newPrice && a.Order.Equals(Order.SELL)
            ).ToListAsync();

            foreach (Alert alert in sellAlerts.Result)
            {
                Console.WriteLine("Alerta " + alert.Id + " enviado.");
                alert.WasSent = true;
                _context.Update(alert);
                MailingHelper.SendMail(alert.Email, "Alerta de Venda para " + alert.Stock.Ticker + "! Preço atingiu " + newPrice);
            }

            var buyAlerts = _context.Alert.Where(a =>
                !a.WasSent && a.StockId == stock.Id && a.Price >= newPrice && a.Order.Equals(Order.BUY)
            ).ToListAsync();

            foreach (Alert alert in buyAlerts.Result)
            {
                Console.WriteLine("Alerta " + alert.Id + " enviado.");
                MailingHelper.SendMail(alert.Email, "Alerta de Compra para " + alert.Stock.Ticker + "! Preço atingiu " + newPrice);
                alert.WasSent = true;
                _context.Update(alert);
            }
        }
    }
}
