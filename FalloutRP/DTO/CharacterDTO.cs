﻿using FalloutRPDAL.Entities.CharacterClasses;

namespace FalloutRP.DTO
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Xp { get; set; }
        public int XpToNext { get; set; }
        public string Origin { get; set; } = string.Empty;
        public int Level { get; set; }
        public int MeleeBonus { get; set; }
        public int Defence { get; set; }
        public int Initiative { get; set; }
        public int HealthPoint { get; set; }
        public int HealthPointMax { get; set; }
        public int MentalHealthPoint { get; set; }
        public int MentalHealthPointMax { get; set; }
        public int PoisonResilience { get; set; }
        public string Background { get; set; } = string.Empty;
        public int Caps { get; set; }
        public float MaxWeight { get; set; }
        public AttributeDTO Attributes { get; set; } = new AttributeDTO();
        public SkillDTO Skills { get; set; } = new SkillDTO();
        public List<BodyPartDTO> BodyParts { get; set; } = new List<BodyPartDTO>();
        public List<ReputationDTO> Reputations { get;set; } = new List<ReputationDTO>();   
        public List<WeaponDTO> Weapons { get;set; } = new List<WeaponDTO>();
        public List<PerkDTO> Perks { get;set; } = new List<PerkDTO>();
        public InventoryDTO Inventories { get; set; } = new InventoryDTO();
    }
    public class AttributeDTO
    {
        public int Id { get; set; }
        public int Strength { get; set; }
        public int Perception { get; set; }
        public int Endurance { get; set; }
        public int Charisme { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Luck { get; set; }
        public int LuckPoints { get; set; }
    }
    public class SkillDTO
    {
        public int Id { get; set; }
        public bool RightHanded { get; set; }
        public bool LeftHanded { get; set; }
        public bool Athletics { get; set; }
        public int Athleticslvl { get; set; }
        public bool Lockpicking { get; set; }
        public int Lockpickinglvl { get; set; }
        public bool Speech { get; set; }
        public int Speechlvl { get; set; }
        public bool Stealth { get; set; }
        public int Stealthlvl { get; set; }
        public bool Medecine { get; set; }
        public int Medecinelvl { get; set; }
        public bool Driving { get; set; }
        public int Drivinglvl { get; set; }
        public bool Repair { get; set; }
        public int Repairlvl { get; set; }
        public bool Science { get; set; }
        public int Sciencelvl { get; set; }
        public bool Survival { get; set; }
        public int Survivallvl { get; set; }
        public bool Bartering { get; set; }
        public int Barteringlvl { get; set; }
        public bool BareHands { get; set; }
        public int BareHandslvl { get; set; }
        public bool MeleeWeapon { get; set; }
        public int MeleeWeaponlvl { get; set; }
        public bool LightWeapon { get; set; }
        public int LightWeaponlvl { get; set; }
        public bool HeavyWeapon { get; set; }
        public int HeavyWeaponlvl { get; set; }
        public bool EnergieWeapon { get; set; }
        public int EnergieWeaponlvl { get; set; }
        public bool ThrowingWeapon { get; set; }
        public int ThrowingWeaponlvl { get; set; }
        public bool Explosive { get; set; }
        public int Explosivelvl { get; set; }
        public bool Game { get; set; }
        public int Gamelvl { get; set; }
    }
    public class BodyPartDTO
    {
        public int Id { get; set; }
        public int Part { get; set; }
        public int PhysicalResilience { get; set; }
        public int RadiationResilience { get; set; }
        public int EnergyResilience { get; set; }
        public int HealthResilience { get; set; }
    }
    public class ReputationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Rank { get; set; }
    }
    public class WeaponDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TN { get; set; }
        public int DC { get; set; }
        public bool PhysicalDamage { get; set; }
        public bool EnergyDamage { get; set; }
        public bool RadiationDamage { get; set; }
        public bool PoisonDamage { get; set; }
        public string Effects { get; set; } = string.Empty;
        public string Proprieties { get; set; } = string.Empty;
        public int RateOfFire { get; set; }
        public int Range { get; set; }
        public int Ammo { get; set; }
        public float Weigth { get; set; }
    }
    public class PerkDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Rank { get; set; }
        public string Effect { get; set; } = string.Empty;
    }
    public class PerkCreateDTO
    {
        public string Name { get; set; } = string.Empty;
    }
    public class InventoryDTO
    {
        public int Id { get; set; }
        public List<AmmoDTO> Ammos { get; set; } = new List<AmmoDTO>();
        public List<ChemicalDTO> Chemicals { get; set; } = new List<ChemicalDTO>();
        public List<DrinkDTO> Drinks { get; set; } = new List<DrinkDTO>();
        public List<EquipementDTO> Equipements { get; set; } = new List<EquipementDTO>();
        public List<FoodDTO> Foods { get; set; } = new List<FoodDTO>();
        public List<MaterialDTO> Materials { get; set; } = new List<MaterialDTO>();
    }
    public class AmmoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float Weight { get; set; }
    }
    public class ChemicalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float Weight { get; set; }
    }
    public class DrinkDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float Weight { get; set; }
    }
    public class EquipementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float Weight { get; set; }
    }
    public class FoodDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float Weight { get; set; }
    }
    public class MaterialDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float Weight { get; set; }
    }
    public class CharacterName
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
