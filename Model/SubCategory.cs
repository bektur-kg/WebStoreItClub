using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebStore.Model
{
    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageURL { get; set; }

        public string IconURL { get; set; }

        [ForeignKey("MainCategory")]
        public int MainCategoryId { get; set; }

        [JsonIgnore]
        public List<Product>? Product { get; set; }

        [JsonIgnore]
        public MainCategory? MainCategory { get; set; }
    }
}
