
namespace FalloutRPDAL.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Pseudo { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string Team { get; set; } = string.Empty;
    }
}
