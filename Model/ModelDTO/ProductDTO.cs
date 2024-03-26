using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Model.ModelDTO
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
