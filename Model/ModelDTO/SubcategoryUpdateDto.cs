using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebStore.Model;

namespace WebStore.ModelDTO;

public class SubCategoryUpdateDTO
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string ImageURL { get; set; }

    [Required]
    public string IconURL { get; set; }

    [Required]
    public int MainCategoryId { get; set; }
}
