using FalloutRPDAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace FalloutRP.DTO
{
    public class PlayerCreateDTO
    {
        [Required]
        public string pseudo { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
        [Required]
        public Team team { get; set; }
    }
}
