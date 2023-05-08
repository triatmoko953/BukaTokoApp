using System.ComponentModel.DataAnnotations;

namespace BukaToko.DTO
{
    public class CreateCartDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
