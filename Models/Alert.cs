using System.ComponentModel.DataAnnotations;

namespace broker.Models
{
    public enum Order
    {
        BUY,
        SELL
    }

    public class Alert
    {
        
        public int Id { get; set; }

        [Required]
        public int StockId { get; set; }
        public Stock? Stock { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool WasSent { get; set; } = false;

        [Required]
        public Order Order { get; set; } = Order.SELL;

        [EmailAddress]
        public string Email { get; set; } = null!;
        public Alert()
        {

        }
    }
}
