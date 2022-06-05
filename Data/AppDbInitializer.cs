using broker.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace broker.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext> ();
                context.Database.EnsureCreated();

                if (!context.Stock.Any())
                {
                    context.Stock.AddRange(new List<Stock>() {
                        new Stock { Ticker = "TBLE3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "RADL3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "CCRO3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "PCAR4.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "LAME4.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "MULT3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "ITSA4.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "CMIG4.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "BBDC3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "BBSE3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "BRML3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "LREN3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "UGPA3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "VALE5.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "PETR4.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "BBAS3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "EQTL3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "KLBN11.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "SBSP3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "OIBR4.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "TIMP3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "ENBR3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "ECOR3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "USIM5.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "JBSS3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "BBDC4.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "VIVT4.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "PETR3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "BRKM5.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "GOLL4.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "ITUB4.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "FIBR3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "KROT3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "CTIP3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "EMBR3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "BRPR3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "GOAU4.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "CSNA3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "CYRE3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "CESP6.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "HGTX3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "QUAL3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "CPLE6.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "RENT3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "ABEV3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "MRFG3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "MRVE3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "VALE3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "CSAN3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "RUMO3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "HYPE3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "SMLE3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "BVMF3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "CIEL3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "CPFE3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "BRFS3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "BRAP4.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "NATU3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "GGBR4.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "SANB11.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "ESTC3.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "SUZB5.SA", LastPrice = 0, Currency = "BRL" },
                        new Stock { Ticker = "ELET3.SA", LastPrice = 0, Currency = "BRL" }
                    });
                    context.SaveChanges();
                }
            }
        } 
    }
}
