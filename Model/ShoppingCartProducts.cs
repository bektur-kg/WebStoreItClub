using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebStore.Model
{
    public class ShoppingCartProducts
    {
        [Key]
        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ShoppingCart")]
        public int ShoppingCartId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [JsonIgnore]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [JsonIgnore]
        public ShoppingCarts? ShoppingCarts { get; set; }

        public Product? Product { get; set; }
    }
}
