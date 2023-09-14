using System.ComponentModel.DataAnnotations;

namespace FalloutRP.DTO
{
    public class PlayerChangePasswordDTO
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
