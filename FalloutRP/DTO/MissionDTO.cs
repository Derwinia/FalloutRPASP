using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace FalloutRP.DTO
{
    public class MissionDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string ShortDescription { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Status { get; set; } = string.Empty;
    }

    public class MissionGroupByTeamDTO
    {
        [Required]
        public string Team { get; set; } = string.Empty;
        [Required]
        public List<MissionDTO> Missions { get; set;} = new List<MissionDTO>();
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
