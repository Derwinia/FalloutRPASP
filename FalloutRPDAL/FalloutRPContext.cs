using Microsoft.EntityFrameworkCore;
using FalloutRPDAL.Configs;
using FalloutRPDAL.Entities;


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
        }
    }
}
