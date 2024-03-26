using System.ComponentModel.DataAnnotations;

namespace WebStore.ModelDTO;

public class CategoryUpdateDto
{
    [Required]
    public string Name { get; set; }
}
