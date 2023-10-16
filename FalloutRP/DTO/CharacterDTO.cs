namespace FalloutRP.DTO
{
    public class CharacterDTO
    {
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
        public int PoisonResilience { get; set; }
        public string Background { get; set; } = string.Empty;
        public int Caps { get; set; }
        public int MaxWeight { get; set; }
        public int Weight { get; set; }
        public List<BodyPartDTO> BodyParts { get; set; }
        public SkillDTO Skills { get; set; }
    }
    public class BodyPartDTO
    {
        public int Part { get; set; }
        public int PhysicalResilience { get; set; }
        public int RadiationResilience { get; set; }
        public int EnergyResilience { get; set; }
        public int HealthResilience { get; set; }
    }
    public class SkillDTO
    {
        public bool RightHanded { get; set; }
        public bool LeftHanded { get; set; }
        public bool Athletics { get; set; }
        public bool Lockpicking { get; set; }
        public bool Speech { get; set; }
        public bool Stealth { get; set; }
        public bool Medecine { get; set; }
        public bool Driving { get; set; }
        public bool Repair { get; set; }
        public bool Science { get; set; }
        public bool Survival { get; set; }
        public bool Bartering { get; set; }
        public bool BareHands { get; set; }
        public bool MeleeWeapon { get; set; }
        public bool LightWeapon { get; set; }
        public bool HeavyWeapon { get; set; }
        public bool EnergieWeapon { get; set; }
        public bool ThrowingWeapon { get; set; }
        public bool Explosive { get; set; }
    }
}
