
namespace FalloutRPDAL.Entities
{
    public class Player
    {
        public Guid id { get; set; }
        public string Pseudo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
    }
}
