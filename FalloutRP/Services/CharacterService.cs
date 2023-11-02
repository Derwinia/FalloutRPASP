using FalloutRP.DTO;
using FalloutRPDAL;
using FalloutRPDAL.Entities;
using FalloutRPDAL.Entities.CharacterClasses;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FalloutRP.Services
{
    public class CharacterService
    {
        private readonly FalloutRPContext _falloutRPContext;
        public CharacterService(FalloutRPContext falloutRPContext)
        {
            _falloutRPContext = falloutRPContext;
        }
        public CharacterDTO? CharacterGetById(int id)
        {


            Character character = _falloutRPContext.Characters
                .Include(a => a.Attributes)
                .Include(s => s.Skill)
                .Include(b => b.BodyParts)
                .Include(r => r.Reputations)
                .Include(w => w.Weapons)
                .Include(p => p.Perks)
                .Include(i => i.Inventory)
                .ThenInclude(a => a.Ammos)
                .Include(i => i.Inventory)
                .ThenInclude(c => c.Chemicals)
                .Include(i => i.Inventory)
                .ThenInclude(d => d.Drinks)
                .Include(i => i.Inventory)
                .ThenInclude(e => e.Equipements)
                .Include(i => i.Inventory)
                .ThenInclude(f => f.Foods)
                .Include(i => i.Inventory)
                .ThenInclude(m => m.Materials)
                .FirstOrDefault(c => c.Id == id);

            if (character == null)
            {
                throw new KeyNotFoundException("Cet utilisateur n'existe pas");
            }

            List<BodyPartDTO> bodyParts = new List<BodyPartDTO>();
            
            foreach (BodyPart bodypart in character.BodyParts)
            {
                BodyPartDTO bp = new BodyPartDTO
                {
                    Part = bodypart.Part,
                    PhysicalResilience = bodypart.PhysicalResilience,
                    RadiationResilience = bodypart.RadiationResilience,
                    EnergyResilience = bodypart.EnergyResilience,
                    HealthResilience = bodypart.HealthResilience,
                };
                bodyParts.Add(bp);
            }

            List<ReputationDTO> reputations = new List<ReputationDTO>();

            foreach (Reputation reputation in character.Reputations)
            {
                ReputationDTO rep = new ReputationDTO
                {
                    Name = reputation.Name,
                    Rank = reputation.Rank
                };
                reputations.Add(rep);
            }

            List<WeaponDTO> weapons = new List<WeaponDTO>();

            foreach (Weapon weapon in character.Weapons)
            {
                WeaponDTO weap = new WeaponDTO
                {
                    Name = weapon.Name,
                    TN = weapon.TN,
                    DC = weapon.DC,
                    PhysicalDamage = weapon.PhysicalDamage,
                    EnergyDamage = weapon.EnergyDamage,
                    RadiationDamage = weapon.RadiationDamage,
                    PoisonDamage = weapon.PoisonDamage,
                    Effects = weapon.Effects,
                    Proprieties = weapon.Proprieties,
                    RateOfFire = weapon.RateOfFire,
                    Range = weapon.Range,
                    Ammo = weapon.Ammo,
                    Weigth = weapon.Weigth,
                };
                weapons.Add(weap);
            }

            List<PerkDTO> perks = new List<PerkDTO>();

            foreach (Perk perk in character.Perks)
            {
                PerkDTO pk = new PerkDTO
                {
                    Name = perk.Name,
                    Rank = perk.Rank,
                    Effect = perk.Effect,
                };
                perks.Add(pk);
            }

            List<AmmoDTO> ammos = new List<AmmoDTO>();

            foreach (Ammo ammo in character.Inventory.Ammos)
            {
                AmmoDTO am = new AmmoDTO
                {
                    Name = ammo.Name,
                    Quantity = ammo.Quantity,
                    Weight = ammo.Weight,
                };
                ammos.Add(am);
            }

            List<ChemicalDTO> chemicals = new List<ChemicalDTO>();

            foreach (Chemical chemical in character.Inventory.Chemicals)
            {
                ChemicalDTO chem = new ChemicalDTO
                {
                    Name = chemical.Name,
                    Quantity = chemical.Quantity,
                    Weight = chemical.Weight,
                };
                chemicals.Add(chem);
            }

            List<DrinkDTO> drinks = new List<DrinkDTO>();

            foreach (Drink drink in character.Inventory.Drinks)
            {
                DrinkDTO drk = new DrinkDTO
                {
                    Name = drink.Name,
                    Quantity = drink.Quantity,
                    Weight = drink.Weight,
                };
                drinks.Add(drk);
            }

            List<EquipementDTO> equipements = new List<EquipementDTO>();

            foreach (Equipement equipement in character.Inventory.Equipements)
            {
                EquipementDTO equip = new EquipementDTO
                {
                    Name = equipement.Name,
                    Quantity = equipement.Quantity,
                    Weight = equipement.Weight,
                };
                equipements.Add(equip);
            }

            List<FoodDTO> foods = new List<FoodDTO>();

            foreach (Food food in character.Inventory.Foods)
            {
                FoodDTO fd = new FoodDTO
                {
                    Name = food.Name,
                    Quantity = food.Quantity,
                    Weight = food.Weight,
                };
                foods.Add(fd);
            }

            List<MaterialDTO> materials = new List<MaterialDTO>();

            foreach (Material material in character.Inventory.Materials)
            {
                MaterialDTO mat = new MaterialDTO
                {
                    Name = material.Name,
                    Quantity = material.Quantity,
                    Weight = material.Weight,
                };
                materials.Add(mat);
            }

            CharacterDTO characterDTO = new CharacterDTO()
            {
                Name = character.Name,
                Xp = character.Xp,
                XpToNext = character.XpToNext,
                Origin = character.Origin,
                Level = character.Level,
                MeleeBonus = character.MeleeBonus,
                Defence = character.Defence,
                Initiative = character.Initiative,
                HealthPoint = character.HealthPoint,
                HealthPointMax = character.HealthPointMax,
                MentalHealthPoint = character.MentalHealthPoint,
                MentalHealthPointMax = character.MentalHealthPointMax,
                PoisonResilience = character.PoisonResilience,
                Background = character.Background,
                Caps = character.Caps,
                MaxWeight = character.MaxWeight,
                Attributes = new AttributeDTO
                {
                    Strength = character.Attributes.Strength,
                    Perception = character.Attributes.Perception,
                    Endurance = character.Attributes.Endurance,
                    Charisme = character.Attributes.Charisme,
                    Intelligence = character.Attributes.Intelligence,
                    Agility = character.Attributes.Agility,
                    Luck = character.Attributes.Luck,
                    LuckPoints = character.Attributes.LuckPoints,
                },
                Skills = new SkillDTO {
                    RightHanded = character.Skill.RightHanded,
                    LeftHanded = character.Skill.LeftHanded,
                    Athletics = character.Skill.Athletics,
                    Lockpicking = character.Skill.Lockpicking,
                    Lockpickinglvl = 0,
                    Speech = character.Skill.Speech,
                    Speechlvl = 0,
                    Stealth = character.Skill.Stealth,
                    Stealthlvl = 0,
                    Medecine = character.Skill.Medecine,
                    Medecinelvl = 0,
                    Driving = character.Skill.Driving,
                    Drivinglvl = 0,
                    Repair = character.Skill.Repair,
                    Repairlvl = 0,
                    Science = character.Skill.Science,
                    Sciencelvl = 0,
                    Survival = character.Skill.Survival,
                    Survivallvl = 0,
                    Bartering = character.Skill.Bartering,
                    Barteringlvl = 0,
                    BareHands = character.Skill.BareHands,
                    BareHandslvl = 0,
                    MeleeWeapon = character.Skill.MeleeWeapon,
                    MeleeWeaponlvl = 0,
                    LightWeapon = character.Skill.LightWeapon,
                    LightWeaponlvl = 0,
                    HeavyWeapon = character.Skill.HeavyWeapon,
                    HeavyWeaponlvl = 0,
                    EnergieWeapon = character.Skill.EnergieWeapon,
                    EnergieWeaponlvl = 0,
                    ThrowingWeapon = character.Skill.ThrowingWeapon,
                    ThrowingWeaponlvl = 0,
                    Explosive = character.Skill.Explosive,
                    Explosivelvl = 0,
                    Game = character.Skill.Game,
                    Gamelvl = 0,
                },
                BodyParts = bodyParts,
                Reputations = reputations,
                Weapons = weapons,
                Perks = perks,
                Inventories = new InventoryDTO
                {
                    Ammos = ammos,
                    Chemicals = chemicals,
                    Drinks = drinks,
                    Equipements = equipements,
                    Foods = foods,
                    Materials = materials,
                }
            };
            return characterDTO;
        }

        public IEnumerable<CharacterName>? CharacterListForATeam(string name)
        {
            List<CharacterName> characterList = new List<CharacterName>();
            List<Player> players = _falloutRPContext.Players
                .Include(p => p.Team)
                .Include(p => p.Character)
                .Where(p => p.Team.Name == name)
                .ToList();

            if (players.Count == 0)
            {
                throw new Exception("Cette équipe n'existe pas ou ne possède pas de joueur");
            }
            else
            {
                foreach (Player player in players)
                {
                    if(player.Character != null)
                    {
                        CharacterName characterName = new CharacterName
                        {
                            Id = player.Character.Id,
                            Name = player.Character.Name,
                        };
                        characterList.Add(characterName);
                    }
                }
                return characterList;
            }
        }
    }
}
