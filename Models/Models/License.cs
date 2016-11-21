using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class License
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
    }
}