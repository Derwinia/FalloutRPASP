using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutRPDAL.Entities.CharacterClasses
{
    public class Skill
    {
        public int Id { get; set; }
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

        // Foreign Keys
        public int CharacterId { get; set; }
    }
}
