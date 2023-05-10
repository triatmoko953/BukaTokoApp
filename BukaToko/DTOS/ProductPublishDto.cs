using System.ComponentModel.DataAnnotations;

namespace BukaToko.DTOS
{
    public class ProductPublishDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string Event { get; set; } = string.Empty;
    }
}
