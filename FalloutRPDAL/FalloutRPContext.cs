using Microsoft.EntityFrameworkCore;
using FalloutRPDAL.Configs;
using FalloutRPDAL.Entities;
using FalloutRPDAL.Services;
using FalloutRPDAL.Entities.CharacterClasses;
using Attribute = FalloutRPDAL.Entities.CharacterClasses.Attribute;

namespace FalloutRPDAL
{
    public class FalloutRPContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Ammo> Ammos { get; set; }
        public DbSet<Entities.CharacterClasses.Attribute> Attributes { get; set; }
        public DbSet<BodyPart> BodyParts { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Equipement> Equipements { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Inventory> Inventorys { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Perk> Perks { get; set; }
        public DbSet<Reputation> Reputations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Weapon> Weapons { get; set; }


        public FalloutRPContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PlayerConfig());
            builder.ApplyConfiguration(new RuleConfig());

            LoadPlayer(builder);
            LoadTeam(builder);
            LoadRule(builder);
            LoadCharacter(builder);
            LoadAttribute(builder);
            LoadSkill(builder);
            LoadBodyPart(builder);
            LoadReputation(builder);
            LoadPerk(builder);
            LoadWeapon(builder);
            LoadInventory(builder);
            LoadAmmo(builder);
            LoadChemical(builder);
            LoadDrink(builder);
            LoadEquipement(builder);
            LoadFood(builder);
            LoadMaterial(builder);
        }

        private void LoadPlayer(ModelBuilder builder)
        {
            PasswordService.PasswordHashCreate("mdp", out byte[] passwordHash, out byte[] passwordSalt);


            builder.Entity<Player>().HasData(new List<Player>
            {
                new Player
                {
                    Id = 1,
                    Pseudo = "superviseur",
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    TeamId = 1,
                },
                new Player
                {
                    Id = 2,
                    Pseudo = "player1",
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    TeamId = 2,
                },
            });
        }
        private void LoadTeam(ModelBuilder builder)
        {
            builder.Entity<Team>().HasData(new List<Team>
            {
                new Team
                {
                    Id = 1,
                    Name = "admin",
                },
                new Team
                {
                    Id = 2,
                    Name = "team1",
                },
            });
        }
        private void LoadRule(ModelBuilder builder)
        {
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
        private void LoadCharacter(ModelBuilder builder)
        {
            builder.Entity<Character>().HasData(new List<Character>
            {
                new Character
                {
                    Id = 1,
                    Name = "perso 1",
                    Xp = 0,
                    XpToNext = 100, 
                    Origin = "laba",
                    Level = 1,
                    MeleeBonus = 0,
                    Defence = 0,
                    Initiative = 0,
                    HealthPoint = 10,
                    HealthPointMax = 10,
                    PoisonResilience = 0,
                    Background = "sort du tuto",
                    Caps = 100,
                    MaxWeight = 120,
                    PlayerId = 2,
                }
            });
        }
        private void LoadAttribute(ModelBuilder builder)
        {
            builder.Entity<Attribute>().HasData(new List<Attribute>
            {
                new Attribute
                {
                    Id = 1,
                    Strength = 10,
                    Perception = 11,
                    Endurance = 12,
                    Charisme = 13,
                    Intelligence = 14,
                    Agility = 15,
                    Luck = 16,
                    LuckPoints = 17,
                    CharacterId = 1,
                }
            });
        }
        private void LoadSkill(ModelBuilder builder)
        {
            builder.Entity<Skill>().HasData(new List<Skill>
            {
                new Skill
                {
                    Id = 1,
                    RightHanded = true,
                    LeftHanded = false,
                    Athletics = true,
                    Athleticslvl = 1,
                    Lockpicking = false,
                    Lockpickinglvl = 1,
                    Speech = false,
                    Speechlvl = 1,
                    Stealth =false,
                    Stealthlvl = 1,
                    Medecine = false,
                    Medecinelvl = 1,
                    Driving = false,
                    Drivinglvl = 1,
                    Repair = false,
                    Repairlvl = 1,
                    Science = false,
                    Sciencelvl = 1,
                    Survival = true,
                    Survivallvl = 1,
                    Bartering = false,
                    Barteringlvl = 1,
                    BareHands = false,
                    BareHandslvl = 1,
                    MeleeWeapon = false,
                    MeleeWeaponlvl = 1,
                    LightWeapon = false,
                    LightWeaponlvl = 1,
                    HeavyWeapon = false,
                    HeavyWeaponlvl = 1,
                    EnergieWeapon = false,
                    EnergieWeaponlvl = 1,
                    ThrowingWeapon = false,
                    ThrowingWeaponlvl = 1,
                    Explosive = false,
                    Explosivelvl = 1,
                    Game = true,
                    Gamelvl = 1,
                    CharacterId = 1,
                }
            });
        }
        private void LoadBodyPart(ModelBuilder builder)
        {
            builder.Entity<BodyPart>().HasData(new List<BodyPart>
            {
                new BodyPart
                {
                    Id = 1,
                    Part = 1,
                    PhysicalResilience = 1,
                    RadiationResilience = 2,
                    EnergyResilience = 3,
                    HealthResilience = 4,
                    CharacterId = 1,
                },
                new BodyPart
                {
                    Id = 2,
                    Part = 2,
                    PhysicalResilience = 4,
                    RadiationResilience = 3,
                    EnergyResilience = 2,
                    HealthResilience = 1,
                    CharacterId = 1,
                },
                new BodyPart
                {
                    Id = 3,
                    Part = 3,
                    PhysicalResilience = 2,
                    RadiationResilience = 1,
                    EnergyResilience = 1,
                    HealthResilience = 0,
                    CharacterId = 1,
                },
                new BodyPart
                {
                    Id = 4,
                    Part = 4,
                    PhysicalResilience = 5,
                    RadiationResilience = 5,
                    EnergyResilience = 5,
                    HealthResilience = 5,
                    CharacterId = 1,
                },
                new BodyPart
                {
                    Id = 5,
                    Part = 5,
                    PhysicalResilience = 0,
                    RadiationResilience = 1,
                    EnergyResilience = 0,
                    HealthResilience = 1,
                    CharacterId = 1,
                },
                new BodyPart
                {
                    Id = 6,
                    Part = 6,
                    PhysicalResilience = 2,
                    RadiationResilience = 2,
                    EnergyResilience = 2,
                    HealthResilience = 2,
                    CharacterId = 1,
                },
            });
        }
        private void LoadReputation(ModelBuilder builder)
        {
            builder.Entity<Reputation>().HasData(new List<Reputation>
            {
                new Reputation
                {
                    Id = 1,
                    Name = "Humain",
                    Rank = 3,
                    CharacterId = 1,
                },
                new Reputation
                {
                    Id = 2,
                    Name = "Goule",
                    Rank = 1,
                    CharacterId = 1,
                }
            });
        }
        private void LoadPerk(ModelBuilder builder)
        {
            builder.Entity<Perk>().HasData(new List<Perk>
            {
                new Perk
                {
                    Id = 1,
                    Name = "tueur",
                    Rank = 1,
                    Effect = "Tue",
                    CharacterId = 1,
                },
                new Perk
                {
                    Id = 2,
                    Name = "beau parleur",
                    Rank = 2,
                    Effect = "Dit de joli mots",
                    CharacterId = 1,
                }
            });
        }
        private void LoadWeapon(ModelBuilder builder)
        {
            builder.Entity<Weapon>().HasData(new List<Weapon>
            {
                new Weapon
                {
                    Id = 1,
                    Name = "pistolet",
                    TN = 1,
                    DC = 1,
                    PhysicalDamage = true,
                    EnergyDamage = false,
                    RadiationDamage = false,
                    PoisonDamage = false,
                    Effects = "none",
                    Proprieties = "none",
                    RateOfFire = 1,
                    Range = 20,
                    Ammo = 1,
                    Weigth = 5,
                    CharacterId = 1,
                }
            });
        }
        private void LoadInventory(ModelBuilder builder)
        {
            builder.Entity<Inventory>().HasData(new List<Inventory>
            {
                new Inventory
                {
                    Id = 1,
                    CharacterId = 1,
                }
            });
        }
        private void LoadAmmo(ModelBuilder builder)
        {
            builder.Entity<Ammo>().HasData(new List<Ammo>
            {
                new Ammo
                {
                    Id = 1,
                    Name = "9mm",
                    Quantity = 1,
                    Weight = 1,
                    InventoryId= 1,
                }
            });
        }
        private void LoadChemical(ModelBuilder builder)
        {
            builder.Entity<Chemical>().HasData(new List<Chemical>
            {
                new Chemical
                {
                    Id = 1,
                    Name = "Soufre",
                    Quantity = 1,
                    Weight = 1,
                    InventoryId= 1,
                }
            });
        }
        private void LoadDrink(ModelBuilder builder)
        {
            builder.Entity<Drink>().HasData(new List<Drink>
            {
                new Drink
                {
                    Id = 1,
                    Name = "eau",
                    Quantity = 1,
                    Weight = 1,
                    InventoryId= 1,
                }
            });
        }
        private void LoadEquipement(ModelBuilder builder)
        {
            builder.Entity<Equipement>().HasData(new List<Equipement>
            {
                new Equipement
                {
                    Id = 1,
                    Name = "crochet",
                    Quantity = 1,
                    Weight = 1,
                    InventoryId= 1,
                }
            });
        }
        private void LoadFood(ModelBuilder builder)
        {
            builder.Entity<Food>().HasData(new List<Food>
            {
                new Food
                {
                    Id = 1,
                    Name = "barre de chocolat",
                    Quantity = 1,
                    Weight = 1,
                    InventoryId= 1,
                }
            });
        }
        private void LoadMaterial(ModelBuilder builder)
        {
            builder.Entity<Material>().HasData(new List<Material>
            {
                new Material
                {
                    Id = 1,
                    Name = "metal",
                    Quantity = 1,
                    Weight = 1,
                    InventoryId= 1,
                }
            });
        }
    }
}
