using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace FalloutRP.DTO
{
    public class MissionDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string ShortDescription { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }

    public class MissionCreateDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string ShortDescription { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public IEnumerable<int> ConcernedPlayers { get; set; } = Enumerable.Empty<int>();
    }
}
