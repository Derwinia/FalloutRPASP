using System.ComponentModel.DataAnnotations;

namespace FalloutRP.DTO
{
    public class PlayerLoginDTO
    {
        [Required]
        public string pseudo { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
    }
}
