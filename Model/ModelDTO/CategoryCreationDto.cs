using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Model;

namespace WebStore.ModelDTO;

public class CategoryCreationDto
{
    [Required]
    public string Name { get; set; }
}