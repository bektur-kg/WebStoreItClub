using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.ModelDTO;

public class SubCategoryCreationDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    public string ImageURL { get; set; }
    [Required]
    public string IconURL { get; set; }
    [Required]
    public int MainCategoryId { get; set; }
}
