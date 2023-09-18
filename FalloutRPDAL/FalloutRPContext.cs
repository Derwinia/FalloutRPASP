using Microsoft.EntityFrameworkCore;
using FalloutRPDAL.Configs;
using FalloutRPDAL.Entities;
using FalloutRPDAL.Services;

namespace FalloutRPDAL
{
    public class FalloutRPContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Rule> Rules { get; set; }

        public FalloutRPContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PlayerConfig());
            builder.ApplyConfiguration(new RuleConfig());

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

            builder.Entity<Rule>().HasData(new List<Rule>
            {
                new Rule
                {
                    Id = 1,
                    Order = 1,
                    Name = "règle n°1",
                    ShortDescription = "petite description",
                    Description = "longue description"
                },
                new Rule
                {
                    Id = 2,
                    Order = 2,
                    Name = "règle n°2",
                    ShortDescription = "petite description2",
                    Description = "longue description2"
                },
                new Rule
                {
                    Id = 3,
                    Order = 3,
                    Name = "règle n°3",
                    ShortDescription = "petite description3",
                    Description = "longue description3"
                }
            });
        }
    }
}
