using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace broker.Models
{
    [DisplayName("Ação")]
    public class Stock
    {
        public int Id { get; set; }

        [Required]
        public string Ticker { get; set; } = null!;

        [DisplayName("Último Preço")]
        public decimal LastPrice { get; set; }

        [DisplayName("Moeda")]
        public string Currency { get; set; } = "BRL";

        [DisplayName("Alertas")]
        public List<Alert>? Alerts { get; set; }

        public Stock()
        {

        }
    }
}
