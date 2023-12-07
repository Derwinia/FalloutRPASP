using FalloutRP.DTO;
using FalloutRPDAL;
using FalloutRPDAL.Entities;
using FalloutRPDAL.Entities.CharacterClasses;
using FalloutRPDAL.Services;
using Microsoft.EntityFrameworkCore;
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

        public void PlayerCreate(PlayerCreateDTO playerCreateDTO)
        {
            Player? player = _falloutRPContext.Players.FirstOrDefault(u => u.Pseudo == playerCreateDTO.Pseudo);
            Character character;

            if (player != null)
            {
                throw new Exception("Ce nom d'utilisateur est déjà utilisé");
            }

            Team? team = _falloutRPContext.Teams.FirstOrDefault(t => t.Name == playerCreateDTO.Team);

            if (team == null || team.Name == "admin")
            {
                throw new Exception("Ce nom d'équipe n'existe pas");
            }

            PasswordService.PasswordHashCreate(playerCreateDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

            player = new Player()
            {
                Pseudo = playerCreateDTO.Pseudo,
                Team = team,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Character = new Character()
                {
                    Name = "nom du personnage",
                    Xp = 0,
                    XpToNext = 100,
                    Origin = "fort fort lointain",
                    Level = 1,
                    MeleeBonus = 0,
                    Defence = 0,
                    Initiative = 0,
                    HealthPoint = 10,
                    HealthPointMax = 10,
                    PoisonResilience = 0,
                    Background = "sort du tuto",
                    Caps = 0,
                    MaxWeight = 0,

                    BodyParts = new List<BodyPart>{
                        new BodyPart
                        {
                            Part = 1,
                            PhysicalResilience = 1,
                            RadiationResilience = 2,
                            EnergyResilience = 3,
                            HealthResilience = 4,
                        },
                        new BodyPart
                        {
                            Part = 2,
                            PhysicalResilience = 4,
                            RadiationResilience = 3,
                            EnergyResilience = 2,
                            HealthResilience = 1,
                        },
                        new BodyPart
                        {
                            Part = 3,
                            PhysicalResilience = 2,
                            RadiationResilience = 1,
                            EnergyResilience = 1,
                            HealthResilience = 0,
                        },
                        new BodyPart
                        {
                            Part = 4,
                            PhysicalResilience = 5,
                            RadiationResilience = 5,
                            EnergyResilience = 5,
                            HealthResilience = 5,
                        },
                        new BodyPart
                        {
                            Part = 5,
                            PhysicalResilience = 0,
                            RadiationResilience = 1,
                            EnergyResilience = 0,
                            HealthResilience = 1,
                        },
                        new BodyPart
                        {
                            Part = 6,
                            PhysicalResilience = 2,
                            RadiationResilience = 2,
                            EnergyResilience = 2,
                            HealthResilience = 2,
                        }
                    },
                    Attributes = new FalloutRPDAL.Entities.CharacterClasses.Attribute()
                    {
                        Strength = 1,
                        Perception = 2,
                        Endurance = 3,
                        Charisme = 4,
                        Intelligence = 5,
                        Agility = 6,
                        Luck = 7,
                        LuckPoints = 8,
                    },
                    Skill = new Skill()
                    {
                        RightHanded = true,
                        LeftHanded = false,
                        Athletics = false,
                        Athleticslvl = 0,
                        Lockpicking = false,
                        Lockpickinglvl = 0,
                        Speech = false,
                        Speechlvl = 0,
                        Stealth =false,
                        Stealthlvl = 0,
                        Medecine = false,
                        Medecinelvl = 0,
                        Driving = false,
                        Drivinglvl = 0,
                        Repair = false,
                        Repairlvl = 0,
                        Science = false,
                        Sciencelvl = 0,
                        Survival = false,
                        Survivallvl = 0,
                        Bartering = false,
                        Barteringlvl = 0,
                        BareHands = false,
                        BareHandslvl = 0,
                        MeleeWeapon = false,
                        MeleeWeaponlvl = 0,
                        LightWeapon = false,
                        LightWeaponlvl = 0,
                        HeavyWeapon = false,
                        HeavyWeaponlvl = 0,
                        EnergieWeapon = false,
                        EnergieWeaponlvl = 0,
                        ThrowingWeapon = false,
                        ThrowingWeaponlvl = 0,
                        Explosive = false,
                        Explosivelvl = 0,
                        Game = false,
                        Gamelvl = 0,
                    },
                    Inventory = new Inventory()
                    {

                    },
                }
            };
            _falloutRPContext.Players.Add(player);
            _falloutRPContext.SaveChanges();
        }

        public IEnumerable<PlayerDetailDTO> PlayerList()
        {
            List<PlayerDetailDTO> players = new List<PlayerDetailDTO>();
            List<Player> playerList = _falloutRPContext.Players
                .Include(p => p.Team)
                .ToList();
            foreach (Player player in playerList)
            {
                if(player.Team.Name != "admin")
                {
                    players.Add(new PlayerDetailDTO()
                    {
                        Id = player.Id,
                        Pseudo = player.Pseudo,
                        Team = player.Team.Name,
                    });
                }
            }
            return players;
        }

        public Player? GetByUsername(string pseudo)
        {
            return _falloutRPContext.Players.Include(t => t.Team).FirstOrDefault(u => u.Pseudo == pseudo);
        }

        public void PlayerDelete(int idToDelete)
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

            _falloutRPContext.Players.Remove(player);
            _falloutRPContext.SaveChanges();
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (HMACSHA512 hmca = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmca.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public void PasswordChange(PlayerChangePasswordDTO playerChangePasswordDTO)
        {
            Player? player = _falloutRPContext.Players.FirstOrDefault(u => u.Id == playerChangePasswordDTO.Id);

            if (player == null)
            {
                throw new KeyNotFoundException("Cet utilisateur n'existe pas");
            }

            PasswordService.PasswordHashCreate(playerChangePasswordDTO.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
            player.PasswordHash = passwordHash;
            player.PasswordSalt = passwordSalt;

            _falloutRPContext.SaveChanges();
        }

        public void TeamCreate(TeamDTO teamDTO)
        {
            Team? team = _falloutRPContext.Teams.FirstOrDefault(u => u.Name == teamDTO.Name);

            if (team != null)
            {
                throw new Exception("Ce nom d'équipe est déjà utilisé");
            }

            team = new Team()
            {
                Name = teamDTO.Name,
            };

            _falloutRPContext.Teams.Add(team);
            _falloutRPContext.SaveChanges();
        }

        public IEnumerable<TeamDTO> TeamList()
        {
            List<TeamDTO> teams = new List<TeamDTO>();
            List<Team> teamList = _falloutRPContext.Teams.ToList();
            foreach (Team team in teamList)
            {
                if(team.Name != "admin")
                teams.Add(new TeamDTO()
                {
                    Name = team.Name,
                });
            }
            return teams;

        }

        public void TeamDelete(string teamToDelete)
        {
            Team? team = _falloutRPContext.Teams.FirstOrDefault(t => t.Name == teamToDelete);

            if (team is null)
            {
                throw new KeyNotFoundException("La team n'a pas été trouvé");
            }

            if (team.Name.ToLower() == "admin")
            {
                throw new ValidationException("Cette team ne peut pas être supprimé");
            }

            _falloutRPContext.Teams.Remove(team);
            _falloutRPContext.SaveChanges();
        }
    }
}
