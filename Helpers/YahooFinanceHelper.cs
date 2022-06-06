using broker.Models;

namespace broker.Helpers
{
    public class YahooFinanceHelper
    {
		/* Get quote info from YahooFinance
		 * Tickers: stock tickers joined by ','
		*/
		public static async Task<string> GetQuotesAsync(string Tickers)
        {
			var client = new HttpClient();

			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(YahooFinanceSettings.baseurl + "/market/v2/get-quotes?region=BR&symbols=" + Tickers),
				Headers =
				{
					{ "X-RapidAPI-Host", YahooFinanceSettings.x_rapidAPI_host },
					{ "X-RapidAPI-Key", YahooFinanceSettings.x_rapidAPI_key },
				},
			};

			var response = await client.SendAsync(request);
			try
            {
				response.EnsureSuccessStatusCode();
			}
			catch (HttpRequestException e)
            {
				Console.WriteLine("Error on GetQuotesAsync");
				Console.WriteLine(e.Message);
			}
			var body = await response.Content.ReadAsStringAsync();

			return body;
		}
    }
}
