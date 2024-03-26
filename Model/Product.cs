using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebStore.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageURL { get; set; }

        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Grade { get; set; } = 0;

        public int FreqPurchases { get; set; } = 0;

        [JsonIgnore]
        public SubCategory? SubCategory { get; set; } 

        [JsonIgnore]
        public List<Reviews>? Reviews { get; set; }

        [JsonIgnore]
        public List<ShoppingCartProducts>? ShoppingCartProducts { get; set; } 
    }
}
