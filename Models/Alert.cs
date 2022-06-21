using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace broker.Models
{
    public enum Order
    {
        BUY,
        SELL
    }

    [DisplayName("Alerta")]
    public class Alert
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Usuário")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser{ get; set; }

        [Required]
        [DisplayName("Ação")]
        public int StockId { get; set; }
        public Stock? Stock { get; set; }

        [Required]
        [DisplayName("Preço")]
        public decimal Price { get; set; }

        [DisplayName("Enviado?")]
        public bool WasSent { get; set; } = false;

        [Required]
        [DisplayName("Ordem")]
        public Order Order { get; set; } = Order.SELL;
        public Alert()
        {

        }
    }
}
