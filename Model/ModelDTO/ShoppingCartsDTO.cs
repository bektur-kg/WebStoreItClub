using System.ComponentModel.DataAnnotations;

namespace WebStore.Model.ModelDTO
{
    public class ShoppingCartsDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
