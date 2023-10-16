
using FalloutRPDAL.Entities.CharacterClasses;

namespace FalloutRPDAL.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Pseudo { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];

        // Foreign Keys
        public Team? Team { get; set; }
        public int? TeamId { get; set; }
        public IEnumerable<Mission>? Missions { get; set;}
        public Character? Character { get; set; }
    }
}
