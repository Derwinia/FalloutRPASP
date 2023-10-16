using FalloutRPDAL.Entities;
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
    public class PlayerDetailDTO
    {
        public int Id { get; set; }
        public string Pseudo { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
    }
    public class PlayerCreateDTO
    {
        [Required]
        public string Pseudo { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public Team Team { get; set; } = new Team();
    }
    public class PlayerChangePasswordDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
