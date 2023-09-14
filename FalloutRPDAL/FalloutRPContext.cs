using Microsoft.EntityFrameworkCore;
using FalloutRPDAL.Configs;
using FalloutRPDAL.Entities;
using FalloutRPDAL.Services;

namespace FalloutRPDAL
{
    public class FalloutRPContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public FalloutRPContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PlayerConfig());

            LoadPlayer(builder);
        }

        private void LoadPlayer(ModelBuilder builder)
        {
            PasswordService.CreatePasswordHash("mdp", out byte[] passwordHash, out byte[] passwordSalt);


            builder.Entity<Player>().HasData(new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Pseudo = "superviseur",
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    Team = "admin"
                }
            });
        }
    }
}
