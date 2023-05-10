using System.ComponentModel.DataAnnotations;

namespace BukaToko.DTOS
{
    public class TopUpPublishedDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public decimal Cash { get; set; }
        [Required]
        public string Event { get; set; } = string.Empty;
    }
}
