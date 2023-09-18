using FalloutRP.DTO;
using FalloutRPDAL;
using FalloutRPDAL.Entities;
using FalloutRPDAL.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace FalloutRP.Services
{
    public class PlayerService
    {
        private readonly FalloutRPContext _falloutRPContext;
        public PlayerService(FalloutRPContext falloutRPContext)
        {
            _falloutRPContext = falloutRPContext;
        }

        /// <summary>
        /// Get a list of all the players
        /// </summary>
        /// <returns>List of player</returns>
        public IEnumerable<PlayerDetailDTO> GetAllPlayer()
        {
            List<PlayerDetailDTO> players = new List<PlayerDetailDTO>();
            List<Player> playerList = _falloutRPContext.Players.ToList();
            foreach (Player player in playerList)
            {
                players.Add(new PlayerDetailDTO()
                {
                    id = player.Id,
                    pseudo = player.Pseudo,
                    team = player.Team,
                });
            }
            return players;
        }

        /// <summary>
        /// Get a Player entity by Pseudo
        /// </summary>
        /// <param name="Pseudo"></param>
        /// <returns>Player entity</returns>
        public Player? GetByUsername(string pseudo)
        {
            return _falloutRPContext.Players.FirstOrDefault(u => u.Pseudo == pseudo);
        }

        /// <summary>
        /// Create user and hash password
        /// </summary>
        public void Add(PlayerCreateDTO playerCreateDTO)
        {
            Player? player = _falloutRPContext.Players.FirstOrDefault(u => u.Pseudo == playerCreateDTO.pseudo);

            if (player != null)
            {
                throw new Exception("Ce nom d'utilisateur est déjà utilisé");
            }

            player = new Player()
            {
                Pseudo = playerCreateDTO.pseudo,
                Team = playerCreateDTO.team,
            };

            PasswordService.CreatePasswordHash(playerCreateDTO.password, out byte[] passwordHash, out byte[] passwordSalt);
            player.PasswordSalt = passwordSalt;
            player.PasswordHash = passwordHash;

            _falloutRPContext.Players.Add(player);
            _falloutRPContext.SaveChanges();
        }

        /// <summary>
        /// Delete a user
        /// The Belgrain user is the super administrator user, it cannot be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ValidationException"></exception>
        public void Delete(int idToDelete)
        {
            Player? player = _falloutRPContext.Players.FirstOrDefault(p => p.Id == idToDelete);

            if (player is null)
            {
                throw new KeyNotFoundException("L'utilisateur n'a pas été trouvé");
            }

            if (player.Pseudo.ToLower() == "superviseur")
            {
                throw new ValidationException("Cet utilisateur ne peut pas être supprimé");
            }

            _falloutRPContext.Remove(player);
            _falloutRPContext.SaveChanges();
        }

        /// <summary>
        /// Check password hash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns>Boolean</returns>
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (HMACSHA512 hmca = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmca.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="actorId"></param>
        /// <param name="userChangePasswordDTO"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="PasswordDoesNotMatchExeption"></exception>
        public void ChangePassword(PlayerChangePasswordDTO playerChangePasswordDTO)
        {
            Player? player = _falloutRPContext.Players.FirstOrDefault(u => u.Id == playerChangePasswordDTO.id);

            if (player == null)
            {
                throw new KeyNotFoundException("Cet utilisateur n'existe pas");
            }

            PasswordService.CreatePasswordHash(playerChangePasswordDTO.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
            player.PasswordHash = passwordHash;
            player.PasswordSalt = passwordSalt;

            _falloutRPContext.SaveChanges();
        }
    }
}
