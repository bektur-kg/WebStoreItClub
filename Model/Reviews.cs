using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebStore.Model
{
    public class Reviews
    {
        [Key]
        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int Grade { get; set; } = 0;

        [JsonIgnore]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [JsonIgnore]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }
    }
}
