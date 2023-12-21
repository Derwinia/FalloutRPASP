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

        public CharacterDTO? CharacterGetByPseudo(string pseudo)
        {
            Player player = _falloutRPContext.Players.FirstOrDefault(p => p.Pseudo == pseudo);

            if (player == null)
            {
                throw new KeyNotFoundException("Joueur introuvable");
            }

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
                .FirstOrDefault(c => c.PlayerId == player.Id);

            if (character == null)
            {
                throw new KeyNotFoundException("Cet utilisateur n'a pas de personnage ?");
            }

            List<BodyPartDTO> bodyParts = character.BodyParts
                .Select(bodypart => new BodyPartDTO
                {
                    Id = bodypart.Id,
                    Part = bodypart.Part,
                    PhysicalResilience = bodypart.PhysicalResilience,
                    RadiationResilience = bodypart.RadiationResilience,
                    EnergyResilience = bodypart.EnergyResilience,
                    HealthResilience = bodypart.HealthResilience,
                })
                .OrderBy(bp => bp.Part)
                .ToList();

            List<ReputationDTO> reputations = new List<ReputationDTO>();

            foreach (Reputation reputation in character.Reputations)
            {
                ReputationDTO rep = new ReputationDTO
                {
                    Id = reputation.Id,
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
                    Id = weapon.Id,
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
                    Id = perk.Id,
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
                    Id = ammo.Id,
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
                    Id = chemical.Id,  
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
                    Id = drink.Id,
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
                    Id = equipement.Id,
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
                    Id = food.Id,
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
                    Id = material.Id,
                    Name = material.Name,
                    Quantity = material.Quantity,
                    Weight = material.Weight,
                };
                materials.Add(mat);
            }

            CharacterDTO characterDTO = new CharacterDTO()
            {
                Id= character.Id,
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
                    Id = character.Attributes.Id,
                    Strength = character.Attributes.Strength,
                    Perception = character.Attributes.Perception,
                    Endurance = character.Attributes.Endurance,
                    Charisme = character.Attributes.Charisme,
                    Intelligence = character.Attributes.Intelligence,
                    Agility = character.Attributes.Agility,
                    Luck = character.Attributes.Luck,
                    LuckPoints = character.Attributes.LuckPoints,
                },
                Skills = new SkillDTO
                {
                    Id = character.Skill.Id,
                    RightHanded = character.Skill.RightHanded,
                    LeftHanded = character.Skill.LeftHanded,
                    Athletics = character.Skill.Athletics,
                    Athleticslvl = character.Skill.Athleticslvl,
                    Lockpicking = character.Skill.Lockpicking,
                    Lockpickinglvl = character.Skill.Lockpickinglvl,
                    Speech = character.Skill.Speech,
                    Speechlvl = character.Skill.Speechlvl,
                    Stealth = character.Skill.Stealth,
                    Stealthlvl = character.Skill.Stealthlvl,
                    Medecine = character.Skill.Medecine,
                    Medecinelvl = character.Skill.Medecinelvl,
                    Driving = character.Skill.Driving,
                    Drivinglvl = character.Skill.Drivinglvl,
                    Repair = character.Skill.Repair,
                    Repairlvl = character.Skill.Repairlvl,
                    Science = character.Skill.Science,
                    Sciencelvl = character.Skill.Sciencelvl,
                    Survival = character.Skill.Survival,
                    Survivallvl = character.Skill.Survivallvl,
                    Bartering = character.Skill.Bartering,
                    Barteringlvl = character.Skill.Barteringlvl,
                    BareHands = character.Skill.BareHands,
                    BareHandslvl = character.Skill.Barteringlvl,
                    MeleeWeapon = character.Skill.MeleeWeapon,
                    MeleeWeaponlvl = character.Skill.MeleeWeaponlvl,
                    LightWeapon = character.Skill.LightWeapon,
                    LightWeaponlvl = character.Skill.LightWeaponlvl,
                    HeavyWeapon = character.Skill.HeavyWeapon,
                    HeavyWeaponlvl = character.Skill.HeavyWeaponlvl,
                    EnergieWeapon = character.Skill.EnergieWeapon,
                    EnergieWeaponlvl = character.Skill.EnergieWeaponlvl,
                    ThrowingWeapon = character.Skill.ThrowingWeapon,
                    ThrowingWeaponlvl = character.Skill.ThrowingWeaponlvl,
                    Explosive = character.Skill.Explosive,
                    Explosivelvl = character.Skill.Explosivelvl,
                    Game = character.Skill.Game,
                    Gamelvl = character.Skill.Gamelvl,
                },
                BodyParts = bodyParts,
                Reputations = reputations,
                Weapons = weapons,
                Perks = perks,
                Inventories = new InventoryDTO
                {
                    Id = character.Inventory.Id,
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

        public void CharacterUpdate(CharacterDTO characterUpdate)
        {
            Character? character = _falloutRPContext.Characters
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
                .FirstOrDefault(u => u.Id == characterUpdate.Id);

            if (character == null)
            {
                throw new KeyNotFoundException("Ce personnage n'existe pas");
            }
            #region character
            character.Name = characterUpdate.Name;
            character.Xp = characterUpdate.Xp;
            character.XpToNext = characterUpdate.XpToNext;
            character.Origin= characterUpdate.Origin;
            character.Level= characterUpdate.Level;
            character.MeleeBonus = characterUpdate.MeleeBonus;
            character.Defence= characterUpdate.Defence;
            character.Initiative= characterUpdate.Initiative;
            character.HealthPoint= characterUpdate.HealthPoint;
            character.HealthPointMax= characterUpdate.HealthPointMax;
            character.MentalHealthPoint= characterUpdate.MentalHealthPoint;
            character.MentalHealthPointMax = characterUpdate.MentalHealthPointMax;
            character.PoisonResilience= characterUpdate.PoisonResilience;
            character.Background= characterUpdate.Background;
            character.Caps= characterUpdate.Caps;
            character.MaxWeight= characterUpdate.MaxWeight;
            #endregion

            #region attributes
            character.Attributes.Strength = characterUpdate.Attributes.Strength;
            character.Attributes.Perception= characterUpdate.Attributes.Perception;
            character.Attributes.Endurance= characterUpdate.Attributes.Endurance;
            character.Attributes.Charisme= characterUpdate.Attributes.Charisme;
            character.Attributes.Intelligence= characterUpdate.Attributes.Intelligence;
            character.Attributes.Agility= characterUpdate.Attributes.Agility;
            character.Attributes.Luck= characterUpdate.Attributes.Luck;
            character.Attributes.LuckPoints= characterUpdate.Attributes.LuckPoints;
            #endregion

            #region skills
            character.Skill.RightHanded = characterUpdate.Skills.RightHanded;
            character.Skill.LeftHanded = characterUpdate.Skills.LeftHanded;
            character.Skill.Athletics = characterUpdate.Skills.Athletics;
            character.Skill.Athleticslvl = characterUpdate.Skills.Athleticslvl;
            character.Skill.Lockpicking = characterUpdate.Skills.Lockpicking;
            character.Skill.Lockpickinglvl = characterUpdate.Skills.Lockpickinglvl;
            character.Skill.Speech = characterUpdate.Skills.Speech;
            character.Skill.Speechlvl = characterUpdate.Skills.Speechlvl;
            character.Skill.Stealth = characterUpdate.Skills.Stealth;
            character.Skill.Stealthlvl = characterUpdate.Skills.Stealthlvl;
            character.Skill.Medecine = characterUpdate.Skills.Medecine;
            character.Skill.Medecinelvl = characterUpdate.Skills.Medecinelvl;
            character.Skill.Driving = characterUpdate.Skills.Driving;
            character.Skill.Drivinglvl = characterUpdate.Skills.Drivinglvl;
            character.Skill.Repair = characterUpdate.Skills.Repair;
            character.Skill.Repairlvl = characterUpdate.Skills.Repairlvl;
            character.Skill.Science = characterUpdate.Skills.Science;
            character.Skill.Sciencelvl = characterUpdate.Skills.Sciencelvl;
            character.Skill.Survival = characterUpdate.Skills.Survival;
            character.Skill.Survivallvl = characterUpdate.Skills.Survivallvl;
            character.Skill.Bartering = characterUpdate.Skills.Bartering;
            character.Skill.Barteringlvl = characterUpdate.Skills.Barteringlvl;
            character.Skill.BareHands = characterUpdate.Skills.BareHands;
            character.Skill.BareHandslvl = characterUpdate.Skills.BareHandslvl;
            character.Skill.MeleeWeapon = characterUpdate.Skills.MeleeWeapon;
            character.Skill.MeleeWeaponlvl = characterUpdate.Skills.MeleeWeaponlvl;
            character.Skill.LightWeapon = characterUpdate.Skills.LightWeapon;
            character.Skill.LightWeaponlvl = characterUpdate.Skills.LightWeaponlvl;
            character.Skill.HeavyWeapon = characterUpdate.Skills.HeavyWeapon;
            character.Skill.HeavyWeaponlvl = characterUpdate.Skills.HeavyWeaponlvl;
            character.Skill.EnergieWeapon = characterUpdate.Skills.EnergieWeapon;
            character.Skill.EnergieWeaponlvl = characterUpdate.Skills.EnergieWeaponlvl;
            character.Skill.ThrowingWeapon = characterUpdate.Skills.ThrowingWeapon;
            character.Skill.ThrowingWeaponlvl = characterUpdate.Skills.ThrowingWeaponlvl;
            character.Skill.Explosive = characterUpdate.Skills.Explosive;
            character.Skill.Explosivelvl = characterUpdate.Skills.Explosivelvl;
            character.Skill.Game = characterUpdate.Skills.Game;
            character.Skill.Gamelvl = characterUpdate.Skills.Gamelvl;
            #endregion

            #region bodypart
            foreach (BodyPart bodypart in character.BodyParts)
            {
                BodyPartDTO bp = characterUpdate.BodyParts.Find(b => b.Id == bodypart.Id);
                if(bp != null)
                {
                    bodypart.PhysicalResilience = bp.PhysicalResilience;
                    bodypart.RadiationResilience = bp.RadiationResilience;
                    bodypart.EnergyResilience = bp.EnergyResilience;
                    bodypart.HealthResilience = bp.HealthResilience;
                }
            }
            
            #endregion

            #region reputation
            foreach (Reputation rep in character.Reputations)
            {
                ReputationDTO newrep = characterUpdate.Reputations.Find(r => r.Id == rep.Id);
                rep.Rank = newrep.Rank;
                rep.Name = newrep.Name;
            }
            #endregion

            #region weapon
            foreach (Weapon weapon in character.Weapons)
            {
                WeaponDTO newweapon = characterUpdate.Weapons.Find(w => w.Id == weapon.Id);
                weapon.Name = newweapon.Name;
                weapon.TN = newweapon.TN;
                weapon.DC = newweapon.DC;
                weapon.PhysicalDamage = newweapon.PhysicalDamage;
                weapon.EnergyDamage = newweapon.EnergyDamage;
                weapon.RadiationDamage = newweapon.RadiationDamage;
                weapon.PoisonDamage = newweapon.PoisonDamage;
                weapon.Effects = newweapon.Effects;
                weapon.Proprieties = newweapon.Proprieties;
                weapon.RateOfFire = newweapon.RateOfFire;
                weapon.Range = newweapon.Range;
                weapon.Ammo = newweapon.Ammo;
                weapon.Weigth = newweapon.Weigth;
            }
            #endregion

            #region perks
            foreach (Perk perk in character.Perks)
            {
                PerkDTO newperk = characterUpdate.Perks.Find(r => r.Id == perk.Id);
                perk.Name = newperk.Name;
                perk.Rank = newperk.Rank;
                perk.Effect = newperk.Effect;
            }
            #endregion

            #region ammo
            foreach (Ammo ammo in character.Inventory.Ammos)
            {
                AmmoDTO newammo = characterUpdate.Inventories.Ammos.Find(r => r.Id == ammo.Id);
                ammo.Name = newammo.Name;
                ammo.Quantity = newammo.Quantity;
                ammo.Weight = newammo.Weight;
            }
            #endregion

            #region chemical
            foreach (Chemical chemical in character.Inventory.Chemicals)
            {
                ChemicalDTO newchem = characterUpdate.Inventories.Chemicals.Find(r => r.Id == chemical.Id);
                chemical.Name = newchem.Name;
                chemical.Quantity = newchem.Quantity;
                chemical.Weight = newchem.Weight;
            }
            #endregion

            #region drink
            foreach (Drink drink in character.Inventory.Drinks)
            {
                DrinkDTO newdrink = characterUpdate.Inventories.Drinks.Find(r => r.Id == drink.Id);
                drink.Name = newdrink.Name;
                drink.Quantity = newdrink.Quantity;
                drink.Weight = newdrink.Weight;
            }
            #endregion

            #region equipement
            foreach (Equipement equip in character.Inventory.Equipements)
            {
                EquipementDTO newequip = characterUpdate.Inventories.Equipements.Find(r => r.Id == equip.Id);
                equip.Name = newequip.Name;
                equip.Quantity = newequip.Quantity;
                equip.Weight = newequip.Weight;
            }
            #endregion

            #region food
            foreach (Food food in character.Inventory.Foods)
            {
                FoodDTO newfood = characterUpdate.Inventories.Foods.Find(r => r.Id == food.Id);
                food.Name = newfood.Name;
                food.Quantity = newfood.Quantity;
                food.Weight = newfood.Weight;
            }
            #endregion

            #region material
            foreach (Material mat in character.Inventory.Materials)
            {
                MaterialDTO newmat = characterUpdate.Inventories.Materials.Find(r => r.Id == mat.Id);
                mat.Name = newmat.Name;
                mat.Quantity = newmat.Quantity;
                mat.Weight = newmat.Weight;
            }
            #endregion

            _falloutRPContext.SaveChanges();
        }

        public int CharacterPerkCreate(int concernedCharacter)
        {
            Perk newPerk = new Perk
            {
                Name = "x",
                Rank = 0,
                Effect = "x",
                CharacterId = concernedCharacter,
            };
            _falloutRPContext.Perks.Add(newPerk);
            _falloutRPContext.SaveChanges();

            return newPerk.Id;
        }

        public void CharacterPerkDelete(int perkId)
        {
            Perk perk = _falloutRPContext.Perks.FirstOrDefault(x => x.Id == perkId);

            if(perk == null)
            {
                throw new KeyNotFoundException("Cette compétence n'existe pas");
            }

            _falloutRPContext.Perks.Remove(perk);

            _falloutRPContext.SaveChanges();
        }

        public IEnumerable<CharacterName>? CharacterNameListForATeam(string teamName)
        {
            List<CharacterName> characterList = new List<CharacterName>();
            List<Player> players = _falloutRPContext.Players
                .Include(p => p.Team)
                .Include(p => p.Character)
                .Where(p => p.Team.Name == teamName)
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
