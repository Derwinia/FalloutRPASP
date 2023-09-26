using System.ComponentModel.DataAnnotations;

namespace FalloutRP.DTO
{
    public class PlayerLoginDTO
    {
        [Required]
        public string Pseudo { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
