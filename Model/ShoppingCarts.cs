using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebStore.Model
{
    public class ShoppingCarts
    {
        [Key]
        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description {  get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [JsonIgnore]
        public List<ShoppingCartProducts>? ShoppingCartProducts { get; set; }
    }
}
