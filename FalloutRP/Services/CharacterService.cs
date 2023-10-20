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
                    Speech = character.Skill.Speech,
                    Stealth = character.Skill.Stealth,
                    Medecine = character.Skill.Medecine,
                    Driving = character.Skill.Driving,
                    Repair = character.Skill.Repair,
                    Science = character.Skill.Science,
                    Survival = character.Skill.Survival,
                    Bartering = character.Skill.Bartering,
                    BareHands = character.Skill.BareHands,
                    MeleeWeapon = character.Skill.MeleeWeapon,
                    LightWeapon = character.Skill.LightWeapon,
                    HeavyWeapon = character.Skill.HeavyWeapon,
                    EnergieWeapon = character.Skill.EnergieWeapon,
                    ThrowingWeapon = character.Skill.ThrowingWeapon,
                    Explosive = character.Skill.Explosive,
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
    }
}
