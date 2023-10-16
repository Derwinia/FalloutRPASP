using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FalloutRPDAL.Entities.CharacterClasses
{
    public class Character
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
        public int PoisonResilience { get; set; }
        public string Background { get; set; } = string.Empty;
        public int Caps { get; set; }
        public int MaxWeight { get; set; }


        // Foreign Keys
        public int PlayerId { get; set; }
        public Skill? Skill { get; set; }
        public ICollection<BodyPart>? BodyParts { get; set; }
        public ICollection<Weapon>? Weapons { get; set; }
        public ICollection<Perk>? Perks { get; set; }
        public ICollection<Reputation>? Reputations { get; set; }
        public Inventory? Inventory { get; set; }
    }
}
