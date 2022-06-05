using System.ComponentModel.DataAnnotations;

namespace broker.Models
{
    public class Stock
    {
        public int Id { get; set; }

        [Required]
        public string Ticker { get; set; } = null!;

        public decimal LastPrice { get; set; }

        [Required]
        public string Currency { get; set; } = null!;

        public List<Alert>? Alerts { get; set; }

        public Stock()
        {

        }
    }
}
