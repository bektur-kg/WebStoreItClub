using System.ComponentModel.DataAnnotations;

namespace WebStore.Model.ModelDTO
{
    public class ShoppingCartProductsDTO
    {
        [Required]
        public int ShoppingCartId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int ProductQuantity { get; set; }
    }
}
