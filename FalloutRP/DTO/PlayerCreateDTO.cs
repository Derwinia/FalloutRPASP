using FalloutRPDAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace FalloutRP.DTO
{
    public class PlayerCreateDTO
    {
        [Required]
        public string Pseudo { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public Team Team { get; set; } = new Team();
    }
}
